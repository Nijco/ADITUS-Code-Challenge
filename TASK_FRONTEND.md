# 💻 Frontend Developer Code-Challenge

**Target Audience:** Nuxt Developers  
**Technology:** Nuxt 4, TypeScript  
**Estimated Effort:** 6-12 hours

---

## 📋 Preparation

### Running the Backend API Locally

The backend API is required to test the frontend application. Follow these steps:

1. **Open the project in VS Code or Visual Studio**
   - Navigate to the `src/` directory
   - Open the file `ADITUS.CodeChallenge.sln`

2. **Start the API**
   - In VS Code: Open a terminal and run: `dotnet run` in the `src/ADITUS.CodeChallenge.API/` directory
   - In Visual Studio: Select the `ADITUS.CodeChallenge.API` project and run it (F5 or Ctrl+F5)

3. **Verify that the API is running**
   - Open your browser and navigate to `https://localhost:5001/api/events/`
   - You should see a JSON response with a list of events

4. **Note the API URL**
   - The local API runs at `https://localhost:5001`
   - Use this URL later in your Nuxt application for API configuration

---

## 📋 Task Overview

You will implement an **Event Management Dashboard with Nuxt 4**. The backend API for events is already available. You will implement this with a modern frontend and integrate additional external data sources.

---

## 📝 Task 1: Set Up Nuxt 4 Application

Create a new Nuxt 4 application and configure it for communication with the backend API.

---

## 📝 Task 2: Event List

Implement a page that lists all events. Use the API: `GET /api/events/`

The following information should be displayed:
- Name
- Year
- Start and end date
- Type (OnSite, Online, Hybrid)

Each event should be clickable to navigate to the detail view. Also implement a filter by event type.

---

## 📝 Task 3: Event Detail View

Implement a detail page for a single event. Use the API: `GET /api/events/{id}`

Display all available information. Implement navigation back to the list.

---

## 📝 Task 4: Statistics from External Data Sources

Integrate statistics from external data sources directly in the frontend. The following endpoints provide statistics:

- **Online Statistics:** `https://codechallenge-statistics.azurewebsites.net/api/online-statistics/:eventId`
- **OnSite Statistics:** `https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/:eventId`

*Note: These endpoints require a valid GUID as the event ID.*

Extend the detail view with statistics display based on event type:
- For **Online Events:** Fetch and display online statistics
- For **OnSite Events:** Fetch and display onsite statistics
- For **Hybrid Events:** Fetch both statistics and combine them meaningfully in the display

---

## 📝 Task 5: Event Management (Mock Data)

Implement functionality for creating and editing events. Since this functionality is not available via the API, work with local mock data.

**Features:**
- Form / process for creating a new event
- Editing an existing event
- Deleting an event

**Persistence:**
- Locally created and edited events should be persisted in the browser's local storage (e.g., localStorage or Pinia store)

---

**Good luck! 🚀**
