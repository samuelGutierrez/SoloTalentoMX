import { Component } from '@angular/core';
import { Registro } from '../models/register.interface';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent {

  constructor(
    private registerService: RegisterService, // Importar el servicio ArticulosService
    private router: Router
  ) {}

  dataRegister = {
    nombre: '',
    apellido: '',
    direccion: '',
    correo: '',
    password: ''
  };
  saveRegister() {
    const nuevoArticulo: Registro = {
      nombre: this.dataRegister.nombre,
      apellido: this.dataRegister.apellido,
      direccion: this.dataRegister.direccion,
      correo: this.dataRegister.correo,
      password: this.dataRegister.password
    };

    this.registerService.Registro(nuevoArticulo).subscribe(
      (response) => {
        console.log('Artículo creado exitosamente', response);
        this.router.navigateByUrl('/');
      },
      (error) => {
        console.error('Error al crear el artículo:', error);
      }
    );
  }

}
