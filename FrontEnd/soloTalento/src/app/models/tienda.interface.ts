export interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
  image: string;
}

export interface Tienda {
  idTienda: number;
  nombreTienda: string;
  productos: Array<Product>;
}

export interface Tiendas {
  tiendas: Array<Tienda>;
}