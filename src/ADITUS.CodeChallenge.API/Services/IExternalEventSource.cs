using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services;

public interface IExternalEventSource
{
  Task<Event> GetEvent(Guid id, ExternalEventType externalEventType);
}
