using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfEmployeeRepository : EfGenericRepository<Employee>, IEfEmployeeRepository
{
    public EfEmployeeRepository(HotelBookingDbContext context) : base(context)
    {
    }
}