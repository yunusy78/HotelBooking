using FluentValidation;
using HotellBooking.Domain.DTOs.ReservationDto;

namespace HotellBooking.Application.Services.Validations;

public class CreateReservationValidator : AbstractValidator<CreateReservationDto>
{
    
    public CreateReservationValidator()
    {
        RuleFor(x => x.RoomId).NotEmpty();
        RuleFor(x => x.CheckIn).NotEmpty();
        RuleFor(x => x.CheckOut).NotEmpty();
        RuleFor(x => x.AdultCount).NotEmpty();
        RuleFor(x => x.ChildCount).NotEmpty();
        RuleFor(x => x.Baby).NotEmpty();
    }
    
}