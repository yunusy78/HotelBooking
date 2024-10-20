using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfRoomFacilityRepository : EfGenericRepository<RoomFacility>, IEfRoomFacilityRepository
{
    public EfRoomFacilityRepository(HotelBookingDbContext context) : base(context)
    {
    }
}