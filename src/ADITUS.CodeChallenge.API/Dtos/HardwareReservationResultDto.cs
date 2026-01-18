using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Dtos;


public class HardwareReservationResultDto
{

    public HardwareReservationResultDto() { }
    public bool Success => CreateHardwareReservation is not null;
    public bool EventNotFarEnoughInTheFuture { get; init; }
    public bool EventReservationAlreadyExists { get; init; }
    public bool EventNotFound { get; init; }
    public HardwareReservationDto? CreateHardwareReservation { get; init; }

}