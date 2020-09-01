import {
  MenuOutline,
  UpOutline,
  DownOutline,
  LogoutOutline,
} from '@ant-design/icons-angular/icons';

import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { BreadcrumbModule } from 'angular-crumbs';
import { CommonModule } from '@angular/common';
import { IconDefinition } from '@ant-design/icons-angular';
import { LoadingComponent } from './components/loading/loading.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NgModule } from '@angular/core';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { NavbarUserComponent } from './components/navbar-user/navbar-user.component';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';

const icons: IconDefinition[] = [
  MenuOutline,
  UpOutline,
  DownOutline,
  LogoutOutline,
];

@NgModule({
  declarations: [
    LoadingComponent,
    LoadingSpinnerComponent,
    BreadcrumbComponent,
    NavbarComponent,
    NavbarUserComponent,
  ],
  imports: [
    CommonModule,
    BreadcrumbModule,
    TranslateModule,
    RouterModule,
    NzBreadCrumbModule,
    NzButtonModule,
    NzIconModule,
    NzMenuModule,
    NzToolTipModule,
    NzIconModule.forChild(icons),
    NzDropDownModule,
  ],
  exports: [
    TranslateModule,
    NzBreadCrumbModule,
    RouterModule,
    LoadingComponent,
    LoadingSpinnerComponent,
    BreadcrumbComponent,
    NavbarComponent,
    NavbarUserComponent,
  ],
})
export class SharedModule {}
