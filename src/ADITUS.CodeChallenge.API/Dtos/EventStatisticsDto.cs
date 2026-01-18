namespace ADITUS.CodeChallenge.API.Dtos;
/// <summary>
/// Contains statistics specific to physical, in-person events.
/// </summary>
public record OnSiteEventStatisticsDto
{
    /// <summary>
    /// The total number visitors physically present at the event.
    /// </summary>
    public int VisitorsCount { get; init; }

    /// <summary>
    /// The number of entities exhibiting at the event.
    /// </summary>
    public int ExhibitorsCount { get; init; }

    /// <summary>
    /// The total count of physical booths set up at the venue.
    /// </summary>
    public int BoothsCount { get; init; }
}

/// <summary>
/// Contains statistics specific to virtual or online events.
/// </summary>
public record OnlineEventStatisticsDto
{
    /// <summary>
    /// The number of users who attended the online event.
    /// </summary>
    public int Attendees { get; init; }

    /// <summary>
    /// The total number of invitations sent out for the event.
    /// </summary>
    public int Invites { get; init; }

    /// <summary>
    /// The total number of page visits
    /// </summary>
    public int Visits { get; init; }

    /// <summary>
    /// The number of virtual rooms
    /// </summary>
    public int VirtualRooms { get; init; }
}

/// <summary>
/// A container for event statistics. Depending on the event type, 
/// one or both of the nested statistics objects may be present.
/// </summary>
public record EventStatisticsDto
{
    /// <summary>
    /// Statistics for the physical portion of the event. 
    /// Null if the event is purely virtual.
    /// </summary>
    public OnSiteEventStatisticsDto? OnSiteEventStatistics { get; init; }

    /// <summary>
    /// Statistics for the virtual portion of the event. 
    /// Null if the event is purely on-site.
    /// </summary>
    public OnlineEventStatisticsDto? OnlineEventStatistics { get; init; }
}