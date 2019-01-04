import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { User } from './user.model';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  register(user: User): Observable<void> {
    return this.http.post<void>(`${API_URL}/authentication/register`, user);
  }

  logIn(user: User): Observable<string> {
    return this.http.post<string>(`${API_URL}/authentication/login`, user);
  }
}
