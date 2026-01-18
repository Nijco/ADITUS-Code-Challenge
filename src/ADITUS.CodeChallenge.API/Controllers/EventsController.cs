using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API;

[Route("events")]
public class EventsController : ControllerBase
{
  private readonly IEventService _eventService;
  private readonly IHardwareReservationService _hardwareReservation;

  public EventsController(IEventService eventService, IHardwareReservationService hardwareReservation)
  {
    _eventService = eventService;
    _hardwareReservation = hardwareReservation;
  }

  [HttpGet]
  [Route("")]
  public async Task<IActionResult> GetEvents()
  {
    var events = await _eventService.GetEvents();
    return Ok(events);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> GetEvent(Guid id)
  {
    var @event = await _eventService.GetEvent(id);
    if (@event == null)
    {
      return NotFound();
    }

    return Ok(@event);
  }

  [HttpGet]
  [Route("Statistics/{eventType}/{id}")]
  public async Task<IActionResult> Statistics(Guid id, EventType eventType)
  {
    if (id.Version == 0)
    {
      return BadRequest(new { ErrorMessage = "Id is not a valid Guid" });
    }
    var @event = await _eventService.GetEventStatistics(id, eventType);
    if (@event == null)
    {
      return NotFound();
    }

    return Ok(@event);
  }
}