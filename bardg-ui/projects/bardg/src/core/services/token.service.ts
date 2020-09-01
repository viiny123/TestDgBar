import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token } from '@core/models/token.model';

const TOKEN_NAME = 'token';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private jwtHelper = new JwtHelperService();

  constructor() {}

  get tokenData(): Token {
    return this.jwtHelper.decodeToken(this.token);
  }

  get token(): string {
    return localStorage.getItem(TOKEN_NAME);
  }

  set token(value: string) {
    localStorage.setItem(TOKEN_NAME, value);
  }

  clear() {
    localStorage.removeItem(TOKEN_NAME);
  }

  get isExpired(): boolean {
    return this.jwtHelper.isTokenExpired(this.token);
  }
}
