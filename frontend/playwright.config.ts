import { defineConfig, devices } from '@playwright/test';

/**
 * E2E tests run against the full stack (web + api + db), started with
 *   docker compose --profile app up -d --build
 * Override the target with E2E_BASE_URL, e.g. http://localhost:4200 for `npm start`.
 */
export default defineConfig({
  testDir: './e2e',
  fullyParallel: true,
  forbidOnly: !!process.env['CI'],
  retries: process.env['CI'] ? 1 : 0,
  reporter: process.env['CI'] ? [['list'], ['html', { open: 'never' }]] : 'list',
  use: {
    baseURL: process.env['E2E_BASE_URL'] ?? 'http://localhost:8081',
    trace: 'on-first-retry',
  },
  projects: [{ name: 'chromium', use: { ...devices['Desktop Chrome'] } }],
});
