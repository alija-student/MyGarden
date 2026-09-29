import {
  Component,
  ElementRef,
  OnDestroy,
  afterRenderEffect,
  effect,
  inject,
  input,
  signal,
  viewChild,
} from '@angular/core';
import Konva from 'konva';
import { GardenApi } from '../../core/api/garden-api';
import { Garden } from '../../shared/models/garden';

const GRID_CM = 50;

/**
 * Draws a garden plan with Konva: Stage → Layer → Shapes.
 * The garden is scaled so its width fits the container; 1 grid cell = 50 cm.
 */
@Component({
  selector: 'app-garden-canvas',
  template: `
    <h1>{{ garden()?.name ?? 'Loading…' }}</h1>
    <p>Drag the plant around. Grid cells are {{ gridCm }} cm.</p>
    <div #container class="canvas"></div>
  `,
  styles: `
    .canvas {
      max-width: 900px;
      border: 1px solid #c9d3c0;
      background: white;
    }
  `,
})
export class GardenCanvas implements OnDestroy {
  /** Bound from the :id route parameter (withComponentInputBinding). */
  readonly id = input.required<string>();

  private readonly api = inject(GardenApi);
  private readonly container = viewChild.required<ElementRef<HTMLDivElement>>('container');
  private stage?: Konva.Stage;

  protected readonly garden = signal<Garden | null>(null);
  protected readonly gridCm = GRID_CM;

  constructor() {
    effect((onCleanup) => {
      const sub = this.api.get(this.id()).subscribe((g) => this.garden.set(g));
      onCleanup(() => sub.unsubscribe());
    });

    afterRenderEffect(() => {
      const garden = this.garden();
      if (garden) this.draw(garden, this.container().nativeElement);
    });
  }

  ngOnDestroy(): void {
    this.stage?.destroy();
  }

  private draw(garden: Garden, el: HTMLDivElement): void {
    this.stage?.destroy();

    const width = el.clientWidth || 800;
    const scale = width / garden.widthCm; // pixels per cm
    const height = garden.lengthCm * scale;

    this.stage = new Konva.Stage({ container: el, width, height });
    const ground = new Konva.Layer({ listening: false });
    const plants = new Konva.Layer();

    ground.add(new Konva.Rect({ width, height, fill: '#d8c6a0' }));
    for (let x = GRID_CM; x < garden.widthCm; x += GRID_CM) {
      ground.add(new Konva.Line({ points: [x * scale, 0, x * scale, height], stroke: '#00000022' }));
    }
    for (let y = GRID_CM; y < garden.lengthCm; y += GRID_CM) {
      ground.add(new Konva.Line({ points: [0, y * scale, width, y * scale], stroke: '#00000022' }));
    }

    // Placeholder plant: a tomato needs roughly 60 cm spacing
    const spacingCm = 60;
    plants.add(
      new Konva.Circle({
        x: width / 2,
        y: height / 2,
        radius: (spacingCm / 2) * scale,
        fill: '#2f7d32cc',
        stroke: '#1b5e20',
        draggable: true,
      }),
    );

    this.stage.add(ground, plants);
  }
}
