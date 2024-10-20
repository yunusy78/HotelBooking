using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfRoomTypeRepository : EfGenericRepository<RoomType>, IEfRoomTypeRepository
{
    public EfRoomTypeRepository(HotelBookingDbContext context) : base(context)
    {
    }
}