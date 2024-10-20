using AutoMapper;
using HotellBooking.Domain.DTOs.GuestList;
using HotellBooking.Domain.DTOs.HotelDto;
using HotellBooking.Domain.DTOs.ReservationDto;
using HotellBooking.Domain.DTOs.RoomDto;
using HotellBooking.Domain.DTOs.RoomStatusDto;
using HotellBooking.Domain.Entities.Concrete;

namespace HotellBooking.WebApi.Mapping;

public class ReservationMapProfile : Profile
{
    public ReservationMapProfile()
    {
        CreateMap<Reservation, CreateReservationDto>().ReverseMap();
        CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
        CreateMap<Reservation, GetResultReservationDto>().ReverseMap();
        CreateMap<Room,CreateRoomDto>().ReverseMap();
        CreateMap<Room,UpdateRoomDto>().ReverseMap();
        CreateMap<Room,GetResultRoomDto>().ReverseMap();

        CreateMap<GuestList, CreateGuestListDto>().ReverseMap();
        CreateMap<GuestList, UpdateGuestListDto>().ReverseMap();
        CreateMap<GuestList, GetResultGuestListDto>().ReverseMap();

        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        CreateMap<Hotel, GetResultHotelDto>().ReverseMap();

        CreateMap<RoomStatus, CreateRoomStatusDto>().ReverseMap();
        CreateMap<RoomStatus, UpdateRoomStatusDto>().ReverseMap();
        CreateMap<RoomStatus, GetResultRoomStatusDto>().ReverseMap();
    }
    
}