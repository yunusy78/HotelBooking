using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfRoomRepository : EfGenericRepository<Room>, IEfRoomRepository
{
    public EfRoomRepository(HotelBookingDbContext context) : base(context)
    {
    }
}