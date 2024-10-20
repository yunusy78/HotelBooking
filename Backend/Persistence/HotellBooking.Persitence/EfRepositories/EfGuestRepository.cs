using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfGuestRepository : EfGenericRepository<Guest>, IEfGuestRepository
{
    public EfGuestRepository(HotelBookingDbContext context) : base(context)
    {
    }
}