using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services;

public class ExternalEventSource : IExternalEventSource
{
    public record ExternalEventApiConfig(Uri BaseUrl, string OnlineSubRoute, string OnSiteSubRoute);

    public HttpClient _externalApiClient;
    public ExternalEventApiConfig _externalEventApiConfig;
    public ExternalEventSource(HttpClient extenalApiClient, ExternalEventApiConfig externalEventApiConfig)
    {
        _externalApiClient = extenalApiClient;
        _externalEventApiConfig = externalEventApiConfig;
    }

    public Task<Event> GetEvent(Guid id, ExternalEventType externalEventType)
    {
        var subRout = externalEventType switch
        {
            ExternalEventType.Online => _externalEventApiConfig.OnlineSubRoute,
            ExternalEventType.OnSite => _externalEventApiConfig.OnSiteSubRoute,
        };
        return _externalApiClient.GetFromJsonAsync<Event>($"{subRout}/{id}");
    }

}