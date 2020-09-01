import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { LoginLogoComponent } from './components/login-logo/login-logo.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { LoginRoutesModule } from './login.routes';
import { NgModule } from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../shared/shared.module';

@NgModule({
  declarations: [LoginPageComponent, LoginFormComponent, LoginLogoComponent],
  imports: [
    CommonModule,
    LoginRoutesModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    NzFormModule,
    NzInputModule,
    NzButtonModule,
    NzTypographyModule,
    NzSelectModule,
  ],
})
export class LoginModule {}
