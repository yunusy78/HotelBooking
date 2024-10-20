namespace HotellBooking.Domain.Entities.Concrete;

public class Guest : ApplicationUser
{
    
    public int? Age { get; set; }
    
    public string? Nationality { get; set; }
    
}