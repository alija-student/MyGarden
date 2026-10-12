# MyGarden 🌱

MyGarden is a planning tool for gardeners. Sketch a garden to scale, place plants on it, and
learn what each plant needs (spacing, sun, water) before doing any real work outside.

School project, HTL Leonding. Project documents (charter, design, use cases, ER and UML
diagrams, user stories, system tests) are in [`docs/`](docs/README.md).

## Tech stack

| Part       | Technology                                                     |
|------------|----------------------------------------------------------------|
| Backend    | ASP.NET Core 10 (Minimal APIs), EF Core 10, Npgsql             |
| Database   | PostgreSQL 17 (in Docker)                                      |
| Frontend   | Angular 22 (standalone, zoneless), Konva for the garden canvas |
| Tests      | xUnit, Testcontainers (backend) · Vitest (frontend) · Playwright (E2E) |
| CI/CD      | GitHub Actions (`ci.yml`, `deploy.yml`)                        |
| Hosting    | Leocloud (Kubernetes), images in GitHub Container Registry     |

## Project structure

```
MyGarden/
├── .github/workflows/
│   ├── ci.yml                   # lint, build, unit + integration + E2E tests
│   └── deploy.yml               # build images, push to GHCR, deploy to Leocloud
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
│   ├── e2e/                      # Playwright E2E tests
│   ├── angular.json
│   ├── package.json
│   ├── playwright.config.ts
│   └── proxy.conf.json           # /api -> http://localhost:5080 in dev
├── docker/                       # Dockerfile.api, Dockerfile.web, nginx.conf
├── docs/                         # project documents and diagrams
├── k8s/                          # Kubernetes manifests for Leocloud
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

# 2. Frontend dependencies (exact versions from package-lock.json)
cd frontend
npm ci

# 3. Browser for the E2E tests (once)
npx playwright install chromium
cd ..
```

## Running locally

```bash
# 1. Start PostgreSQL (add "--profile tools" for pgAdmin on http://localhost:5050)
docker compose up -d

# 2. Start the API -> http://localhost:5080  (OpenAPI: /openapi/v1.json)
#    Pending migrations are applied automatically on startup.
cd backend
dotnet run --project src/MyGarden.Api

# 3. Start the frontend in a second terminal -> http://localhost:4200
cd frontend
npm start
```

`ng serve` forwards all `/api` requests to the backend (`proxy.conf.json`), so there are no CORS issues.
`backend/src/MyGarden.Api/MyGarden.Api.http` has sample requests you can run from VS Code / Rider / Visual Studio.

To run the whole stack in containers instead: `docker compose --profile app up -d --build`
(web app on http://localhost:8081, API on http://localhost:8080).

## Database migrations

Migrations live in `backend/src/MyGarden.Infrastructure/Persistence/Migrations`.
Run these from the `backend/` folder:

```bash
# Create a migration after changing entities (use a descriptive name)
dotnet ef migrations add AddPlantNotes \
  --project src/MyGarden.Infrastructure \
  --startup-project src/MyGarden.Api \
  --output-dir Persistence/Migrations

# Apply migrations manually (optional - the API does this on startup)
dotnet ef database update \
  --project src/MyGarden.Infrastructure \
  --startup-project src/MyGarden.Api
```

The API applies pending migrations on startup when `Database:MigrateOnStartup` is `true`
(set in `appsettings.Development.json`, `docker-compose.yml` and `k8s/api.yaml`).
The integration tests apply all migrations to a fresh PostgreSQL container, so a broken
migration fails CI.

## Tests

| Level | Tool | Where | Run |
|---|---|---|---|
| Unit | xUnit, Vitest | `backend/tests/MyGarden.UnitTests`, `frontend/src/**/*.spec.ts` | CI + locally |
| Integration | xUnit + Testcontainers | `backend/tests/MyGarden.IntegrationTests` | CI + locally |
| E2E | Playwright | `frontend/e2e` | CI + locally |
| System | Manual checklist | [`docs/system-tests.md`](docs/system-tests.md) | before every sprint review |

```bash
# Backend unit + integration tests (Docker must be running)
cd backend
dotnet test

# Frontend unit tests
cd frontend
npm test

# E2E tests against the full stack in Docker
docker compose --profile app up -d --build
cd frontend
npm run e2e
# ...or against `npm start`: E2E_BASE_URL=http://localhost:4200 npm run e2e
```

## Deployment (Leocloud)

Every push to `main` runs CI. If CI succeeds, the **Deploy** workflow builds the `api` and
`web` images, pushes them to GitHub Container Registry
(`ghcr.io/alija-student/mygarden-api` / `mygarden-web`) and applies the manifests in
[`k8s/`](k8s) to Leocloud. It can also be started manually under *Actions → Deploy → Run workflow*.

Until the Leocloud settings below exist, the deploy job is skipped and only the images are pushed.

One-time setup in *Settings → Secrets and variables → Actions*:

| Type | Name | Value |
|---|---|---|
| Secret | `KUBECONFIG` | Content of the kubeconfig file from Leocloud |
| Secret | `POSTGRES_PASSWORD` | A strong password for the production database |
| Variable | `LEOCLOUD_HOST` | Public host name of the app, as assigned by Leocloud |
| Variable | `LEOCLOUD_NAMESPACE` | *(optional)* Namespace, if the kubeconfig has no default |
| Secret | `GHCR_PULL_TOKEN` | *(optional)* Personal access token with `read:packages`, only if the images stay private |

The images are private by default. Either make both packages public
(*GitHub profile → Packages → package → Package settings → Change visibility*) or set
`GHCR_PULL_TOKEN`.

Useful commands with the Leocloud kubeconfig:

```bash
kubectl get pods                      # status of db, api and web
kubectl logs deployment/api           # API logs
kubectl rollout restart deployment/api
```

## Linting

- Backend: `dotnet format backend/MyGarden.sln --verify-no-changes` (rules in `.editorconfig`)
- Frontend: add ESLint with `ng add angular-eslint`. CI runs `npm run lint` automatically once the script exists.
