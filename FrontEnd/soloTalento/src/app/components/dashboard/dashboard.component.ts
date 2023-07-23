import { Component, OnInit } from "@angular/core";
import { CrearArticulo } from "src/app/models/articulos.interface";
import { ArticulosService } from "src/app/services/articulos.service";
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
  // constructor(private user: UsuarioService, private auth: AuthService, private userStore: UserStoreService) { }

  constructor(
    private user: UsuarioService,
    private auth: AuthService,
    private userStore: UserStoreService,
    private articulosService: ArticulosService // Importar el servicio ArticulosService
  ) {}

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
    const nuevoArticulo: CrearArticulo = {
      Codigo: this.dataArticle.codigo,
      Descripcion: this.dataArticle.descripcion,
      Imagen: this.dataArticle.imagen,
      Precio: this.dataArticle.precio,
      Stock: this.dataArticle.stock
    };

    this.articulosService.crearArticulo(nuevoArticulo).subscribe(
      (response) => {
        console.log('Artículo creado exitosamente', response);
      },
      (error) => {
        console.error('Error al crear el artículo:', error);
      }
    );
  }
  saveArticle() {
    const nuevoArticulo: CrearArticulo = {
      Codigo: this.dataArticle.codigo,
      Descripcion: this.dataArticle.descripcion,
      Imagen: this.dataArticle.imagen,
      Precio: this.dataArticle.precio,
      Stock: this.dataArticle.stock
    };

    this.articulosService.crearArticulo(nuevoArticulo).subscribe(
      (response) => {
        console.log('Artículo creado exitosamente', response);
      },
      (error) => {
        console.error('Error al crear el artículo:', error);
      }
    );
  }

  buscarProducto(codigoInput: any) {
    if (codigoInput === "") {
      alert("Necesitamos el código");
    } else {
      const codigo = codigoInput;
  
      this.articulosService.articulo(codigo).subscribe(
        (response) => {
          console.log('Artículo encontrado:', response);
        },
        (error) => {
          console.error('Error al buscar el artículo:', error);
        }
      );
    }
  }

  saveFullOut() {
    console.log('Form Data:', this.dataFullOut);
  }

}
