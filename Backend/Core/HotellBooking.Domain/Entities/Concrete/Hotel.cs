using System.Collections;
using Microsoft.VisualBasic;

namespace HotellBooking.Domain.Entities.Concrete;

public class Hotel
{
    
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
    public ICollection<Address> Addresses { get; set; }
    public ICollection<HotelImage> HotelImages { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<SocialMedia> SocialMedias { get; set; }
    public ICollection<Information> Informations { get; set; }
    
    
}