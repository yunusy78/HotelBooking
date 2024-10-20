namespace HotellBooking.Domain.Entities.Concrete;

public class Employee :ApplicationUser
{
    public string EmployeeCode { get; set; }
    public string Title { get; set; }
    
}