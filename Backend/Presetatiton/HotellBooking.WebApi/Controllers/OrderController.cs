using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.GuestList;
using HotellBooking.Domain.DTOs.OrderDto;
using HotellBooking.Domain.DTOs.ReservationDto;
using HotellBooking.Domain.Entities.Abstract;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotellBooking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IEfOrderRepository _orderService;
    private readonly IMapper _mapper;
    
    public OrderController(IEfOrderRepository orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return Ok(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderDto dto)
    {
        var mappedOrder = _mapper.Map<Order>(dto);
        var newOrder = await _orderService.AddAsync(mappedOrder);
        return Ok("Order created successfully");
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateOrderDto dto)
    {
        var order = await _orderService.GetByIdAsync(dto.Id);
        if (order == null)
        {
            return NotFound();
        }
        
        var mappedOrder = _mapper.Map(dto, order);
        await _orderService.UpdateAsync(mappedOrder);
        return Ok("Order updated successfully");
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        
        await _orderService.DeleteAsync(order);
        return Ok("Order deleted successfully");
    }
   
}