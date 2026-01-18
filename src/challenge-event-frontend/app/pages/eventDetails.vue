<template>
    <div>
        <button @click="navigateTo('/')">Zurück zur Übersicht</button>
        <h2>Event Details - {{ eventData?.name }}</h2>
        <h3>Generell</h3>
        <table>
            <tr v-if="eventLoading">Event data loading</tr>
            <tr>
                <td>Id</td>
                <td>{{ eventData?.id }}</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>{{ eventData?.startDate ? formatDate(eventData.startDate, true) : '' }}</td>
            </tr>
            <tr>
                <td>Ende</td>
                <td>{{ eventData?.endDate ? formatDate(eventData.endDate, true) : '' }}</td>
            </tr>
            <tr>
                <td>Jahr</td>
                <td>{{ eventData?.year }}</td>
            </tr>
            <tr>
                <td>Event Typ</td>
                <td>{{ eventData?.type }}</td>
            </tr>
        </table>
    </div>
    <h3>Statistik</h3>
    <div v-if="eventStatisticsData?.onSiteEventStatistics">
        <h4>Vorort</h4>
        <table>
            <tr v-if="eventStatisticsLoading">Event data loading</tr>
            <tr>
                <td>Besucherzahl</td>
                <td>{{ eventStatisticsData?.onSiteEventStatistics.visitorsCount }}</td>
            </tr>
            <tr>
                <td>Aussteleranzahl</td>
                <td>{{ eventStatisticsData?.onSiteEventStatistics.exhibitorsCount }}</td>
            </tr>
            <tr>
                <td>Anzahl an Ständen</td>
                <td>{{ eventStatisticsData?.onSiteEventStatistics.boothsCount }}</td>
            </tr>
        </table>
    </div>

    <div v-if="eventStatisticsData?.onlineEventStatistics">
        <h4>Online</h4>
        <table>
            <tr v-if="eventStatisticsLoading">Event data loading</tr>
            <tr>
                <td>Teilnehmer</td>
                <td>{{ eventStatisticsData?.onlineEventStatistics.attendees }}</td>
            </tr>
            <tr>
                <td>Versendete Einladungen</td>
                <td>{{ eventStatisticsData?.onlineEventStatistics.invites }}</td>
            </tr>
            <tr>
                <td>Virtuelle Räume</td>
                <td>{{ eventStatisticsData?.onlineEventStatistics.virtualRooms }}</td>
            </tr>
            <tr>
                <td>Seitenaufrufe</td>
                <td>{{ eventStatisticsData?.onlineEventStatistics.visits }}</td>
            </tr>
        </table>
    </div>
</template>

<script setup lang="ts">
import { useApi } from '~/composeable/useApi';
import type { EventDto } from '~/models/EventDto';
import type { EventStatisticsDto } from '~/models/EventStatisticsDto';

const route = useRoute();

let eventLoading = ref(false);
let eventStatisticsLoading = ref(false);
let eventData = ref<EventDto | null>(null);
let eventStatisticsData = ref<EventStatisticsDto | null>(null);

// Access the parameter via route.params
const eventId = ref<string>("");
onMounted(() => {
    if (typeof (route.query.id) == "string" && route.query.id.length > 1) {
        eventId.value = route.query.id;
        loadEventDetails(eventId.value);
    }
})


async function loadEventDetails(id: string) {
    try {
        eventLoading.value = true;
        const event = await useApi<EventDto>(`/events/${id}`, {
            method: 'GET',
        });
        eventData.value = event;
    } finally {
        eventLoading.value = false;
    }
    if (eventData) {
        try {
            eventStatisticsLoading.value = true;
            const eventStatistics = await useApi<EventStatisticsDto>(`Events/Statistics/${eventData.value.type}/${id}`, {
                method: 'GET',
            });
            eventStatisticsData.value = eventStatistics;
        } finally {
            eventStatisticsLoading.value = false;
        }
    }
}

</script>

<style scoped lang="scss">
table {
    width: 100%;
    border-collapse: collapse;

    td {
        padding: 10px;
        border-bottom: 1px solid #eee;
    }
}

button {
    background-color: white;
    border: none;
    color: black;
    padding: 6px 6px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    transition-duration: 0.4s;
    cursor: pointer;
    border: 2px solid black;
}
</style>