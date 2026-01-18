namespace ADITUS.CodeChallenge.API.Dtos;

public record OnSiteEventStatisticsDto
{
    public int VisitorsCount { get; init; }
    public int ExhibitorsCount { get; init; }
    public int BoothsCount { get; init; }
}

public record OnlineEventStatisticsDto
{
    public int Attendees { get; init; }
    public int Invites { get; init; }
    public int Visits { get; init; }
    public int VirtualRooms { get; init; }
}

public record EventStatisticsDto
{

    public OnSiteEventStatisticsDto? OnSiteEventStatistics { get; init; }
    public OnlineEventStatisticsDto? OnlineEventStatistics { get; init; }
}
