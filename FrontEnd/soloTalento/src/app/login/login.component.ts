import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  formData = {
    correo: '',
    password: ''
  };

  login(loginForm: any) {
    if (loginForm.valid) {
      console.log('Form Data:', this.formData);
    } else {
      console.log('Form is invalid');
    }
  }
}
