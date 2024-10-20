using System.Collections;

namespace HotellBooking.Domain.Entities.Concrete;

public class Room
{
    
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? Capacity { get; set; }
    
    public int InformationId { get; set; }
    
    public int HotelId { get; set; }
    
    public Hotel? Hotel { get; set; }
    
    public decimal AdultPrice { get; set; }
    
    public decimal ChildPrice { get; set; }
    
    public decimal BabyPrice { get; set; }
    
    public int RoomTypeId { get; set; }
    
    public RoomType? Type { get; set; }
    
    public ICollection<RoomImage>? RoomImages { get; set; }
    public ICollection<RoomFacility>? RoomFacilities { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}