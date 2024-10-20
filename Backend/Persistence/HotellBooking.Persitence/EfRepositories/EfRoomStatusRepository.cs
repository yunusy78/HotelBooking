using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Persitence.EfRepositories;

public class EfRoomStatusRepository : EfGenericRepository<RoomStatus>, IEfRoomStatusRepository
{
    public EfRoomStatusRepository(HotelBookingDbContext context) : base(context)
    {
    }

    public async Task<bool> StatsCheckAsync(int roomId, DateTime startDate, DateTime endDate)
    {
        var result = await _context.RoomStatuses
            .Where(x => x.RoomId == roomId && x.Date >= startDate && x.Date <= endDate)
            .ToListAsync();
        return !result.Any();
       
    }

    public Task<bool> AddRoomStatusForReservationAsync(RoomStatus roomStatus)
    {
        throw new NotImplementedException();
    }
}