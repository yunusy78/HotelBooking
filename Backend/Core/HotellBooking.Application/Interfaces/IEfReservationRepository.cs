using System.Linq.Expressions;
using HotellBooking.Domain.Entities.Concrete;

namespace HotellBooking.Application.Interfaces;

public interface IEfReservationRepository : IEfGenericRepository<Reservation>
{
    Task<Reservation> CreateReservationAsync(Reservation reservation);
    Task<Reservation> UpdateReservationAsync(Reservation reservation);
    Task<List<Reservation>> GetReservationWithRoomAndStatusAndPricingAsync();
    Task<List<Reservation>> GetByFilterAsync(Expression<Func<Reservation, bool>> filter);
    
}