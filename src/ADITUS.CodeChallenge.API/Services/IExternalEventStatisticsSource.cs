using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Dtos;

namespace ADITUS.CodeChallenge.API.Services;

public interface IExternalEventStatisticsSource
{
  Task<OnlineEventStatisticsDto?> GetOnlineEvent(Guid id);
  Task<OnSiteEventStatisticsDto?> GetOnSiteEvent(Guid id);
}
