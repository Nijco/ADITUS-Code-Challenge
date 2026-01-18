using System.ComponentModel.DataAnnotations;
using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Dtos;


/// <summary>
/// Represents a request to reserve hardware for a specific event.
/// </summary>
public record HardwareReservationDto
{
    public HardwareReservationDto() { }

    public HardwareReservationDto(HardwareReservation domainObj)
    {
        EventId = domainObj.EventId;
        TurnstileCount = domainObj.TurnstileCount;
        HandheldScannerCount = domainObj.HandheldScannerCount;
        MobileScanTerminalCount = domainObj.MobileScanTerminalCount;
    }

    /// <summary>
    /// The unique identifier of the event for which hardware is being reserved.
    /// </summary>
    [Required]
    public Guid EventId { get; init; }

    /// <summary>
    /// The number of physical turnstiles requested.
    /// </summary>
    public int TurnstileCount { get; init; }

    /// <summary>
    /// The number of handheld scanners requested.
    /// </summary>
    public int HandheldScannerCount { get; init; }

    /// <summary>
    /// The number of mobile scanning terminals requested.
    /// </summary>
    public int MobileScanTerminalCount { get; init; }
}