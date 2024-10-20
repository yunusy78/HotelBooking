using HotellBooking.Domain.Entities.Abstract;

namespace HotellBooking.Domain.DTOs.RoomStatusDto;

public class GetResultRoomStatusDto
{
    public int Id { get; set; }
    public RoomStatusEnum Status { get; set; } 
    public int RoomId { get; set; }
   
    public DateTime Date { get; set; }

    
}