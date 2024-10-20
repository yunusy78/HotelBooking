namespace HotellBooking.Domain.DTOs.ApplicationUserDto;

public class RegisterUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string ProfilePicture { get; set; }
    public string? Address { get; set; }
    
    public string? Email { get; set; }
        
    public string? PhoneNumber { get; set; }
        
    public string Password { get; set; }
    
}