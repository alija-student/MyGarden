# Projektauftrag

## 1. Projekttitel

**MyGarden – Digitaler Gartenplaner**

---

## 2. Projektorganisation und Team

Für die Umsetzung des Schulprojekts werden die folgenden Rollen und Zuständigkeiten definiert:

### 2.1 Projektleitung
* **Projektleiter/in:** [Albin Kraml]
  * Hauptverantwortlich für die Meilensteinplanung und Koordination.
  * Zentraler Ansprechpartner für den Auftraggeber (Albin Kraml).

### 2.2 Entwicklungsteam
* **Frontend-Entwickler/in (Angular & Konva.js):** [Albin Kraml, Saif Abdulqader]
  * Zuständig für die grafische Oberfläche, Zeichenfunktionen und API-Anbindung.
* **Backend-Entwickler/in (C# / ASP.NET Core):** [Alija Bickalo, Saif Abdulqader]
  * Zuständig für die Geschäftslogik, Flächenberechnung und Bereitstellung der REST-API.
* **Datenbank-Spezialist/in (PostgreSQL):** [Alija Bickalo, Albin Kraml]
  * Zuständig für das Datenmodell, Entwurf der Tabellen und versionierte Migrationen.

### 2.3 Stakeholder / Auftraggeber
* **Auftraggeber:** [David Klewein / HTL Leonding]
  * Verantwortlich für die Projektabnahme und Bewertung.

## 3. Projektbeschreibung

MyGarden ist eine webbasierte Fullstack-Anwendung zur digitalen Planung und Gestaltung von Gärten.

Benutzer sollen ein Grundstück beziehungsweise eine Grundstücksfläche digital abbilden und darauf verschiedene Gartenbereiche wie Rasenflächen, Wege, Terrassen, Beete oder Teiche einzeichnen können. Zusätzlich sollen Pflanzen und weitere Gartenelemente auf dem Gartenplan platziert werden können.

Die Anwendung soll die gezeichneten Flächen auswerten und beispielsweise deren Größe berechnen. Gartenpläne und die darin enthaltenen Elemente sollen dauerhaft gespeichert und später wieder geladen und bearbeitet werden können.

Die grafische Darstellung und Bearbeitung des Gartenplans erfolgt im Browser. Die Anwendung wird als Fullstack-System umgesetzt und besteht aus einem Frontend, einem Backend sowie einer relationalen Datenbank.

---

## 4. Ausgangssituation

Die Planung eines Gartens erfolgt häufig mit Papierplänen, einfachen Zeichenprogrammen oder nicht auf die Gartenplanung spezialisierten Anwendungen.

Dabei müssen Grundstücksflächen, Gartenbereiche und geplante Pflanzen häufig getrennt dokumentiert werden. Eine automatische Flächenberechnung und strukturierte Speicherung der Planung sind dabei nur eingeschränkt möglich.

MyGarden soll diese Aufgaben in einer gemeinsamen Anwendung abbilden.

---

## 5. Projektziel

Ziel des Projekts ist die Entwicklung einer funktionsfähigen Webanwendung, mit der Benutzer einen Garten digital planen können.

Das System soll insbesondere ermöglichen:

- ein Grundstück anzulegen
- die Grundstücksfläche grafisch darzustellen
- Gartenflächen auf dem Grundstück zu zeichnen
- unterschiedliche Flächentypen zu definieren
- Pflanzen und weitere Gartenelemente zu platzieren
- Elemente zu verschieben und zu bearbeiten
- Flächen automatisch zu berechnen
- identische Objekte zu zählen
- einen Gartenplan dauerhaft zu speichern
- einen gespeicherten Gartenplan wieder zu laden
- einen bestehenden Gartenplan zu bearbeiten

Die Anwendung soll dabei eine klare Trennung zwischen Benutzeroberfläche, Geschäftslogik und Datenhaltung aufweisen.

---

## 6. Projektumfang

### 6.1 Grundstück

Der Benutzer kann ein Grundstück als Grundlage für seinen Gartenplan erstellen.

Das Grundstück wird als Polygon dargestellt und bildet die Begrenzung des zu planenden Bereichs.

Mögliche Funktionen:

- Grundstück erstellen
- Grundstücksform zeichnen
- Grundstück bearbeiten
- Grundstücksgröße darstellen
- Grundstück speichern

### 6.2 Gartenflächen

Innerhalb des Grundstücks können unterschiedliche Flächen eingezeichnet werden.

Beispiele:

- Rasen
- Terrasse
- Wege
- Beete
- Teich
- sonstige befestigte oder bepflanzte Flächen

Die Flächen sollen grafisch dargestellt und anschließend ausgewertet werden können.

### 6.3 Flächenberechnung

Für geeignete Flächen soll die Anwendung automatisch die Fläche berechnen.

Beispielsweise:

- Rasenfläche: 125,4 m²
- Terrasse: 24,8 m²
- Beet: 12,5 m²

Die berechneten Werte sollen Bestandteil des Gartenplans sein und gespeichert werden können.

Die fachliche Logik zur Flächenberechnung wird im Backend beziehungsweise in der entsprechenden Anwendungsschicht umgesetzt.

### 6.4 Pflanzen und Gartenelemente

Der Benutzer soll Pflanzen und weitere Objekte aus einer verfügbaren Auswahl auswählen und auf dem Gartenplan platzieren können.

Beispiele:

- Bäume
- Sträucher
- Blumen
- Hecken
- Gartenmöbel
- sonstige Gartenelemente

Ein Objekt soll mindestens folgende Informationen besitzen können:

- Bezeichnung
- Kategorie
- Position
- Größe beziehungsweise Abmessungen
- Anzahl

Objekte sollen auf dem Plan verschoben und wieder entfernt werden können.

### 6.5 Speicherung

Ein vollständiger Gartenplan soll dauerhaft gespeichert werden können.

Gespeichert werden unter anderem:

- Grundstück
- Flächen
- Flächentypen
- Pflanzen
- Gartenelemente
- Positionen
- Größen
- berechnete beziehungsweise relevante Eigenschaften

Gespeicherte Gartenpläne sollen anschließend wieder geladen und bearbeitet werden können.

---

## 7. Nicht Bestandteil des Projekts

Der Projektumfang wird bewusst begrenzt.

Folgende Funktionen sind **nicht Bestandteil der ersten Projektversion**:

- Benutzerverwaltung und Registrierung
- komplexes Rollen- und Berechtigungssystem
- Online-Shop
- Bestellsystem
- Zahlungsabwicklung
- automatische Gartenplanung durch künstliche Intelligenz
- mobile native App
- professionelle CAD-Funktionen
- automatische Vermessung eines Grundstücks
- Integration externer Kartendienste
- vollständige professionelle Landschaftsplanung

Diese Funktionen könnten bei einer späteren Weiterentwicklung ergänzt werden.

---

## 8. Zielgruppe

Die Anwendung richtet sich grundsätzlich an Personen, die einen Garten planen oder eine bestehende Gartenfläche digital dokumentieren möchten.

Mögliche Benutzer sind beispielsweise:

- private Gartenbesitzer
- Personen bei der Planung eines neuen Gartens
- Hobbygärtner
- Gartenplaner
- kleinere Gartenbaubetriebe

Für das Schulprojekt steht dabei die technische Umsetzung der Anwendung im Vordergrund.

---

## 9. Funktionale Anforderungen

| ID | Anforderung |
|---|---|
| FA-01 | Ein Grundstück kann erstellt werden. |
| FA-02 | Die Grundstücksform kann grafisch definiert werden. |
| FA-03 | Gartenflächen können innerhalb des Grundstücks gezeichnet werden. |
| FA-04 | Gartenflächen können einem Typ zugeordnet werden. |
| FA-05 | Die Fläche eines Bereichs kann berechnet werden. |
| FA-06 | Pflanzen können ausgewählt werden. |
| FA-07 | Pflanzen können auf dem Gartenplan platziert werden. |
| FA-08 | Pflanzen können verschoben werden. |
| FA-09 | Gartenelemente können hinzugefügt werden. |
| FA-10 | Elemente können gelöscht werden. |
| FA-11 | Identische Elemente können gezählt werden. |
| FA-12 | Ein Gartenplan kann gespeichert werden. |
| FA-13 | Ein gespeicherter Gartenplan kann geladen werden. |
| FA-14 | Ein Gartenplan kann bearbeitet werden. |
| FA-15 | Änderungen können dauerhaft gespeichert werden. |

---

## 10. Nichtfunktionale Anforderungen

### Bedienbarkeit

Die Anwendung soll übersichtlich und möglichst intuitiv bedienbar sein.

### Performance

Zeichenoperationen und Änderungen am Gartenplan sollen ohne merkliche Verzögerung dargestellt werden.

### Wartbarkeit

Der Quellcode soll modular aufgebaut und nachvollziehbar dokumentiert werden.

### Erweiterbarkeit

Die Architektur soll eine spätere Erweiterung um zusätzliche Pflanzen, Gartenelemente und Funktionen ermöglichen.

### Datenkonsistenz

Gespeicherte Gartenpläne müssen nach dem erneuten Laden vollständig und konsistent wiederhergestellt werden können.

### Reproduzierbarkeit

Das Projekt soll über das Git-Repository reproduzierbar aufgebaut werden können. Die Repository-Struktur soll Quellcode, Tests, Datenbankmigrationen, Dokumentation und notwendige Konfigurationen enthalten.

---

## 11. Technische Umsetzung

MyGarden wird als Fullstack-Webanwendung umgesetzt.

### Frontend

**Angular**

Das Frontend übernimmt unter anderem:

- Benutzeroberfläche
- Gartenplan
- Zeichenfunktionen
- Interaktion mit Pflanzen und Objekten
- Kommunikation mit der REST API

Für die grafische Darstellung des Gartenplans wird **Konva.js** eingesetzt.

### Backend

**C# / ASP.NET Core**

Das Backend stellt die REST API bereit und enthält die zentrale Geschäftslogik.

Geplante Schichten:

- MyGarden.Api
- MyGarden.Application
- MyGarden.Domain
- MyGarden.Infrastructure

### Datenbank

**PostgreSQL**

Die Datenbank speichert die persistenten Daten des Systems.

Dazu gehören beispielsweise:

- Gartenpläne
- Grundstücke
- Flächen
- Pflanzen
- Gartenelemente
- Positionen
- Eigenschaften der Objekte

Datenbankänderungen werden über versionierte Migrationen dokumentiert.

---

## 12. Systemarchitektur

Die grundlegende Kommunikation des Systems erfolgt nach folgendem Prinzip:

```text
┌──────────────────────┐
│       Benutzer       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│       Angular        │
│      Frontend        │
│                      │
│     Konva.js         │
└──────────┬───────────┘
           │
           │ REST / HTTP
           ▼
┌──────────────────────┐
│    ASP.NET Core      │
│        API           │
├──────────────────────┤
│ Application          │
│ Domain               │
│ Infrastructure       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      PostgreSQL      │
└──────────────────────┘
```

---

## 13. Geplante REST API

Das Backend stellt eine REST API für die Kommunikation mit dem Frontend bereit.

Beispielsweise:

```text
GET     /api/gardens
POST    /api/gardens
GET     /api/gardens/{id}
PUT     /api/gardens/{id}
DELETE  /api/gardens/{id}
```

Weitere Endpunkte können für Pflanzen, Flächen und Gartenelemente ergänzt werden.

Die API soll dokumentiert und über OpenAPI beziehungsweise Swagger beschrieben werden.

---

## 14. Datenmodell

Das geplante Domänenmodell enthält unter anderem folgende Entitäten:

```text
Garden
   │
   ├── Property
   │
   ├── Area
   │
   ├── Plant
   │
   └── GardenObject
```

### Garden

Repräsentiert einen vollständigen Gartenplan.

### Property

Repräsentiert das zu planende Grundstück.

### Area

Repräsentiert eine definierte Fläche innerhalb des Grundstücks.

### Plant

Repräsentiert eine Pflanze beziehungsweise ein Pflanzenobjekt.

### GardenObject

Repräsentiert weitere Objekte des Gartenplans.

---

## 15. Scrum

Die Entwicklung erfolgt nach **Scrum**.

Das Product Backlog enthält die bekannten Anforderungen und User Stories.

Beispielsweise:

```text
US-001 Grundstück anlegen
US-002 Grundstück bearbeiten
US-003 Rasenfläche zeichnen
US-004 Weg zeichnen
US-005 Pflanzen hinzufügen
US-006 Fläche berechnen
US-007 Garten speichern
```

Die User Stories werden in einzelne Tasks zerlegt und innerhalb der Sprints umgesetzt.

---

## 16. Beispiel einer User Story

### US-005 – Pflanzen hinzufügen

**Als Gartenplaner möchte ich Pflanzen auf meinem Grundstück platzieren, damit ich meinen Garten planen kann.**

### Akzeptanzkriterien

- [ ] Eine Pflanze kann ausgewählt werden.
- [ ] Eine Pflanze kann auf dem Gartenplan platziert werden.
- [ ] Eine Pflanze kann verschoben werden.
- [ ] Eine Pflanze kann gelöscht werden.
- [ ] Die Position der Pflanze wird gespeichert.

---

## 17. Tests

Für MyGarden werden unterschiedliche Testebenen vorgesehen.

### Unit Tests

Einzelne Klassen und Funktionen werden isoliert getestet.

Beispiele:

- `GardenServiceTests`
- `AreaCalculatorTests`
- `PlantServiceTests`

### Integration Tests

Das Zusammenspiel mehrerer Komponenten wird getestet.

Beispielsweise:

```text
API
 ↓
Application
 ↓
Database
```

### End-to-End Tests

Ein vollständiger Benutzerablauf wird getestet.

Beispiel:

```text
MyGarden öffnen
      ↓
Grundstück erstellen
      ↓
Rasenfläche zeichnen
      ↓
Pflanze hinzufügen
      ↓
Garten speichern
      ↓
Garten erneut öffnen
      ↓
Daten vorhanden
```

---

## 18. Dokumentation

Die Projektdokumentation wird innerhalb des Repositorys strukturiert abgelegt.

Vorgesehen sind unter anderem:

```text
docs/
├── requirements/
│   ├── requirements.md
│   ├── user-stories.md
│   └── use-cases.md
│
├── architecture/
│   ├── system-architecture.md
│   ├── database-model.md
│   └── api-design.md
│
└── scrum/
    ├── definition-of-done.md
    └── sprint-reports/
```

Die Dokumentation soll während der Entwicklung laufend aktualisiert werden.

---

## 19. Versionsverwaltung

Der gesamte Quellcode wird über **Git** versioniert.

Das Repository enthält unter anderem:

- Frontend
- Backend
- Datenbankmigrationen
- Tests
- Dokumentation
- Docker-Konfiguration
- CI/CD-Konfiguration

Automatisch erzeugte Dateien, Zugangsdaten und Produktionsdaten werden nicht in das Repository aufgenommen.

---

## 20. Definition of Done

Eine User Story gilt als abgeschlossen, wenn:

- [ ] die Implementierung abgeschlossen ist
- [ ] die Akzeptanzkriterien erfüllt sind
- [ ] notwendige Unit Tests vorhanden sind
- [ ] notwendige Integration Tests vorhanden sind
- [ ] alle relevanten Tests erfolgreich sind
- [ ] die Dokumentation aktualisiert wurde
- [ ] keine bekannten kritischen Fehler bestehen
- [ ] die Änderungen in den vorgesehenen Branch integriert wurden

---

## 21. Projektabgrenzung

Der Schwerpunkt des Projekts liegt auf der technischen Umsetzung einer Fullstack-Anwendung.

Besonders relevant sind:

- objektorientierte Programmierung
- Angular
- C#
- ASP.NET Core
- REST
- PostgreSQL
- Datenmodellierung
- grafische 2D-Darstellung
- Flächenberechnung
- Softwarearchitektur
- automatisierte Tests
- Git
- Scrum

Damit verbindet MyGarden die im Rahmen des Projekts erforderlichen Bereiche von Frontend-, Backend- und Datenbankentwicklung.

---

## 22. Projektergebnis

Am Ende des Projekts soll eine funktionsfähige Version von MyGarden vorliegen.

Der Benutzer soll in der Lage sein:

```text
Grundstück erstellen
        ↓
Gartenflächen zeichnen
        ↓
Flächen berechnen
        ↓
Pflanzen / Objekte platzieren
        ↓
Gartenplan bearbeiten
        ↓
Gartenplan speichern
        ↓
Gartenplan erneut laden
```

Das fertige Projekt soll als reproduzierbares Fullstack-Projekt in einem Git-Repository vorliegen und neben dem Quellcode auch Tests und Projektdokumentation enthalten.

---

## 23. Erfolgskriterien

Das Projekt gilt als erfolgreich umgesetzt, wenn:

1. ein Grundstück digital erstellt werden kann,
2. Gartenflächen grafisch gezeichnet werden können,
3. Flächen berechnet werden können,
4. Pflanzen und Gartenelemente platziert werden können,
5. Objekte bearbeitet und gelöscht werden können,
6. Gartenpläne gespeichert werden können,
7. gespeicherte Gartenpläne wieder geladen werden können,
8. Frontend, Backend und Datenbank korrekt miteinander kommunizieren,
9. die wesentlichen Funktionen automatisiert getestet werden,
10. die Projektdokumentation vollständig und nachvollziehbar ist.

---

## 24. Geplante Weiterentwicklung

Nach Abschluss der Basisversion kann MyGarden grundsätzlich erweitert werden.

Mögliche spätere Erweiterungen wären beispielsweise:

- Benutzerkonten
- mehrere Gärten pro Benutzer
- Import eines Grundstücksplans
- Angebotsberechnung
- Preisberechnung nach m²
- umfangreichere Pflanzenbibliothek
- Export und Druck eines Gartenplans
- zusätzliche Gartenobjekte
- 3D-Darstellung
- mobile Optimierung

Diese Funktionen sind jedoch ausdrücklich **nicht Bestandteil der ersten Projektversion**.
