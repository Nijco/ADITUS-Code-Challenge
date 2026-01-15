# 💻 Full-Stack-Entwickler Code-Challenge

**Zielgruppe:** C#/.NET + Nuxt-Entwickler  
**Technologie:** C# .NET 8, Nuxt 4, TypeScript  
**Geschätzter Aufwand:** 6-12 Stunden

---

## 📋 Aufgabenübersicht

Du wirst die bestehende **REST-API um neue Funktionalitäten erweitern** und gleichzeitig ein modernes **Frontend-Dashboard mit Nuxt 4** entwickeln.

**Backend:** Das Projekt befindet sich bereits im Repository unter `src/`. Öffne die Solution `ADITUS.CodeChallenge.sln`

**Frontend:** Eine neue Nuxt 4-Anwendung soll von dir angelegt werden.

---

## 🔧 BACKEND-AUFGABEN

---

## 📝 Aufgabe 1: API-Endpunkte - Statistiken

Erweitere die API um Endpunkte für Veranstaltungs-Statistiken. Diese Endpunkte sollen Statistiken von externen Datenquellen abrufen:
- **Online-Statistiken:** `https://codechallenge-statistics.azurewebsites.net/api/online-statistics/:eventId`
- **OnSite-Statistiken:** `https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/:eventId`

*Hinweis: Diese Endpunkte benötigen eine gültige GUID als Event-ID.*

Die abzurufenden Statistiken sind abhängig vom Veranstaltungstyp:
- Für **Online-Events:** Rufe Online-Statistiken ab
- Für **OnSite-Events:** Rufe OnSite-Statistiken ab
- Für **Hybrid-Events:** Rufe beide Statistiken ab

---

## 📝 Aufgabe 2: API-Endpunkte - Hardware-Reservierung

Erweitere die API um Endpunkte für Hardware-Reservierungen. Verfügbare Hardware-Komponenten:
- Drehsperre
- Funkhandscanner
- Mobiles Scan-Terminal

**Funktionalitäten:**
- Eine neue Hardware-Reservierung für ein Event anlegen
- Eine bestehende Reservierung für ein Event abrufen
- Eine bestehende Reservierung stornieren/löschen

**Geschäftsregeln:**
- Reservierungen sind nur möglich, wenn das Event mindestens 4 Wochen in der Zukunft liegt
- Pro Event darf maximal eine aktive Reservierung bestehen
- Keine Reservierungen für vergangene Events

Die Datenpersistierung kann in-memory erfolgen.

---

## 📝 Aufgabe 3: API-Dokumentation

Stelle eine vollständige Dokumentation der API-Endpunkte bereit.

---

## 🎨 FRONTEND-AUFGABEN

---

## 📝 Aufgabe 4: Nuxt 4 Anwendung einrichten

Lege eine neue Nuxt 4 Anwendung an und konfiguriere sie für die Kommunikation mit der Backend-API.

---

## 📝 Aufgabe 5: Frontend - Veranstaltungsverwaltungs-Dashboard

Implementiere ein Dashboard mit folgenden Funktionen:

**Seite: Veranstaltungsliste**
- Liste aller Veranstaltungen
- Zeige Name, Jahr, Datum und Typ
- Filtermöglichkeit nach Veranstaltungstyp
- Anklickbare Einträge führen zur Detailansicht

**Seite: Veranstaltungsdetails**
- Alle Informationen zur Veranstaltung anzeigen
- Navigation zurück zur Liste

---

**Viel Erfolg! 🚀**