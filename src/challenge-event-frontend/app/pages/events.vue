<template>
    <h2>Event List</h2>
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
                <tr v-for="event in eventsList" :key="event.id">
                    <td>{{ event.id }}</td>
                    <td>{{ event.name }}</td>
                    <td>{{ event.StartDate }}</td>
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