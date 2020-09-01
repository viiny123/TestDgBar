import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NavigationPaths } from '@core/constants/navegation/navigation-paths';

@Component({
  selector: 'pj-navbar-user',
  templateUrl: './navbar-user.component.html',
  styleUrls: ['./navbar-user.component.less']
})
export class NavbarUserComponent {

  constructor(private authService: AuthService, private router: Router) { }

  logout() {
    this.authService.logout();
    this.router.navigate([NavigationPaths.login]);
  }
}
