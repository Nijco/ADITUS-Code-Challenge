using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API;

[Route("events/hardwareReservation")]
public class HardwareReservationsController : ControllerBase
{
  private readonly IHardwareReservationService _hardwareReservation;

  public HardwareReservationsController( IHardwareReservationService hardwareReservation)
  {
    _hardwareReservation = hardwareReservation;
  }


  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> GetHardwareReservation(Guid id)
  {
    if (id.Version == 0)
    {
      return BadRequest(new { ErrorMessage = "the provided Id is not a valid Guid" });
    }
    var reservation = await _hardwareReservation.GetHardwareReservation(id);
    if (@reservation is null)
    {
      return NotFound();
    }

    return Ok(reservation);
  }

  [HttpPost]
  [Route("Create")]
  public async Task<IActionResult> CreateHardwareReservation([FromBody] HardwareReservationDto reservationDto)
  {
    if (ModelState.IsValid == false)
    {
      return BadRequest(ModelState);
    }
    var creationResult = await _hardwareReservation.CreateHardwareReservation(reservationDto);
    if (creationResult.EventNotFound)
    {
      return NotFound(creationResult);
    }
    else if (creationResult.Success == false)
    {
      return BadRequest(creationResult);
    }
    return Ok(creationResult);
  }

  [HttpDelete]
  [Route("Cancel/{id}")]
  public async Task<IActionResult> CancelHardwareReservation(Guid id)
  {
    if (id.Version == 0)
    {
      return BadRequest(new { ErrorMessage = "the provided Id is not a valid Guid" });
    }
    var cancelResult = await _hardwareReservation.CancelHardwareReservation(id);
    if (cancelResult is null)
    {
      return NotFound();
    }
    if (cancelResult == false)
      return StatusCode(500);

    return Ok();
  }
}