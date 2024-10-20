namespace HotellBooking.Domain.Entities.Concrete;

public class RoomFacility
{
    public int Id { get; set; }
    
    public int RoomId { get; set; }
    
    public Room Rooms { get; set; }
    
    public int FacilityId { get; set; }
    
    public Facility Facilities { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}