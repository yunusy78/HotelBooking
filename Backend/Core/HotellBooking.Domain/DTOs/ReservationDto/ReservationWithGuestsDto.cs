using HotellBooking.Domain.DTOs.GuestList;
using HotellBooking.Domain.Entities.Concrete;

namespace HotellBooking.Domain.DTOs.ReservationDto;

public class ReservationWithGuestsDto
{
    public CreateReservationDto Reservation { get; set; }
    public List<CreateGuestListDto> Guests { get; set; }
    
}