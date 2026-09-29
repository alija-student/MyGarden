# MyGarden 🌱

MyGarden is a planning tool for gardeners. Sketch a garden to scale, place plants on it, and
learn what each plant needs (spacing, sun, water) before doing any real work outside.

School project, HTL.

## Tech stack

| Part      | Technology                                                    |
|-----------|---------------------------------------------------------------|
| Backend   | ASP.NET Core 10 (Minimal APIs), EF Core 10, Npgsql            |
| Database  | PostgreSQL 17 (in Docker)                                     |
| Frontend  | Angular 22 (standalone, zoneless), Konva for the garden canvas |
| Tests     | xUnit, Testcontainers (backend) · Vitest (frontend)          |
| CI        | GitHub Actions (`.github/workflows/ci.yml`)                   |

## Project structure

```
my-garden/
├── .github/workflows/ci.yml     # CI: build, lint, test (backend + frontend)
├── backend/
│   ├── src/
│   │   ├── MyGarden.Api/            # Program.cs, endpoints, appsettings
│   │   ├── MyGarden.Application/    # services, DTOs, repository interfaces
│   │   ├── MyGarden.Domain/         # entities: Garden, Plant, PlantPlacement
│   │   └── MyGarden.Infrastructure/ # EF Core DbContext, migrations, repositories
│   ├── tests/
│   │   ├── MyGarden.UnitTests/
│   │   └── MyGarden.IntegrationTests/  # real PostgreSQL via Testcontainers
│   ├── MyGarden.sln
│   ├── Directory.Build.props     # shared settings (net10.0, Nullable, ...)
│   ├── Directory.Packages.props  # central NuGet versions
│   └── global.json               # pinned .NET SDK
├── frontend/
│   ├── src/app/
│   │   ├── core/                 # API client, interceptors
│   │   ├── features/
│   │   │   ├── canvas/           # Konva garden editor (Stage, Layer, Shapes)
│   │   │   └── gardens/          # garden list / create
│   │   └── shared/               # models shared across features
│   ├── angular.json
│   ├── package.json
│   └── proxy.conf.json           # /api -> http://localhost:5080 in dev
├── docker/                       # Dockerfile.api, Dockerfile.web, nginx.conf
├── docker-compose.yml            # PostgreSQL (+ pgAdmin, + app containers)
└── .env.example
```

The backend follows a layered ("clean") architecture: `Api → Application → Domain`, and
`Infrastructure` implements the interfaces defined in `Application`.

## Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download) (version pinned in `backend/global.json`)
- [Node.js 24 LTS](https://nodejs.org/) (includes npm)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (database + integration tests)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

## First-time setup

```bash
# 1. Environment variables
cp .env.example .env            # then edit the passwords

# 2. Frontend dependencies - creates package-lock.json, which MUST be committed
cd frontend
npm install
cd ..
```

> CI uses `npm ci`, which fails without `frontend/package-lock.json`. Commit it after the first `npm install`.

## Running locally

```bash
# 1. Start PostgreSQL (add "--profile tools" for pgAdmin on http://localhost:5050)
docker compose up -d

# 2. Start the API -> http://localhost:5080  (OpenAPI: /openapi/v1.json)
cd backend
dotnet run --project src/MyGarden.Api

# 3. Start the frontend in a second terminal -> http://localhost:4200
cd frontend
npm start
```

`ng serve` forwards all `/api` requests to the backend (`proxy.conf.json`), so there are no CORS issues.
`backend/src/MyGarden.Api/MyGarden.Api.http` has sample requests you can run from VS Code / Rider / Visual Studio.

To run the whole stack in containers instead: `docker compose --profile app up -d --build`
(web app on http://localhost:8081).

## Database migrations

Migrations live in `backend/src/MyGarden.Infrastructure/Persistence/Migrations`.
Run these from the `backend/` folder:

```bash
# Create a migration after changing entities
dotnet ef migrations add InitialCreate \
  --project src/MyGarden.Infrastructure \
  --startup-project src/MyGarden.Api \
  --output-dir Persistence/Migrations

# Apply migrations to the local database
dotnet ef database update \
  --project src/MyGarden.Infrastructure \
  --startup-project src/MyGarden.Api
```

After the first migration exists, switch `EnsureCreatedAsync()` to `MigrateAsync()` in
`tests/MyGarden.IntegrationTests/MyGardenApiFactory.cs`.

## Tests

```bash
# Backend (integration tests need Docker running)
cd backend
dotnet test

# Frontend
cd frontend
npm test
```

## Linting

- Backend: `dotnet format backend/MyGarden.sln --verify-no-changes` (rules in `.editorconfig`)
- Frontend: add ESLint with `ng add angular-eslint`. CI runs `npm run lint` automatically once the script exists.
