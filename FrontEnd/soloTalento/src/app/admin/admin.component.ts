import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.sass']
})
export class AdminComponent {
  showModalCreateStore = false;
  showModalCreateProduct = false;
  showModalFillOut = false;

  dataStore = {
    sucursal: '',
    direccion: '',
    imagen: ''
  };
  dataProduct = {
    codigo: '',
    descripcion: '',
    imagen: '',
    precio: 0,
    stock: 0
  };
  dataFullOut = {
    idTienda: '',
    idArticulo: '',
    stock: 0
  };

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

  saveStore(storeForm: any) {
    if (storeForm.valid) {
      console.log('Form Data:', this.dataStore);
      // Perform logic to save the data, e.g., send it to the server.
    } else {
      console.log('Form is invalid. Please fill in all required fields.');
    }
  }

  saveProduct(productForm: any) {
    if (productForm.valid) {
      console.log('Form Data:', this.dataProduct);
      // Perform logic to save the data, e.g., send it to the server.
    } else {
      console.log('Form is invalid. Please fill in all required fields.');
    }
  }

  saveFullOut(fullOutForm: any) {
    if (fullOutForm.valid) {
      console.log('Form Data:', this.dataFullOut);
      // Perform logic to save the data, e.g., send it to the server.
    } else {
      console.log('Form is invalid. Please fill in all required fields.');
    }
  }
}
