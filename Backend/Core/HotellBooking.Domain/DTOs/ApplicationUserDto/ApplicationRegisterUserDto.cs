namespace HotellBooking.Domain.DTOs.ApplicationUserDto;

public class ApplicationRegisterUserDto
{
    public string? Email { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string ProfilePicture { get; set; }
    public string? Address { get; set; }
    
    public string? ConfirmationToken { get; set; }
    
    public string? PasswordHash{ get; set; }
}