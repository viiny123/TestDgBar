import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './../app/modules/layout/components/main-layout/main-layout.component';
import { NavigationPaths } from '@core/constants/navegation/navigation-paths';
import { NavigationRoutes } from '@core/constants/navegation/navigation-routes';
import { NgModule } from '@angular/core';
import { AuthGuard } from '@core/guards/auth.guard';

const routes: Routes = [
  {
    path: NavigationRoutes.login.root,
    loadChildren: () =>
      import('./modules/login/login.module').then((m) => m.LoginModule),
  },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: NavigationRoutes.order.root,
        loadChildren: () =>
          import('./modules/order/order.module').then((m) => m.OrderModule),
        canActivate: [AuthGuard],
      },
      {
        path: '**',
        redirectTo: NavigationPaths.order,
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutesModule {}
