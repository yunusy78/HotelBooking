using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfFacilityRepository : EfGenericRepository<Facility>, IEfFacilityRepository
{
    public EfFacilityRepository(HotelBookingDbContext context) : base(context)
    {
    }
}