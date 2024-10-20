using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfOwnerRepository : EfGenericRepository<Owner>, IEfOwnerRepository
{
    public EfOwnerRepository(HotelBookingDbContext context) : base(context)
    {
    }
}