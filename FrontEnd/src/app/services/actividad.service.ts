import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Actividad } from '../interfaces/actividad';

@Injectable({
  providedIn: 'root'
})
export class ActividadService {
  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Actividad/';

  constructor(private http: HttpClient) { }

  getActividades(): Observable<Actividad[]> {
    return this.http.get<Actividad[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }

  addActividad(actividad: Actividad): Observable<void>{ 
    return this.http.post<void>(`${this.myAppUrl}${this.myApiUrl}`, actividad);
  }
}

