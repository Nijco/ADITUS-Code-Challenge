using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Dtos;


/// <summary>
/// The result of a hardware reservation request. 
/// Contains flags indicating success or specific failure reasons.
/// </summary>
public record HardwareReservationResultDto
{
    public HardwareReservationResultDto() { }

    /// <summary>
    /// Indicates if the reservation was successfully created.
    /// </summary>
    public bool Success => CreateHardwareReservation is not null;

    /// <summary>
    /// True if the request failed because the event date is too soon to fulfill the reservation.
    /// </summary>
    public bool EventNotFarEnoughInTheFuture { get; init; }

    /// <summary>
    /// True if the request failed because a reservation already exists for this event.
    /// </summary>
    public bool EventReservationAlreadyExists { get; init; }

    /// <summary>
    /// True if the request failed because the specified Event ID was not found.
    /// </summary>
    public bool EventNotFound { get; init; }

    /// <summary>
    /// The created hardware reservation details. 
    /// Null if the operation failed.
    /// </summary>
    public HardwareReservationDto? CreateHardwareReservation { get; init; }
}