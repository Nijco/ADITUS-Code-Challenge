using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API;

/// <summary>
/// Provides access to event data and statistics.
/// </summary>
[ApiController]
[Route("events")]
public class EventsController : ControllerBase
{

  private readonly IEventService _eventService;

  public EventsController(IEventService eventService)
  {
    _eventService = eventService;
  }

  /// <summary>
  /// Retrieves all available events.
  /// </summary>
  /// <returns>A list of events.</returns>
  /// <response code="200">Events were successfully retrieved.</response>
  [HttpGet]
  [ProducesResponseType(typeof(IList<Event>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetEvents()
  {
    var events = await _eventService.GetEvents();
    return Ok(events);
  }

  /// <summary>
  /// Retrieves a specific event by Id.
  /// </summary>
  /// <param name="id">The Id of the event.</param>
  /// <returns>The requested event.</returns>
  /// <response code="200">Event was found.</response>
  /// <response code="404">Event was not found.</response>
  [HttpGet("{id}")]
  [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetEvent(Guid id)
  {
    var @event = await _eventService.GetEvent(id);
    if (@event == null)
    {
      return NotFound();
    }

    return Ok(@event);
  }

  /// <summary>
  /// Retrieves statistics for a specific event and event type.
  /// </summary>
  /// <param name="id">The Id of the event.</param>
  /// <param name="eventType">The type of event.</param>
  /// <returns>Statistical information for the event.</returns>
  /// <response code="200">Statistics were retrieved successfully.</response>
  /// <response code="400">The provided event id is invalid.</response>
  /// <response code="404">Statistics were not found.</response>
  [HttpGet("Statistics/{eventType}/{id}")]
  [ProducesResponseType(typeof(EventStatisticsDto), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Statistics(Guid id, EventType eventType)
  {
    if (id == Guid.Empty)
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