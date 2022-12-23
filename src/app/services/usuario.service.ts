import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  myAppUrl: string = environment.endpoint;
  myApiUrl: string = 'api/Usuario/';
  constructor(private http: HttpClient) { }


  getUsuario(id: number): Observable<Usuario>{
    return this.http.get<Usuario>(`${this.myAppUrl}${this.myApiUrl}${id}`)
  }

  deleteUsuario(id: number): Observable<void>{
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${id}`)
  }

  addUsuario(usuario: Usuario): Observable<void>{ 
    return this.http.post<void>(`${this.myAppUrl}${this.myApiUrl}`, usuario);
  }

  updateUsuario(id: number, usuario: Usuario): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${id}`, usuario);  
  }
}

