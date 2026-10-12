import { expect, test } from '@playwright/test';

test('shows the garden list', async ({ page }) => {
  await page.goto('/');

  await expect(page.getByRole('heading', { name: 'My gardens' })).toBeVisible();
  await expect(page.getByText('Could not reach the API')).toBeHidden();
});

test('creates a garden and opens it on the canvas', async ({ page }) => {
  const name = `E2E garden ${Date.now()}`;
  await page.goto('/');

  await page.getByPlaceholder('Name').fill(name);
  await page.getByRole('button', { name: 'Create garden' }).click();

  const link = page.getByRole('link', { name });
  await expect(link).toBeVisible();

  await link.click();

  await expect(page).toHaveURL(/\/gardens\/[0-9a-f-]{36}$/);
  await expect(page.getByRole('heading', { name })).toBeVisible();
  await expect(page.locator('.canvas canvas').first()).toBeVisible();
});

test('unknown routes redirect to the garden list', async ({ page }) => {
  await page.goto('/does-not-exist');

  await expect(page).toHaveURL(/\/$/);
  await expect(page.getByRole('heading', { name: 'My gardens' })).toBeVisible();
});
