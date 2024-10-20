using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Persitence.Context;

public class HotelBookingDbContext : IdentityDbContext<ApplicationUser>
{
 
    public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options)
    {
    }
    
    public DbSet<Owner> Owners { get; set; }
    
    public DbSet<Address> Addresses { get; set; }
   
    public DbSet<Hotel> Hotels { get; set; }
    
    public DbSet<Room> Rooms { get; set; }
    
    public DbSet<RoomType> RoomTypes { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<Guest> Guests { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<RoomFacility> RoomFacilities { get; set; }
    
    
    public DbSet<Facility> Facilities { get; set; }
    
    public DbSet<RoomImage> RoomImages { get; set; }
    
    public DbSet<Information> Informations { get; set; }
    
    public DbSet<HotelImage> HotelImages { get; set; }
    
    public DbSet<RoomStatus> RoomStatuses { get; set; }
    
    
    public DbSet<SocialMedia> SocialMedias { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
    
}