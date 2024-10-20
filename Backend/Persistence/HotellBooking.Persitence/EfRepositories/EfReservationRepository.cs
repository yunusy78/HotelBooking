using System.Linq.Expressions;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Persitence.EfRepositories;

public class EfReservationRepository : EfGenericRepository<Reservation>, IEfReservationRepository
{
    public EfReservationRepository(HotelBookingDbContext context) : base(context)
    {
    }

    public async Task<Reservation> CreateReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return reservation;
        
    }

    public Task<Reservation> UpdateReservationAsync(Reservation reservation)
    {
        throw new NotImplementedException();
    }

    public Task<List<Reservation>> GetReservationWithRoomAndStatusAndPricingAsync()
    {
        var reservations = _context.Reservations
            .Include(r => r.Room)
            .ThenInclude(x=>x.Type) 
            .Include(r => r.Room)
            .ThenInclude(x=>x.RoomImages)
            .Include(r => r.Room)
            .ThenInclude(x=>x.RoomFacilities)!
            .ThenInclude(x=>x.Facilities)
            .Include(r => r.Room)
            .ThenInclude(x=>x.Hotel)
            .Include(x=>x.GuestLists)
            .ToListAsync();
        return reservations;
    }

    public Task<List<Reservation>> GetByFilterAsync(Expression<Func<Reservation, bool>> filter)
    {
        throw new NotImplementedException();
    }
}