using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.HotelDto;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotellBooking.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IEfHotelRepository _HotelService;
    private readonly IMapper _mapper;
    
    public HotelController(IEfHotelRepository HotelService, IMapper mapper)
    {
        _HotelService = HotelService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Hotels = await _HotelService.GetAllAsync();
        return Ok(Hotels);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var Hotel = await _HotelService.GetByIdAsync(id);
        return Ok(Hotel);
    }
    
    [Authorize (Roles = "Owner")]
    [HttpPost]
    public async Task<IActionResult> Post(CreateHotelDto dto)
    {
        var mappedHotel = _mapper.Map<Hotel>(dto);
        var newHotel = await _HotelService.AddAsync(mappedHotel);
        return Ok("Hotel created successfully");
    }
    
    
    [Authorize (Roles = "Owner")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateHotelDto dto)
    {
        var Hotel = await _HotelService.GetByIdAsync(dto.Id);
        if (Hotel == null)
        {
            return NotFound();
        }
        
        var mappedHotel = _mapper.Map(dto, Hotel);
        await _HotelService.UpdateAsync(mappedHotel);
        return Ok("Hotel updated successfully");
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Hotel = await _HotelService.GetByIdAsync(id);
        if (Hotel == null)
        {
            return NotFound();
        }
        
        await _HotelService.DeleteAsync(Hotel);
        return Ok("Hotel deleted successfully");
    }
   
}