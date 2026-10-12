# User Stories (Product Backlog)

Draft backlog to transfer into the GitHub Project (template "Iterative Development"):
one issue per user story, label `user story`, and the sprint set in the project's
*Iteration* field. Priorities and sprint assignment are suggestions – agree on them with
the supervisor.

Status: ✅ done · ⬜ open

## Epic: Gardens

| ID | User story | Acceptance criteria | Prio | Status |
|---|---|---|---|---|
| US-01 | As a gardener I want to create a garden with its real size so that I can plan it to scale. | Name required, width/length > 0 cm; garden appears in the list. | Must | ✅ |
| US-02 | As a gardener I want to see all my gardens so that I can open the one I want to work on. | List sorted by name with size in metres; empty state message. | Must | ✅ |
| US-03 | As a gardener I want to rename or resize a garden so that I can correct mistakes. | `PUT /api/gardens/{id}`; validation as in US-01; plants outside the new size are flagged. | Should | ⬜ |
| US-04 | As a gardener I want to delete a garden so that my list stays tidy. | Confirmation dialog; placements are deleted too. | Should | ⬜ |
| US-05 | As a gardener I want to see helpful error messages when my input is invalid. | Server validation errors are shown next to the form. | Should | ⬜ |

## Epic: Plant catalogue

| ID | User story | Acceptance criteria | Prio | Status |
|---|---|---|---|---|
| US-10 | As a gardener I want to browse a catalogue of plants so that I can choose what to plant. | `GET /api/plants`; seed data with at least 15 common vegetables/herbs. | Must | ⬜ |
| US-11 | As a gardener I want to see a plant's needs (spacing, height, sun, water) so that I know where it fits. | Detail view with all care data. | Must | ⬜ |
| US-12 | As a gardener I want to search and filter plants (e.g. by sun) so that I find suitable ones quickly. | Search by name, filter by sun and water. | Could | ⬜ |
| US-13 | As an administrator I want to add and edit plants so that the catalogue grows. | CRUD endpoints + form; deleting a placed plant is blocked. | Could | ⬜ |

## Epic: Garden editor (canvas)

| ID | User story | Acceptance criteria | Prio | Status |
|---|---|---|---|---|
| US-20 | As a gardener I want to see my garden to scale with a grid so that I can judge distances. | Canvas scaled to screen width, 50 cm grid. | Must | ✅ |
| US-21 | As a gardener I want to drag a plant from the catalogue onto my garden. | Placement saved in cm; survives a reload. | Must | ⬜ |
| US-22 | As a gardener I want to move and remove placed plants. | Drag saves the new position; remove via button/context menu. | Must | ⬜ |
| US-23 | As a gardener I want to be warned when plants are too close so that they have room to grow. | Circles show spacing; overlapping plants are highlighted with a reason. | Should | ⬜ |
| US-24 | As a gardener I want to zoom and pan in large gardens. | Mouse wheel zoom, drag to pan. | Could | ⬜ |

## Epic: Operations

| ID | User story | Acceptance criteria | Prio | Status |
|---|---|---|---|---|
| US-30 | As the team we want every push to be built and tested automatically. | CI runs lint, unit, integration and E2E tests. | Must | ✅ |
| US-31 | As the team we want main to be deployed to Leocloud automatically. | Deploy workflow green; app reachable under the Leocloud URL. | Must | ⬜ (waiting for Leocloud access) |

## Suggested sprint plan

| Sprint | Stories |
|---|---|
| 1 | US-01, US-02, US-20, US-30 (done), US-31 |
| 2 | US-10, US-11, US-21, US-05 |
| 3 | US-22, US-23, US-03, US-04 |
| 4 | US-12, US-13, US-24, polishing |
