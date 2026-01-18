using ADITUS.CodeChallenge.API.Dtos;

namespace ADITUS.CodeChallenge.API.Services;

public class ExternalEventStatisticsSource : IExternalEventStatisticsSource
{
    public record ExternalEventApiConfig(Uri BaseUrl, string OnlineSubRoute, string OnSiteSubRoute);

    public HttpClient _ExternalEventStatisticsApiClient;
    public ExternalEventApiConfig _externalEventApiConfig;
    public ExternalEventStatisticsSource(HttpClient extenalApiClient, ExternalEventApiConfig externalEventApiConfig)
    {
        _ExternalEventStatisticsApiClient = extenalApiClient;
        _externalEventApiConfig = externalEventApiConfig;
    }


    public async Task<OnlineEventStatisticsDto?> GetOnlineEvent(Guid id)
    {
        var subRout = _externalEventApiConfig.OnlineSubRoute;
        var stats = await _ExternalEventStatisticsApiClient.GetFromJsonAsync<OnlineEventStatisticsDto>($"{subRout}/{id}");
        return stats;
    }
    public async Task<OnSiteEventStatisticsDto?> GetOnSiteEvent(Guid id)
    {
        var subRout = _externalEventApiConfig.OnSiteSubRoute;
        var stats = await _ExternalEventStatisticsApiClient.GetFromJsonAsync<OnSiteEventStatisticsDto>($"{subRout}/{id}");
        return stats;
    }
}