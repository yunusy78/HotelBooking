using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.ApplicationUserDto;
using HotellBooking.Domain.Entities.Concrete;
using HotellBooking.Persitence.Context;
using Microsoft.AspNetCore.Identity;

namespace HotellBooking.Persitence.EfRepositories;

public class EfApplicationUserRepository : IEfApplicationUserRepository
{
    private readonly HotelBookingDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public EfApplicationUserRepository(HotelBookingDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<ApplicationUser> Authenticate(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return null;
        }

        if (await _userManager.CheckPasswordAsync(user, password))
        {
            return user;
        }

        return null;
    }
    
    public async Task<bool> RegisterUser(ApplicationRegisterUserDto applicationUserDto)
    {
        var userExists = await _userManager.FindByEmailAsync(applicationUserDto.Email);
        if (userExists != null)
        {
            return false;
        }
        
        var user = new ApplicationUser
        {
            UserName = applicationUserDto.Email,
            Email = applicationUserDto.Email,
            FirstName = applicationUserDto.FirstName,
            LastName = applicationUserDto.LastName,
            Address = applicationUserDto.Address,
            ProfilePicture = applicationUserDto.ProfilePicture
        };

        var result = await _userManager.CreateAsync(user, applicationUserDto.PasswordHash);
        if (result.Succeeded)
        {
            return true;
        }

        return false;
    }
    
    public async Task<string> GetUserRoles(ApplicationUser dto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return string.Join(",", roles);
            }
            return "Cannot find user roles.";
        }
        catch (Exception ex)
        {
            // Handle exception (logging etc.)
            return null;
        }
    }
}