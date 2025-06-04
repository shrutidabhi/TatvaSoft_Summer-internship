import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../environments/environment.prod';


 // Adjust the path as necessary

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'access_Token';
  private jwtHelper = new JwtHelperService();
  currentUser = new BehaviorSubject<any>(null);
  private baseUrl = environment.apiBaseUrl; // Ensure this is set in your environment files

  constructor(private http: HttpClient) {}

  loginUser(credentials: { EmailAddress: string; Password: string }) {
    return this.http.post(`${this.baseUrl}/login`, credentials);
  }

  setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }

  decodedToken() {
    const token = this.getToken();
    return token ? this.jwtHelper.decodeToken(token) : null;
  }

  isLoggedIn() {
    const token = this.getToken();
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }

  setCurrentUser(user: any) {
    this.currentUser.next(user);
  }

  getCurrentUser() {
    return this.currentUser.asObservable();
  }
}