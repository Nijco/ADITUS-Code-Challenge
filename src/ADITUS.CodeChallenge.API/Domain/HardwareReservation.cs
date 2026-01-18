namespace ADITUS.CodeChallenge.API.Domain
{
    public class HardwareReservation
    {
        public Guid EventId { get; init; }
        public int TurnstileCount { get; init; }
        public int HandheldScannerCount { get; init; }
        public int MobileScanTerminalCount { get; init; }
    }
}