<template>
    <h2>Event List</h2>
    <div class="table-wrapper">
        <table>
            <thead>
                <tr>
                    <th v-for="col in columns" :key="col">
                        {{ col }}
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="event in events" :key="event.id">
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
import { EventTypeEnum, type EventDto } from '~/models/EventDto';

// Minimal data generation for demo purposes
const columns = ['Name', 'Year', 'Date', 'Type']
const events: EventDto[] = Array.from({ length: 50 }, (_, i) => ({
    id: `${i + 1}`,
    name: `event ${i + 1}`,
    year: i + 2000,
    type: EventTypeEnum.Hybrid,
    EndDate: (new Date).toISOString(),
    StartDate: (new Date).toISOString(),
}))
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