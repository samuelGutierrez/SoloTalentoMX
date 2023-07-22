import { Component } from '@angular/core';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent{


  constructor(
    private loginService: LoginService,
  ){
    
  }

  formData = {
    correo: '',
    password: ''
  };

  // login(loginForm: any) {
  //   if (loginForm.valid) {
  //     console.log('Form Data:', this.formData);
  //   } else {
  //     console.log('Form is invalid');
  //   }
  // }

  login(loginForm: any){
    this.loginService.postLogin(loginForm.value).subscribe(res =>{
      if(!res){
        alert("Usuario y/o contraseña incorrectos")
      }else{
        alert("ingresado correctaemente")
      }
        
    })
  }

}
