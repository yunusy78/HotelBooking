namespace HotellBooking.Domain.Entities.Concrete;

public class Address
{
    
    public int Id { get; set; }
    
    public string? AddressLine { get; set; }
    
    public string? City { get; set; }
    
    public string? Country { get; set; }
    
    public Hotel Hotel { get; set; }
    
    public int HotelId { get; set; }
    
    public string? PostalCode { get; set; }
    
    public string? Phone { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}