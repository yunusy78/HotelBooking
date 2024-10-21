using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.GuestList;
using HotellBooking.Domain.DTOs.ReservationDto;
using HotellBooking.Domain.Entities.Abstract;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotellBooking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    
    public ReservationController(IEfReservationRepository reservationService, IEfRoomStatusRepository roomStatusService, IEfGuestListRepository guestListService, IMapper mapper)
    {
        _reservationService = reservationService;
        _roomStatusService = roomStatusService;
        _guestListService = guestListService;
        _mapper = mapper;
    }

    private readonly IEfReservationRepository _reservationService;
    private readonly IEfRoomStatusRepository _roomStatusService;
    private readonly IEfGuestListRepository _guestListService;
    private readonly IMapper _mapper;


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var reservations = await _reservationService.GetReservationWithRoomAndStatusAndPricingAsync();
        
        var mapperReservations = _mapper.Map<List<GetResultReservationDto>>(reservations);
        return Ok(mapperReservations);
    }
    
    [HttpGet("GetRoomWithName/{hotelId}/{roomName}")]
    public async Task<IActionResult> GetRoomWithName(int hotelId, string roomName)
    {
       
        var reservation = await _reservationService.GetReservationWithRoomAndStatusAndPricingByIdAsync(hotelId, roomName);
        var mappedRoom = _mapper.Map<List<GetResultReservationDto>>(reservation);
        return Ok(mappedRoom);
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        return Ok(reservation);
    }

    
    [HttpPost]
    public async Task<ActionResult<GetResultReservationDto>> Post(ReservationWithGuestsDto dto)
    {
        var roomStatus = await _roomStatusService.StatsCheckAsync(dto.Reservation.RoomId, dto.Reservation.CheckIn, dto.Reservation.CheckOut);
        if (roomStatus == false)
        {
            return BadRequest("Room is not available for this period");
        }
        
        
        var mappedReservation = _mapper.Map<Reservation>(dto.Reservation);
        var newReservation = await _reservationService.CreateReservationAsync(mappedReservation);
        
        var mappedGuests = _mapper.Map<List<GuestList>>(dto.Guests);
        
        foreach (var guest in mappedGuests)
        {
            guest.ReservationId = newReservation.Id;
            await _guestListService.AddAsync(guest);
        }
        
        DateTime currentDate = newReservation.CheckIn;
        DateTime endDate = newReservation.CheckOut;
        
        while (currentDate < endDate)
        {
            await _roomStatusService.AddAsync(new RoomStatus()
            {
                RoomId = newReservation.RoomId,
                Date = currentDate,
                Status = RoomStatusEnum.Reserved
            });
            currentDate = currentDate.AddDays(1);
        }
        
        var getResultReservationDto = _mapper.Map<GetResultReservationDto>(newReservation);
        
        return Ok(getResultReservationDto);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateReservationDto reservation)
    {
        var roomStatus = await _roomStatusService.StatsCheckAsync(reservation.RoomId, reservation.CheckIn, reservation.CheckOut);
        if (roomStatus == false)
        {
            return BadRequest("Room is not available for this period");
        }
        
        var mappedReservation = _mapper.Map<Reservation>(reservation);
        var updatedReservation = await _reservationService.UpdateAsync(mappedReservation);
        return Ok(updatedReservation);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        await _reservationService.DeleteAsync(reservation);
        return Ok();
    }
}