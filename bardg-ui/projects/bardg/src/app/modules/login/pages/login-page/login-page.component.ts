import { AuthService } from '../../../shared/services/auth.service';
import { Component } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { NavigationPaths } from '@core/constants/navegation/navigation-paths';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.less'],
})
export class LoginPageComponent {
  isLoading = false;

  constructor(private authService: AuthService, private router: Router) {}

  login(login: LoginModel) {
    this.isLoading = true;
    this.authService
      .login(login)
      .pipe(
        catchError((error) => {
          this.isLoading = false;
          return throwError(error);
        })
      )
      .subscribe(() => {
        this.router.navigate([NavigationPaths.order]);
      });
  }
}
