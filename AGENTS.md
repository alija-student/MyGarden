# AGENTS.md

Instructions for AI coding assistants working on MyGarden. The full documentation is in
`README.md`. This file lists what you need to get started and the mistakes that are easy to make.

## Stack

- Backend: ASP.NET Core 10 Minimal APIs, EF Core 10 + Npgsql, in `backend/` (`MyGarden.sln`).
  Layers: `Api -> Application -> Domain`; `Infrastructure` implements `Application` interfaces.
- Frontend: Angular 22 (standalone, zoneless) + Konva, in `frontend/`.
- Database: PostgreSQL 17 in Docker (`docker-compose.yml` at the repo root).
- Docker files: `docker/Dockerfile.api`, `docker/Dockerfile.web`, `docker/nginx.conf`.
  The build context is the repo root.
- Production: Leocloud (Kubernetes), manifests in `k8s/`, deployed by `.github/workflows/deploy.yml`.

## Running locally

Docker Desktop must be running. Run commands from the repo root.

| Goal | Command | URL |
|---|---|---|
| Database only | `docker compose up -d` | localhost:5432 |
| + pgAdmin | `docker compose --profile tools up -d` | http://localhost:5050 |
| Whole stack in containers | `docker compose --profile app up -d --build` | web http://localhost:8081, API http://localhost:8080 |
| API on host | `dotnet run --project backend/src/MyGarden.Api` | http://localhost:5080 |
| Frontend on host | `cd frontend && npm ci && npm start` | http://localhost:4200 (proxies `/api` to 5080) |

The API applies EF Core migrations on startup (`Database:MigrateOnStartup`).

## Known pitfalls

- **DB password mismatch:** `dotnet run` does not read `.env`. It uses the connection string in
  `backend/src/MyGarden.Api/appsettings.Development.json` (password `mygarden`). If `.env` has a
  different `POSTGRES_PASSWORD`, the API fails with "password authentication failed". Fix it by
  setting `ConnectionStrings__Default` in the shell before `dotnet run`:
  `$env:ConnectionStrings__Default = ((Get-Content .env | Select-String '^ConnectionStrings__Default=').Line -split '=',2)[1]`
  (PowerShell), or by using the default password `mygarden`.
- **Password stuck in the volume:** Postgres only sets the password when the `pgdata` volume is
  first created. Changing `.env` later has no effect until `docker compose down -v`, which deletes
  all local data. Ask the user before running it.
- **Port 5432 taken** by a locally installed PostgreSQL: change `POSTGRES_PORT` in `.env` and the
  port in the connection string.
- Don't run the `api` container and `dotnet run` at the same time against the same DB if you're
  debugging migrations. Stop one of them first.
- Never commit `.env`. Only `.env.example` is tracked.

## Tests and checks

- Backend: `dotnet test backend/MyGarden.sln` (integration tests use Testcontainers, so Docker
  must be running).
- Frontend unit: `cd frontend && npm test` (Vitest).
- E2E: start the stack with `docker compose --profile app up -d --build`, then `cd frontend && npm run e2e`.
- Format: `dotnet format backend/MyGarden.sln --verify-no-changes`.

## Migrations

Run from `backend/`:

```
dotnet ef migrations add <Name> --project src/MyGarden.Infrastructure --startup-project src/MyGarden.Api --output-dir Persistence/Migrations
```

Requires `dotnet tool install --global dotnet-ef`.
