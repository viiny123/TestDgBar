import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../../app/modules/shared/services/auth.service';
import { NavigationPaths } from '@core/constants/navegation/navigation-paths';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.auth.isLoggedOut()) {
      this.router.navigate([NavigationPaths.login]);
      return false;
    }
    return true;
  }
}
