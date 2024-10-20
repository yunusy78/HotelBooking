namespace HotellBooking.Domain.Entities.Concrete;

public class SocialMedia
{
    
    public int Id { get; set; }
    
    public string? Url { get; set; }
    
    public string? Icon { get; set; }
    
    public string? Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsActive { get; set; }
    
}