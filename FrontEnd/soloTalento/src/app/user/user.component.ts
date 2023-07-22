import { Component } from '@angular/core';
import { Tiendas, Tienda, Product } from '../models/tienda.interface';

interface ProductCarrito extends Product {
  cantidad: number;
}

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass']
})
export class UserComponent {

  proyecto: Tiendas = {
    tiendas: [
      {
        idTienda: 1,
        nombreTienda: "Tienda A",
        productos: [
          {
            id: 566,
            name: "Arroz",
            price: 5400,
            description: "Arroz Roa para toda la familia",
            image: "https://www.vhv.rs/dpng/d/361-3613875_arroz-roa-arroba-arroz-roa-hd-png-download.png",
          },
          {
            id: 322,
            name: "spaghetis",
            price: 8000,
            description: "Doria para servirte",
            image: "https://jumbocolombiaio.vtexassets.com/arquivos/ids/186130/7702085012024-1.jpg?v=637813981192900000",
          },
          {
            id: 888,
            name: "Panela",
            price: 3200,
            description: "Panela sin Azucar",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 789,
            name: "Azucar",
            price: 5000,
            description: "Azucar sin panela",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
        ],
      },
      {
        idTienda: 2,
        nombreTienda: "Tienda B",
        productos: [
          {
            id: 5888,
            name: "Producto B1",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 6612,
            name: "Producto B6",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 10123,
            name: "Producto B4",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 5522,
            name: "Producto B2",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
        ],
      },
      {
        idTienda: 3,
        nombreTienda: "Tienda C",
        productos: [
          {
            id: 9999,
            name: "Producto B1",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 65555,
            name: "Producto B6",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 1112,
            name: "Producto B4",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
          {
            id: 69871,
            name: "Producto B2",
            price: 150,
            description: "Descripción del Producto B1",
            image: "https://mmedia.eluniversal.com/archivos/Panelas%20Papelon%20web%20.jpg",
          },
        ],
      },
    ],
  };
  tiendaSeleccionadaId: number | null = null;
  carrito: ProductCarrito[] = [];
  mostrarCarrito = false;

  carritoVacio = true;

  onTiendaSeleccionadaChange(event: any) {
    if (this.carrito.length > 0) {
      // Si el carrito no está vacío, mostrar una alerta
      const confirmacion = confirm('Si cambia de tienda, se vaciará el carrito. ¿Desea continuar?');
      if (!confirmacion) {
        // Si el usuario cancela la alerta, restaurar la selección anterior del select
        const selectElement = event.target as HTMLSelectElement;
        selectElement.value = this.tiendaSeleccionadaId !== null ? this.tiendaSeleccionadaId.toString() : '';
        return;
      } else {
        // Si el usuario confirma, vaciar el carrito
        this.carrito = [];
        this.carritoVacio = true;
      }
    }

    this.tiendaSeleccionadaId = parseInt(event.target.value, 10);
    this.carritoVacio = this.carrito.length === 0;
  }
  
  agregarAlCarrito(productId: number) {
    const tiendaSeleccionada: Tienda | undefined = this.proyecto.tiendas.find(t => t.idTienda === this.tiendaSeleccionadaId);
    const productToAdd: Product | undefined = tiendaSeleccionada?.productos.find(p => p.id === productId);
    if (productToAdd) {
      const productInCarrito = this.carrito.find(p => p.id === productToAdd.id);
      if (productInCarrito) {
        productInCarrito.cantidad++; // Si el producto ya está en el carrito, aumentamos su cantidad
      } else {
        this.carrito.push({ ...productToAdd, cantidad: 1 }); // Si no está en el carrito, lo agregamos con cantidad 1
      }
    }
    console.log("carrito : ",this.carrito)
  }

  calcularTotalCarrito(): number {
    return this.carrito.reduce((total, item) => total + item.price * item.cantidad, 0);
  }
}




