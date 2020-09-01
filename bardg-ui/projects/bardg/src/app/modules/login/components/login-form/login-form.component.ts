import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginModel } from '../../models/login.model';
import { validateFormFields } from '@core/utils/form-helper';

@Component({
  selector: 'pj-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.less']
})
export class LoginFormComponent implements OnInit {
  @Output() login: EventEmitter<LoginModel> = new EventEmitter();

  loginForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }

  enter() {
    validateFormFields(this.loginForm);

    if (!this.loginForm.invalid) {
      const login: LoginModel = { username: this.username.value, password: this.password.value };
      this.login.emit(login);
    }
  }
}
