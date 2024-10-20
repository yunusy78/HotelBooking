using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;

namespace HotellBooking.Persitence.EfRepositories;

public class EfInformationRepository : EfGenericRepository<Information>, IEfInformationRepository
{
    public EfInformationRepository(HotelBookingDbContext context) : base(context)
    {
    }
}