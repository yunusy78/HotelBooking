using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfGuestListRepository : EfGenericRepository<GuestList>, IEfGuestListRepository
{
    public EfGuestListRepository(HotelBookingDbContext context) : base(context)
    {
    }
}