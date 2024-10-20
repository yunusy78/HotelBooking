using HotellBooking.Domain.Entities.Concrete;

namespace HotellBooking.Application.Interfaces;

public interface IEfRoomStatusRepository : IEfGenericRepository<RoomStatus>   
{
    Task<bool> StatsCheckAsync(int roomId, DateTime startDate, DateTime endDate);
    
    Task<bool> AddRoomStatusForReservationAsync(RoomStatus roomStatus);
    
}