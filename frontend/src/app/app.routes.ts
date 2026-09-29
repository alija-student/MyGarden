import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/gardens/garden-list').then((m) => m.GardenList),
  },
  {
    path: 'gardens/:id',
    loadComponent: () => import('./features/canvas/garden-canvas').then((m) => m.GardenCanvas),
  },
  { path: '**', redirectTo: '' },
];
