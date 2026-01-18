using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;

namespace ADITUS.CodeChallenge.API.Services
{
  public interface IEventService
  {
    Task<Event?> GetEvent(Guid id);
    Task<IList<Event>> GetEvents();
    Task<EventStatisticsDto?> GetEventStatistics(Guid id, EventType eventType);

  }
}