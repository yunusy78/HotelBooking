namespace HotellBooking.Domain.DTOs.OrderDto;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int Adult { get; set; }
    public int Child { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public int  ReservationId  { get; set; }
}