namespace HotellBooking.Domain.Entities.Concrete;

public class Reservation
{
    public int Id { get; set; }
    
    public int RoomId { get; set; }
    
    public Room Room { get; set; }
    
    public ICollection<GuestList> GuestLists { get; set; }
    
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