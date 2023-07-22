import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent {
  dataRegister = {
    nombre: '',
    apellido: '',
    direccion: '',
    correo: '',
    password: ''
  };

  saveDataRegister() {
    console.log('Form Data:', this.dataRegister);
  }
}
