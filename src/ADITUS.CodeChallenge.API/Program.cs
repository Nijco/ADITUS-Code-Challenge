using System.Text.Json.Serialization;
using ADITUS.CodeChallenge.API.Persistence;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.EntityFrameworkCore;
using static ADITUS.CodeChallenge.API.Services.ExternalEventStatisticsSource;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

RegisterExternalEventSourceInjections(builder);

builder.Services.AddDbContext<HardwareReservationDBContext>(options =>
    options.UseInMemoryDatabase("ReservationDb"));

builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddScoped<IHardwareReservationService, HardwareReservationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterExternalEventSourceInjections(WebApplicationBuilder builder)
{
    //Load config for external event API
    var externalEventApiUrlString = builder.Configuration["ExternalEventStatisticsApi:BaseUrl"];
    var externalEventApiOnSiteSubRoute = builder.Configuration["ExternalEventStatisticsApi:OnSiteSubRoute"];
    var externalEventApiOnlineSubRoute = builder.Configuration["ExternalEventStatisticsApi:OnlineSubRoute"];
    if (string.IsNullOrWhiteSpace(externalEventApiUrlString) || string.IsNullOrWhiteSpace(externalEventApiOnSiteSubRoute) || string.IsNullOrWhiteSpace(externalEventApiOnlineSubRoute))
    {
        throw new InvalidOperationException("External API configuration missing.");
    }
    var ExternalEventStatisticsApiConfig = new ExternalEventApiConfig(new Uri(externalEventApiUrlString), externalEventApiOnlineSubRoute, externalEventApiOnSiteSubRoute);
    builder.Services.AddSingleton(ExternalEventStatisticsApiConfig);
    //Inject a httpclient for the configured address into ExternalEventSource into
    builder.Services.AddHttpClient<IExternalEventStatisticsSource, ExternalEventStatisticsSource>(client =>
    {
        client.BaseAddress = ExternalEventStatisticsApiConfig.BaseUrl;
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });
}
