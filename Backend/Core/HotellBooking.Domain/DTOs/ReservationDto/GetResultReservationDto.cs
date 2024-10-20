using System.Collections;
using HotellBooking.Domain.DTOs.GuestList;

namespace HotellBooking.Domain.DTOs.ReservationDto;

public class GetResultReservationDto
{
    
    public int Id { get; set; }
    public int RoomId { get; set; }
    
    public int GuestId { get; set; }
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }
    
    public int AdultCount { get; set; }
    
    public int ChildCount { get; set; }
    
    public int Baby { get; set; }
    
    public string? RoomHotelName { get; set; }
    
    public string? RoomName { get; set; }
    
    public string RoomTypeName { get; set; }
    
    public decimal RoomAdultPrice { get; set; }
    
    public decimal RoomChildPrice { get; set; }
    
    public decimal RoomBabyPrice { get; set; }
    
    public ICollection<GetResultGuestListDto>? GuestLists { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
    
}