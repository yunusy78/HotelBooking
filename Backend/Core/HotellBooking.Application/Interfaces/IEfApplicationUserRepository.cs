using HotellBooking.Domain.DTOs.ApplicationUserDto;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace HotellBooking.Application.Interfaces;

public interface IEfApplicationUserRepository
{
    
    Task<ApplicationUser> Authenticate(string email, string password);

    Task<bool> RegisterUser(ApplicationRegisterUserDto applicationUserDto);
    
    Task<string> GetUserRoles(ApplicationUser user);

}