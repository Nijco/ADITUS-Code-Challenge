using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API;

/// <summary>
/// Provides endpoints for managing hardware reservations for events.
/// </summary>
[ApiController]
[Route("events/hardwareReservation")]
public class HardwareReservationsController : ControllerBase
{
  private readonly IHardwareReservationService _hardwareReservation;

  public HardwareReservationsController(IHardwareReservationService hardwareReservation)
  {
    _hardwareReservation = hardwareReservation;
  }

  /// <summary>
  /// Retrieves a hardware reservation by its Id.
  /// </summary>
  /// <param name="id">The Id of the hardware reservation.</param>
  /// <returns>The hardware reservation.</returns>
  /// <response code="200">The reservation was found.</response>
  /// <response code="400">The provided identifier is not a valid GUID.</response>
  /// <response code="404">The reservation was not found.</response>
  [HttpGet("{id}")]
  [ProducesResponseType(typeof(HardwareReservationDto), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult<HardwareReservationDto>> GetHardwareReservation(Guid id)
  {
    if (id == Guid.Empty)
    {
      return BadRequest(new { ErrorMessage = "The provided Id is not a valid Guid." });
    }

    var reservation = await _hardwareReservation.GetHardwareReservation(id);

    if (reservation is null)
    {
      return NotFound();
    }

    return Ok(reservation);
  }

  /// <summary>
  /// Creates a new hardware reservation for an event.
  /// </summary>
  /// <param name="reservationDto">The hardware reservation request.</param>
  /// <returns>The result of the reservation creation.</returns>
  /// <response code="200">The reservation was created successfully.</response>
  /// <response code="400">The request is invalid or the reservation could not be created.</response>
  /// <response code="404">The referenced event was not found.</response>
  [HttpPost("Create")]
  [ProducesResponseType(typeof(HardwareReservationResultDto), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(HardwareReservationResultDto), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(HardwareReservationResultDto), StatusCodes.Status404NotFound)]
  public async Task<ActionResult<HardwareReservationResultDto>> CreateHardwareReservation(
      [FromBody] HardwareReservationDto reservationDto)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var creationResult = await _hardwareReservation.CreateHardwareReservation(reservationDto);

    if (creationResult.EventNotFound)
    {
      return NotFound(creationResult);
    }

    if (!creationResult.Success)
    {
      return BadRequest(creationResult);
    }

    return Ok(creationResult);
  }

  /// <summary>
  /// Cancels an existing hardware reservation.
  /// </summary>
  /// <param name="id">The Id of the reservation to cancel.</param>
  /// <returns>An empty response if cancellation was successful.</returns>
  /// <response code="200">The reservation was cancelled successfully.</response>
  /// <response code="400">The provided identifier is not a valid GUID.</response>
  /// <response code="404">The reservation was not found.</response>reservation.</response>
  [HttpDelete("Cancel/{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> CancelHardwareReservation(Guid id)
  {
    if (id == Guid.Empty)
    {
      return BadRequest(new { ErrorMessage = "The provided Id is not a valid Guid." });
    }

    var cancelResult = await _hardwareReservation.CancelHardwareReservation(id);

    if (cancelResult is null)
    {
      return NotFound();
    }

    return Ok();
  }
}