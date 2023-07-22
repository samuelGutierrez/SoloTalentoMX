import { Component, OnInit } from "@angular/core";
import { AuthService } from "src/app/services/auth.service";
import { UserStoreService } from "src/app/services/user-store.service";
import { UsuarioService } from "src/app/services/usuario.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
  
})
export class DashboardComponent implements OnInit {
  showModalCreateStore = false;
  showModalCreateProduct = false;
  showModalFillOut = false;
  public users: any = [];
  public role!: string;
  public dataLoaded: boolean = false;

  public fullName: string = "";
  constructor(private user: UsuarioService, private auth: AuthService, private userStore: UserStoreService) { }

  dataStore = {
    sucursal: '',
    direccion: '',
    imagen: ''
  };
  dataArticle = {
    codigo: '',
    descripcion: '',
    imagen: '',
    precio: 0,
    stock: 0
  };
  dataFullOut = {
    nombre: '',
    apellido: '',
    direccion: '',
    correo: '',
    password: ''
  };



  ngOnInit() {
    this.userStore.getRoleFromStore().subscribe(val => {
        const roleFromToken = this.auth.getRoleFromToken();
        this.role = val || roleFromToken;
        this.dataLoaded = true;
    });
}

  logout() {
    this.auth.signOut();
  }

  openCreateStore() {
    this.showModalCreateStore = true;
    this.showModalCreateProduct = false;
    this.showModalFillOut = false;
    
  }
  openModalCreateProduct() {
    this.showModalCreateProduct = true;
    this.showModalFillOut = false;
    this.showModalCreateStore = false;
  }
  
  openModal() {
    this.showModalFillOut = true;
    this.showModalCreateProduct = false;
    this.showModalCreateStore = false; 
  }
  closeModal() {
    this.showModalCreateProduct = false;
    this.showModalFillOut = false;
    this.showModalCreateStore = false;
  }

  saveDataTienda() {
    console.log('Form Data:', this.dataStore);
  }
  saveArticle() {
    console.log('Form Data:', this.dataArticle);
  }
  saveFullOut() {
    console.log('Form Data:', this.dataFullOut);
  }

}
