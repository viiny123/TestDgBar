import { shareReplay, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../../login/models/login.model';
import { LoginResponse } from '../../login/models/login-response.model';
import { Observable } from 'rxjs';
import { environment } from 'projects/bardg/src/environments/environment';
import { TokenService } from '@core/services/token.service';

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(private http: HttpClient, private tokenService: TokenService) {}

  login(login: LoginModel): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(environment.url.bardg + '/api/account/login', {
        Username: login.username,
        Password: login.password,
      })
      .pipe(
        tap((response) => this.setSession(response)),
        shareReplay()
      );
  }

  private setSession(response: LoginResponse) {
    this.tokenService.token = response.accessToken;
  }

  logout() {
    this.tokenService.clear();
  }

  isLoggedIn(): boolean {
    return !this.tokenService.isExpired;
  }

  isLoggedOut(): boolean {
    return !this.isLoggedIn();
  }
}
