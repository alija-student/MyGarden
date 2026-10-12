# System Tests

Manual tests of the complete, deployed system from the user's point of view. Run all active
test cases **before every sprint review** (on Leocloud, or locally with
`docker compose --profile app up -d --build` → http://localhost:8081) and record the result
in the [execution log](#execution-log).

Automated tests (unit, integration, Playwright E2E) run in CI on every push and are not
listed here.

## Test cases

| ID | Title | Use case | Status |
|---|---|---|---|
| ST-01 | Application is reachable | – | active |
| ST-02 | Create a garden | UC1 | active |
| ST-03 | Reject invalid garden input | UC1 | active |
| ST-04 | Open a garden on the canvas | UC2 | active |
| ST-05 | Data survives a restart | UC1 | active |
| ST-06 | Behaviour when the API is down | – | active |
| ST-07 | Direct link to a garden | UC2 | active |
| ST-08 | Place a plant | UC3 | planned |
| ST-09 | Spacing warning | UC6 | planned |

### ST-01 – Application is reachable

| | |
|---|---|
| Precondition | Application is deployed. |
| Steps | 1. Open the application URL in a browser. 2. Open `<URL>/api/health`. |
| Expected result | 1. Garden list "My gardens" is shown, no error message. 2. `{"status":"ok"}`. |

### ST-02 – Create a garden

| | |
|---|---|
| Steps | 1. Enter the name "Vegetable bed", width 400, length 250. 2. Click "Create garden". |
| Expected result | "Vegetable bed (4 m × 2.5 m)" appears in the list; the name field is cleared. |

### ST-03 – Reject invalid garden input

| | |
|---|---|
| Steps | 1. Leave the name empty and click "Create garden". 2. Enter a name and width 0, click "Create garden". |
| Expected result | No garden is created in either case. **TODO** once the UI shows validation messages, check the message text. |

### ST-04 – Open a garden on the canvas

| | |
|---|---|
| Precondition | A garden 400 × 250 cm exists. |
| Steps | 1. Click the garden in the list. |
| Expected result | Garden name as heading; brown area with a proportion of 400:250; grid lines every 50 cm (7 vertical, 4 horizontal); the placeholder plant can be dragged. |

### ST-05 – Data survives a restart

| | |
|---|---|
| Precondition | At least one garden exists. |
| Steps | 1. Restart the API and database (locally: `docker compose --profile app restart`; Leocloud: delete the api and db pods). 2. Reload the page. |
| Expected result | All gardens are still there. |

### ST-06 – Behaviour when the API is down

| | |
|---|---|
| Steps | 1. Stop the API (locally: `docker compose stop api`). 2. Reload the garden list. 3. Start the API again and reload. |
| Expected result | 2. "Could not reach the API. Is the backend running?" is shown. 3. The list loads normally again. |

### ST-07 – Direct link to a garden

| | |
|---|---|
| Steps | 1. Open a garden, copy the URL. 2. Open the URL in a new tab. 3. Open `<URL>/gardens/does-not-exist`. |
| Expected result | 2. The same garden is shown. 3. **TODO** define expected behaviour (currently stays on "Loading…"). |

### ST-08 – Place a plant (planned, sprint TODO)

### ST-09 – Spacing warning (planned, sprint TODO)

## Execution log

Result: ✅ passed · ❌ failed (link the issue) · ⏭ skipped

| Date | Version (commit) | Environment | Tester | ST-01 | ST-02 | ST-03 | ST-04 | ST-05 | ST-06 | ST-07 | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|
| | | | | | | | | | | | |
