using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfAddressRepository : EfGenericRepository<Address>, IEfAddressRepository
{
    public EfAddressRepository(HotelBookingDbContext context) : base(context)
    {
    }
}