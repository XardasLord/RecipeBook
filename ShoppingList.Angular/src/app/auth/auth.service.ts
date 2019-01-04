import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(http: HttpClient) { }

  register(email: string, password: string) {
    // TODO: Here will be created call to the API to register the user
  }
}
