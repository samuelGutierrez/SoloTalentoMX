export interface Articulos{
 id:number;
 Codigo:string;
 Descripcion:string;
 Imagen:string;
 Precio:BigInt;
 Stock:number;   
}

export interface EnviarArticulo{
    idArticulo:number;
    stock:number;
}
