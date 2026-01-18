export interface EventDto {
    id: string,
    year: number,
    name: string,
    type: EventTypeEnum,
    startDate: string | null,
    endDate: string | null,
}

export enum EventTypeEnum {
    OnSite = "OnSite",
    Online = "Online",
    Hybrid = "Hybrid",
}