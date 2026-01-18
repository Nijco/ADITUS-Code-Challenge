export interface EventDto {
    id: string,
    year: number,
    name: string,
    type: EventTypeEnum,
    StartDate: string | null,
    EndDate: string | null,
}

export enum EventTypeEnum {
    OnSite = 1,
    Online = 2,
    Hybrid = 3,
}