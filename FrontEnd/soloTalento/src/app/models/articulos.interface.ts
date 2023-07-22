export interface Articulos {
    id: number;
    Codigo: string;
    Descripcion: string;
    Imagen: string;
    Precio: BigInt;
    Stock: number;
}

export interface EnviarArticulo {
    idArticulo: number;
    stock: number;
}

export interface CrearArticulo {
    Codigo: string;
    Descripcion: string;
    Imagen: string;
    Precio: BigInt;
    Stock: number;
}

export interface ActualizarArticulo{
    Descripcion: string;
    Imagen: string;
    Precio: BigInt;
    Stock: number;
}
