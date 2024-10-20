using HotellBooking.Domain.Entities.Abstract;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Persitence.Context;

public class DbInitializer
{
    public static async Task InitializeAsync(
       HotelBookingDbContext context,
        UserManager<ApplicationUser> um,
        RoleManager<IdentityRole> rm)
    {
        try
        {
            // Ensure database is created
            if (context.Database.IsSqlite())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            
            
            
            var hotel = new Hotel
            {
                Name = "Hotel Oslo",
                Description = "Hotel Oslo is a 5-star hotel located in the heart of Oslo.",
               
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                    
            };
            
            context.Hotels.Add(hotel);
            context.SaveChanges();
            
            var address = new Address
            {
                AddressLine = "Osloveien 1",
                City = "Oslo",
                Phone = "1234",
                PostalCode = "1234",
                Country = "Norway",
               
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                
                HotelId = hotel.Id
            };
            
            context.Addresses.Add(address);
            context.SaveChanges();
            
            var information = new Information
            {
                Title = "Hotel Oslo",
                Description = "Hotel Oslo is a 5-star hotel located in the heart of Oslo.",
                OpeningHours = "24/7",
                PhoneNumber = "1234",
                Email = "HotellBooking@gmail.com",
                Star = 5,
                HotelId = hotel.Id,
                
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                
            };
            
            context.Informations.Add(information);
            context.SaveChanges();
            
            var roomType = new RoomType
            
            {
                Name = "Single Room",
                Description = "A single room is a room with one single bed.",
                
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                
            };
            
            context.RoomTypes.Add(roomType);
            context.SaveChanges();
            
            var room = new Room
            {
                Name = "101",
                Description = "A single room with a view of the city.",
                RoomTypeId = roomType.Id,
                Capacity = 4,
                InformationId =information.Id,
                ChildPrice = 200,
                BabyPrice = 0,
                AdultPrice = 300,
                HotelId = hotel.Id,
               
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                
            };
            
            context.Rooms.Add(room);
            context.SaveChanges();
            
            var roomImage = new RoomImage
            {
                RoomId = room.Id,
                ImageUrl = "https://via.placeholder.com/150",
                
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                
            };
            
            context.RoomImages.Add(roomImage);
            context.SaveChanges();
            
            var hotelImage = new HotelImage
            {
                HotelId = hotel.Id,
                ImagePath = "https://via.placeholder.com/150",
                
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                
            };
            
            context.HotelImages.Add(hotelImage);
            context.SaveChanges();
            
            
            var facilities = new List<Facility>
            {
                new Facility
                {
                    Name = "Free Wifi",
                    Description = "Free wifi is available in all rooms.",
                    
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true
                    
                },
                new Facility
                {
                    Name = "Breakfast",
                    Description = "Breakfast is included in the price.",
                   
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true
                    
                }
            };
            
            context.Facilities.AddRange(facilities);
            context.SaveChanges();
            
            var roomFacilities = new List<RoomFacility>
            {
                new RoomFacility
                {
                    RoomId = room.Id,
                    FacilityId = facilities[0].Id,
                 
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true
                    
                },
                new RoomFacility
                {
                    RoomId = room.Id,
                    FacilityId = facilities[1].Id,
                    
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true
                    
                }
            };
            
            context.RoomFacilities.AddRange(roomFacilities);
            context.SaveChanges();

            // Create roles
            var roles = Enum.GetValues(typeof(UserRoleEnum));
            foreach (UserRoleEnum role in roles)
            {
                if (!await rm.RoleExistsAsync(role.ToString()))
                {
                    await rm.CreateAsync(new IdentityRole(role.ToString()));
                }
            }

            // Create users
            var users = new (ApplicationUser User, string Password, UserRoleEnum Role)[]
            {
                (new ApplicationUser { UserName = "hotelbooking" , ProfilePicture = "ProfilePicture",FirstName = "yunus", LastName = "yigit", Address = "abc" , Email = "yunus@hotelbooking.no", EmailConfirmed = true}, "Password1.", UserRoleEnum.Admin),
                (new Owner { UserName = "owner", FirstName = "owner",  Address= "Address", ProfilePicture="ProfilePicture",  CompanyName = "Owner", CompanyPhone = "12345", CompanyAddress = "Streeet",LastName = "owner", Email = "owner@hotelbooking.no" , EmailConfirmed = true}, "Password1.", UserRoleEnum.Owner),
                (new Employee { UserName = "Employee", ProfilePicture="ProfilePicture",FirstName = "Employee",  Address= "Address",Title = "Leder", EmployeeCode = "EmployeeCode", LastName = "Employee", Email = "employee@hotelbooking.no", EmailConfirmed = true}, "Password1.", UserRoleEnum.Employee),
                (new Guest { UserName = "guest", ProfilePicture="ProfilePicture",FirstName = "guest",  Address= "Address",LastName = "guest", Email = "guest@hotelbooking.no", EmailConfirmed = true}, "Password1.", UserRoleEnum.Guest)

            };
            
            foreach (var (user, password, role) in users)
            {
                var result = await um.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await um.AddToRoleAsync(user, role.ToString());
                }
                else
                {
                    // Log or handle errors from user creation
                    Console.WriteLine($"Failed to create user {user.UserName}: {string.Join(", ", result.Errors)}");
                }
            }

            // Save changes
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
        }
    }
}
