namespace HotellBooking.Domain.Entities.Concrete;

public class Owner : ApplicationUser
{
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhone { get; set; }
    
}