namespace HotellBooking.Domain.Entities.Concrete;

public class RoomImage
{
    
    public int Id { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
    
}