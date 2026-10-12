# Project Charter – MyGarden

| | |
|---|---|
| Project name | MyGarden |
| School / class | HTL Leonding – **TODO** class |
| Supervisor | **TODO** |
| Team | **TODO** names and roles |
| Start | **TODO** |
| Planned end | **TODO** |
| Repository | https://github.com/alija-student/MyGarden |

## Initial situation

Hobby gardeners often plan beds by guessing: plants end up too close together, sun-loving
plants are put in the shade, and plants with very different water needs share a bed. The
mistakes only become visible weeks later, when it is too late to fix them cheaply.

## Project goal

MyGarden is a web application in which a gardener sketches a garden to scale, places plants
on it and immediately sees what each plant needs (spacing, sun, water). Problems such as
plants placed too close together are made visible before any work is done outside.

### Goals

- Create and manage gardens with real dimensions (cm).
- Place plants from a plant catalogue on a scaled canvas by drag and drop.
- Show plant requirements (spacing, mature height, sun, water) and warn about conflicts.
- Run the application in the cloud (Leocloud) with automated deployment.

### Non-goals

- **TODO** confirm with the team, e.g.: no native mobile app, no shop or plant ordering,
  no weather or sensor integration.

## Scope

| In scope | Out of scope |
|---|---|
| Garden management (create, edit, delete) | **TODO** |
| Plant catalogue with care data | |
| Canvas editor for placing plants | |
| Spacing and requirement warnings | |
| Deployment to Leocloud | |

## Milestones / sprints

| Sprint | End (sprint review) | Goal |
|---|---|---|
| 1 | **TODO** | Project setup, CI/CD, garden list and creation |
| 2 | **TODO** | **TODO** |
| 3 | **TODO** | **TODO** |

See [user-stories.md](user-stories.md) for the backlog.

## Risks

| Risk | Impact | Countermeasure |
|---|---|---|
| Canvas editor (Konva) is more complex than expected | Medium | Build a minimal version first, extend in later sprints |
| Leocloud access arrives late | Medium | App runs fully in Docker locally; deploy workflow is ready |
| Plant data (spacing, sun, water) is incomplete | Low | Start with a small, curated seed list |
| **TODO** | | |

## Stakeholders

| Role | Name |
|---|---|
| Client / supervisor | **TODO** |
| Developers | **TODO** |
| Users | Hobby gardeners |
