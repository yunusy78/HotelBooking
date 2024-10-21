namespace HotellBooking.Domain.DTOs.RoomDto;

public class GetResultRoomDto
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? Capacity { get; set; }
    
    public int HotelId { get; set; }
    
    public decimal AdultPrice { get; set; }
    
    public decimal ChildPrice { get; set; }
    
    public decimal BabyPrice { get; set; }
    
    public int RoomTypeId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}