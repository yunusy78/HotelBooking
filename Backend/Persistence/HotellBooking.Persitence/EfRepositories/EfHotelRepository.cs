using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfHotelRepository : EfGenericRepository<Hotel>, IEfHotelRepository
{
    public EfHotelRepository(HotelBookingDbContext context) : base(context)
    {
    }
}