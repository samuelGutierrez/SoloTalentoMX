import { Articulos, EnviarArticulo } from "./articulos.interface";

export interface Tienda {
  id: number;
  sucursal: string;
  direccion: string;
  imagen: string;
}

export interface AbastecerTienda {
  idTienda: number;
  articulos: Array<EnviarArticulo>;
}

export interface Tiendas {
  tiendas: Array<Tienda>;
}