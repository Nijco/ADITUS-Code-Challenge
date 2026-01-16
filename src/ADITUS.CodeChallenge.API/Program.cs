using System.Text.Json.Serialization;
using ADITUS.CodeChallenge.API.Services;
using static ADITUS.CodeChallenge.API.Services.ExternalEventSource;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

RegisterExternalEventSource(builder);

builder.Services.AddSingleton<IEventService, EventService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void RegisterExternalEventSource(WebApplicationBuilder builder)
{
    //Load config for external event API
    var externalEventApiUrlString = builder.Configuration["ExternalApi:BaseUrl"];
    var externalEventApiOnSiteSubRoute = builder.Configuration["ExternalApi:OnSiteSubRoute"];
    var externalEventApiOnlineSubRoute = builder.Configuration["ExternalApi:OnlineSubRoute"];
    if (string.IsNullOrWhiteSpace(externalEventApiUrlString) || string.IsNullOrWhiteSpace(externalEventApiOnSiteSubRoute) || string.IsNullOrWhiteSpace(externalEventApiOnlineSubRoute))
    {
        throw new InvalidOperationException("External API configuration missing.");
    }
    var externalApiConfig = new ExternalEventApiConfig(new Uri(externalEventApiUrlString), externalEventApiOnlineSubRoute, externalEventApiOnSiteSubRoute);
    builder.Services.AddSingleton(externalApiConfig);
    //Inject a httpclient for the configured address into ExternalEventSource into
    builder.Services.AddHttpClient<IExternalEventSource, ExternalEventSource>(client =>
    {
        client.BaseAddress = externalApiConfig.BaseUrl;
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });
}
