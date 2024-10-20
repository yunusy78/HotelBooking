using Microsoft.AspNetCore.Identity;
namespace HotellBooking.Domain.Entities.Concrete;


public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePicture { get; set; }
    public string? Address { get; set; }
    
}