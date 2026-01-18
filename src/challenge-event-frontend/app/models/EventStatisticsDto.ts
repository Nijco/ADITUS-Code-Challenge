export interface OnSiteStatisticsDto {
    visitorsCount: number,
    exhibitorsCount: number,
    boothsCount: number,
}

export interface OnlineStatisticsDto {
    attendees: number,
    invites: number,
    visits: number,
    virtualRooms: number,
}

export interface EventStatisticsDto {
    onSiteEventStatistics: OnSiteStatisticsDto,
    onlineEventStatistics: OnlineStatisticsDto,
}