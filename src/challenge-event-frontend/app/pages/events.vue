<template>
    <div class="header">
        <h2>Event List</h2>
        <div class="filter-container">
            <label for="role-select">Filter by event type:</label>

            <select id="role-select" v-model="selectedEventTypeFilter">
                <option v-for="option in eventtypeFilterOptions" :key="option.value" :value="option.value">
                    {{ option.label }}
                </option>
            </select>
            {{ selectedEventTypeFilter }}
        </div>
    </div>
    <div class="table-wrapper">
        <p v-if="eventsLoading">Events Loading ...</p>
        <table v-if="eventsLoading == false">
            <thead>
                <tr>
                    <th v-for="col in columns" :key="col">
                        {{ col }}
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="event in filteredEvents" :key="event.id">
                    <td>{{ event.name }}</td>
                    <td>{{ event.year }}</td>
                    <td>{{ formatDate(event.startDate!) }}</td>
                    <td>{{ event.type }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup lang="ts">
import { useApi as useApi } from '~/composeable/useApi';
import { EventTypeEnum, type EventDto } from '~/models/EventDto';

let eventsLoading = ref(false);
let eventsList = ref<EventDto[]>([]);

const columns = ['Name', 'Year', 'Date', 'Type'];

onMounted(() => {
    fetchEvents();
})

async function fetchEvents() {
    eventsLoading.value = true;
    try {
        const events = await useApi<EventDto[]>('/events', {
            method: 'GET',
        });
        eventsList.value = events;
    } finally {
        eventsLoading.value = false;
    }
}

function formatDate(dateString: string, locale: string = 'de-DE'): string {
    let date: Date;
    if (typeof (dateString) !== 'string') {
        return '';
    }
    date = new Date(dateString);

    return new Intl.DateTimeFormat(locale, {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
    }).format(date);
}

const selectedEventTypeFilter = ref<EventTypeEnum | ''>('')

const eventtypeFilterOptions = computed(() => {
    const all = { label: `_`, value: '' }
    const items = Object.keys(EventTypeEnum)
        .filter(key => isNaN(Number(key)))
        .map(key => ({
            label: key,
            value: EventTypeEnum[key as keyof typeof EventTypeEnum]
        }))

    return [all, ...items]
})

const filteredEvents = computed(() => {
    if (!selectedEventTypeFilter.value) {
        return eventsList.value;
    }

    console.log(eventsList.value[0]!.type);
    console.log(Number(eventsList.value[0]!.type));
    console.log(selectedEventTypeFilter.value);

    return eventsList.value
        .filter(e => e.type == selectedEventTypeFilter.value);
})
</script>

<style lang="scss" scoped>
.table-wrapper {
    height: 300px;
    overflow-y: auto;
    border: 1px solid #ddd;
    flex-grow: 1;

    table {
        width: 100%;
        border-collapse: collapse;

        th {
            position: sticky;
            top: 0;
            background: #333;
            color: white;
            z-index: 1;

            padding: 10px;
            text-align: left;
        }

        td {
            padding: 10px;
            border-bottom: 1px solid #eee;
        }
    }
}
</style>