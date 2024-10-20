namespace HotellBooking.Domain.Entities.Concrete;

public class Information
{
    
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
    
    public int Star { get; set; }
    
    public int HotelId { get; set; }
    
    public Hotel? Hotel { get; set; }
    
    public string? OpeningHours { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}