using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.GuestList;
using HotellBooking.Domain.DTOs.RoomDto;
using HotellBooking.Domain.DTOs.ReservationDto;
using HotellBooking.Domain.Entities.Abstract;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotellBooking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IEfRoomRepository _RoomService;
    private readonly IMapper _mapper;
    
    public RoomController(IEfRoomRepository RoomService, IMapper mapper)
    {
        _RoomService = RoomService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Rooms = await _RoomService.GetAllAsync();
        return Ok(Rooms);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var Room = await _RoomService.GetByIdAsync(id);
        return Ok(Room);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateRoomDto dto)
    {
        var mappedRoom = _mapper.Map<Room>(dto);
        var newRoom = await _RoomService.AddAsync(mappedRoom);
        return Ok("Room created successfully");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, CreateRoomDto dto)
    {
        var Room = await _RoomService.GetByIdAsync(id);
        if (Room == null)
        {
            return NotFound();
        }
        
        var mappedRoom = _mapper.Map(dto, Room);
        await _RoomService.UpdateAsync(mappedRoom);
        return Ok("Room updated successfully");
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Room = await _RoomService.GetByIdAsync(id);
        if (Room == null)
        {
            return NotFound();
        }
        
        await _RoomService.DeleteAsync(Room);
        return Ok("Room deleted successfully");
    }
   
}