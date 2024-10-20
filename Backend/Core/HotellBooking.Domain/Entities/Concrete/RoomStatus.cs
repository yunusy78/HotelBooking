using HotellBooking.Domain.Entities.Abstract;

namespace HotellBooking.Domain.Entities.Concrete;

public class RoomStatus
{ 
   
   public int Id { get; set; }
   public RoomStatusEnum Status { get; set; } 
   public Room Room { get; set; }
   public int RoomId { get; set; }
   
   public DateTime Date { get; set; }
    
}