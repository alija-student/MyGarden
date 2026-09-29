import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { GardenApi } from '../../core/api/garden-api';
import { Garden } from '../../shared/models/garden';

@Component({
  selector: 'app-garden-list',
  imports: [FormsModule, RouterLink],
  template: `
    <h1>My gardens</h1>

    @if (error()) {
      <p class="error">Could not reach the API. Is the backend running?</p>
    }

    <ul>
      @for (garden of gardens(); track garden.id) {
        <li>
          <a [routerLink]="['/gardens', garden.id]">{{ garden.name }}</a>
          ({{ garden.widthCm / 100 }} m × {{ garden.lengthCm / 100 }} m)
        </li>
      } @empty {
        <li>No gardens yet. Create your first one below.</li>
      }
    </ul>

    <form (ngSubmit)="create()">
      <input name="name" [(ngModel)]="name" placeholder="Name" required />
      <input name="width" type="number" [(ngModel)]="widthCm" min="1" /> cm wide
      <input name="length" type="number" [(ngModel)]="lengthCm" min="1" /> cm long
      <button type="submit">Create garden</button>
    </form>
  `,
  styles: `
    .error {
      color: #b00020;
    }
    form {
      display: flex;
      flex-wrap: wrap;
      gap: 0.5rem;
      align-items: center;
    }
  `,
})
export class GardenList {
  private readonly api = inject(GardenApi);

  protected readonly gardens = signal<Garden[]>([]);
  protected readonly error = signal(false);

  protected name = '';
  protected widthCm = 400;
  protected lengthCm = 300;

  constructor() {
    this.load();
  }

  protected create(): void {
    if (!this.name.trim()) return;
    this.api
      .create({ name: this.name, widthCm: this.widthCm, lengthCm: this.lengthCm })
      .subscribe(() => {
        this.name = '';
        this.load();
      });
  }

  private load(): void {
    this.api.getAll().subscribe({
      next: (gardens) => {
        this.gardens.set(gardens);
        this.error.set(false);
      },
      error: () => this.error.set(true),
    });
  }
}
