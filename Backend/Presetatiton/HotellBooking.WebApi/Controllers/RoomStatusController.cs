using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.RoomStatusDto;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotellBooking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomStatusController : ControllerBase
{
    private readonly IEfRoomStatusRepository _RoomStatusService;
    private readonly IMapper _mapper;
    
    public RoomStatusController(IEfRoomStatusRepository RoomStatusService, IMapper mapper)
    {
        _RoomStatusService = RoomStatusService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var RoomStatuss = await _RoomStatusService.GetAllAsync();
        return Ok(RoomStatuss);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var RoomStatus = await _RoomStatusService.GetByIdAsync(id);
        return Ok(RoomStatus);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateRoomStatusDto dto)
    {
        var mappedRoomStatus = _mapper.Map<RoomStatus>(dto);
        var newRoomStatus = await _RoomStatusService.AddAsync(mappedRoomStatus);
        return Ok("RoomStatus created successfully");
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateRoomStatusDto dto)
    {
        var RoomStatus = await _RoomStatusService.GetByIdAsync(dto.Id);
        if (RoomStatus == null)
        {
            return NotFound();
        }
        
        var mappedRoomStatus = _mapper.Map(dto, RoomStatus);
        await _RoomStatusService.UpdateAsync(mappedRoomStatus);
        return Ok("RoomStatus updated successfully");
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        var RoomStatus = await _RoomStatusService.GetByIdAsync(id);
        if (RoomStatus == null)
        {
            return NotFound();
        }
        
        await _RoomStatusService.DeleteAsync(RoomStatus);
        return Ok("RoomStatus deleted successfully");
    }
   
}