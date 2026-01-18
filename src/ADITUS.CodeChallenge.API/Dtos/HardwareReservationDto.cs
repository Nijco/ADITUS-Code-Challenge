using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Dtos;


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
    public Guid EventId { get; init; }
    public int TurnstileCount { get; init; }
    public int HandheldScannerCount { get; init; }
    public int MobileScanTerminalCount { get; init; }

}