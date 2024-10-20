namespace HotellBooking.Domain.Entities.Concrete;

public class HotelImage
{
    public int Id { get; set; }
    
    public int HotelId { get; set; }
    
    public Hotel Hotels { get; set; }
    
    public string? ImagePath { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}