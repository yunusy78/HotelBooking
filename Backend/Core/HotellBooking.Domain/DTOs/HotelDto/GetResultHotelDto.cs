﻿namespace HotellBooking.Domain.DTOs.HotelDto;

public class GetResultHotelDto
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
}