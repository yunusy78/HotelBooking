using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfHotelImageRepository : EfGenericRepository<HotelImage>, IEfHotelImageRepository
{
    public EfHotelImageRepository(HotelBookingDbContext context) : base(context)
    {
    }
}