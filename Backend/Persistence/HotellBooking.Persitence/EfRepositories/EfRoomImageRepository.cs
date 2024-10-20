using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfRoomImageRepository : EfGenericRepository<RoomImage>, IEfRoomImageRepository
{
    public EfRoomImageRepository(HotelBookingDbContext context) : base(context)
    {
    }
}