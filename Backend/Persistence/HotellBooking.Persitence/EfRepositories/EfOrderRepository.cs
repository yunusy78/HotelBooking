using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfOrderRepository : EfGenericRepository<Order>, IEfOrderRepository
{
    public EfOrderRepository(HotelBookingDbContext context) : base(context)
    {
    }
}