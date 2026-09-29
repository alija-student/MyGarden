import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  template: `
    <header>
      <a routerLink="/">🌱 MyGarden</a>
    </header>
    <main>
      <router-outlet />
    </main>
  `,
  styles: `
    header {
      padding: 0.75rem 1.5rem;
      background: var(--leaf);
    }
    header a {
      color: white;
      font-weight: 600;
      text-decoration: none;
    }
    main {
      padding: 1.5rem;
    }
  `,
})
export class App {}
