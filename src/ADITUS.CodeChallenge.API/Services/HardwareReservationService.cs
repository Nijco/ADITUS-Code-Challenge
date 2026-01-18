using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;
using ADITUS.CodeChallenge.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace ADITUS.CodeChallenge.API.Services;

public class HardwareReservationService : IHardwareReservationService
{
    private readonly IEventService _eventService;
    private readonly HardwareReservationDBContext _reservations;

    public HardwareReservationService(IEventService eventService, HardwareReservationDBContext hardwareReservationDB)
    {
        _eventService = eventService;
        _reservations = hardwareReservationDB;
    }

    public async Task<HardwareReservationDto?> GetHardwareReservation(Guid id)
    {
        var reservation = await _reservations.HardwareReservations.FindAsync(id);
        if (reservation is null)
            return null;
        return new HardwareReservationDto(reservation);
    }

    public async Task<HardwareReservationResultDto> CreateHardwareReservation(HardwareReservationDto dto)
    {
        var corospondingEvent = await _eventService.GetEvent(dto.EventId);
        if (corospondingEvent is null)
            return new HardwareReservationResultDto() { EventNotFound = true };

        if (await _reservations.HardwareReservations.FindAsync(dto.EventId) is not null)
            return new HardwareReservationResultDto { EventReservationAlreadyExists = true };

        // event must be at least 4 weeks in the future for a new reservation
        if (corospondingEvent.StartDate - DateTime.Now < TimeSpan.FromDays(28))
            return new HardwareReservationResultDto() { EventNotFarEnoughInTheFuture = true };

        var reservation = new HardwareReservation
        {
            EventId = corospondingEvent.Id,
            HandheldScannerCount = dto.HandheldScannerCount,
            MobileScanTerminalCount = dto.MobileScanTerminalCount,
            TurnstileCount = dto.TurnstileCount,
        };
        var theReservation = await _reservations.AddAsync(reservation);
        await _reservations.SaveChangesAsync();
        return new HardwareReservationResultDto()
        {
            CreateHardwareReservation = new HardwareReservationDto(theReservation.Entity)
        };
    }

    public async Task<bool?> CancelHardwareReservation(Guid id)
    {
        var reservation = await _reservations.HardwareReservations.FindAsync(id);
        if (reservation is null)
            return null;
        _reservations.HardwareReservations.Remove(reservation);
        await _reservations.SaveChangesAsync();
        return true;
    }

}
