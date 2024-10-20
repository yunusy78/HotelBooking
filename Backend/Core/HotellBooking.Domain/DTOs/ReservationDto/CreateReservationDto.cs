﻿
using HotellBooking.Domain.Entities.Concrete;

namespace HotellBooking.Domain.DTOs.ReservationDto;

public class CreateReservationDto
{
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    
    public int AdultCount { get; set; }
    
    public int ChildCount { get; set; }
    
    public int Baby { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}