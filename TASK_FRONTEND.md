# 💻 Frontend-Entwickler Code-Challenge

**Zielgruppe:** Nuxt-Entwickler  
**Technologie:** Nuxt 4, TypeScript  
**Geschätzter Aufwand:** 6-12 Stunden

---

## 📋 Vorbereitungen

### Backend-API lokal ausführen

Die Backend-API wird benötigt, um die Frontend-Anwendung zu testen. Folge diesen Schritten:

1. **Öffne das Projekt in VS Code oder Visual Studio**
   - Navigiere zum Verzeichnis `src/`
   - Öffne die Datei `ADITUS.CodeChallenge.sln`

2. **Starte die API**
   - In VS Code: Öffne ein Terminal und führe aus: `dotnet run` im Verzeichnis `src/ADITUS.CodeChallenge.API/`
   - In Visual Studio: Wähle das Projekt `ADITUS.CodeChallenge.API` aus und starte es (F5 oder Ctrl+F5)

3. **Verifiziere, dass die API läuft**
   - Öffne deinen Browser und navigiere zu `https://localhost:5001/api/events/`
   - Du solltest eine JSON-Antwort mit einer Liste von Veranstaltungen sehen

4. **Notiere die API-URL**
   - Die lokale API läuft unter `https://localhost:5001`
   - Nutze diese URL später in deiner Nuxt-Anwendung für die API-Konfiguration

---

## 📋 Aufgabenübersicht

Du wirst ein **Veranstaltungsverwaltungs-Dashboard mit Nuxt 4** implementieren. Die Backend-API für Veranstaltungen ist bereits vorhanden. Du wirst diese mit modernem Frontend umsetzen und zusätzliche externe Datenquellen integrieren.

---

## 📝 Aufgabe 1: Nuxt 4 Anwendung einrichten

Lege eine neue Nuxt 4 Anwendung an und konfiguriere sie für die Kommunikation mit der Backend-API.

---

## 📝 Aufgabe 2: Veranstaltungsliste

Implementiere eine Seite, die alle Veranstaltungen auflistet. Nutze die API: `GET /api/events/`

Folgende Informationen sollen angezeigt werden:
- Name
- Jahr
- Start- und Enddatum
- Typ (OnSite, Online, Hybrid)

Jede Veranstaltung soll anklickbar zur Detailansicht führen. Implementiere zudem eine Filtermöglichkeit nach Veranstaltungstyp.

---

## 📝 Aufgabe 3: Veranstaltungs-Detailansicht

Implementiere eine Detailseite für eine einzelne Veranstaltung. Nutze die API: `GET /api/events/{id}`

Zeige alle verfügbaren Informationen an. Implementiere eine Navigation zurück zur Liste.

---

## 📝 Aufgabe 4: Statistiken von externen Datenquellen

Integriere Statistiken aus externen Datenquellen direkt im Frontend. Die folgenden Endpunkte stellen Statistiken bereit:

- **Online-Statistiken:** `https://codechallenge-statistics.azurewebsites.net/api/online-statistics/:eventId`
- **OnSite-Statistiken:** `https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/:eventId`

*Hinweis: Diese Endpunkte benötigen eine gültige GUID als Event-ID.*

Erweitere die Detailansicht um die Darstellung von Statistiken basierend auf dem Veranstaltungstyp:
- Für **Online-Events:** Rufe Online-Statistiken ab und zeige diese an
- Für **OnSite-Events:** Rufe OnSite-Statistiken ab und zeige diese an
- Für **Hybrid-Events:** Rufe beide Statistiken ab und kombiniere diese sinnvoll in der Anzeige

---

## 📝 Aufgabe 5: Verwaltung von Veranstaltungen (Mock-Daten)

Implementiere eine Funktionalität zur Erstellung und Bearbeitung von Veranstaltungen. Da diese Funktionalität nicht über die API verfügbar ist, arbeite mit lokalen Mock-Daten.

**Funktionalitäten:**
- Formular / Prozess zur Erstellung einer neuen Veranstaltung
- Bearbeitung einer bestehenden Veranstaltung
- Löschung einer Veranstaltung

**Persistierung:**
- Die lokal erstellten und bearbeiteten Veranstaltungen sollen im lokalen Speicher des Browsers (z.B. localStorage oder Pinia Store) persistiert werden

---

**Viel Erfolg! 🚀**
