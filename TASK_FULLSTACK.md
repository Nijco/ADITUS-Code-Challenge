# 💻 Full-Stack Developer Code-Challenge

**Target Audience:** C#/.NET + Nuxt Developers  
**Technology:** C# .NET 8, Nuxt 4, TypeScript  
**Estimated Effort:** 6-12 hours

---

## 📋 Task Overview

You will **extend the existing REST-API with new functionality** and simultaneously **develop a modern Frontend Dashboard with Nuxt 4**.

**Backend:** The project is already located in the repository under `src/`. Open the solution file `ADITUS.CodeChallenge.sln`

**Frontend:** A new Nuxt 4 application should be created by you.

---

## 🔧 BACKEND TASKS

---

## 📝 Task 1: API Endpoints - Statistics

Extend the API with endpoints for event statistics. These endpoints should fetch statistics from external data sources:
- **Online Statistics:** `https://codechallenge-statistics.azurewebsites.net/api/online-statistics/:eventId`
- **OnSite Statistics:** `https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/:eventId`

*Note: These endpoints require a valid GUID as the event ID.*

The statistics to be fetched depend on the event type:
- For **Online Events:** Fetch online statistics
- For **OnSite Events:** Fetch onsite statistics
- For **Hybrid Events:** Fetch both statistics

---

## 📝 Task 2: API Endpoints - Hardware Reservation

Extend the API with endpoints for hardware reservations. Available hardware components:
- Turnstile
- Handheld scanner
- Mobile scan terminal

**Features:**
- Create a new hardware reservation for an event
- Retrieve an existing reservation for an event
- Cancel/delete an existing reservation

**Business Rules:**
- Reservations are only possible if the event is at least 4 weeks in the future
- Only one active reservation per event is allowed
- No reservations for past events

Data persistence can be done in-memory.

---

## 📝 Task 3: API Documentation

Provide complete documentation of the API endpoints.

---

## 🎨 FRONTEND TASKS

---

## 📝 Task 4: Set Up Nuxt 4 Application

Create a new Nuxt 4 application and configure it for communication with the backend API.

---

## 📝 Task 5: Frontend - Event Management Dashboard

Implement a dashboard with the following functions:

**Page: Event List**
- List all events
- Show name, year, date and type
- Filter option by event type
- Clickable entries lead to the detail view

**Page: Event Details**
- Display all information about the event
- Navigation back to the list

---

**Good luck! 🚀**