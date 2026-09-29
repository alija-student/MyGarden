import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateGardenRequest, Garden } from '../../shared/models/garden';

/** Typed client for the /api/gardens endpoints (proxied to the .NET backend in dev). */
@Injectable({ providedIn: 'root' })
export class GardenApi {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = '/api/gardens';

  getAll(): Observable<Garden[]> {
    return this.http.get<Garden[]>(this.baseUrl);
  }

  get(id: string): Observable<Garden> {
    return this.http.get<Garden>(`${this.baseUrl}/${id}`);
  }

  create(request: CreateGardenRequest): Observable<Garden> {
    return this.http.post<Garden>(this.baseUrl, request);
  }
}
