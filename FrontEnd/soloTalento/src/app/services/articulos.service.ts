import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";
import { CrearArticulo, ActualizarArticulo } from "../models/articulos.interface";


@Injectable({
    providedIn: 'root'
})
export class ArticulosService {
    private baseUrl: string = `${environment.APIURL}/api/Articulos`;
    private token: string | null;

    constructor(private http: HttpClient, private router: Router) {
        this.token = localStorage.getItem('token');
    }



    listArticulos() {
        return this.http.get<any>(`${this.baseUrl}/ListaArticulos`);
    }

    articulo(id: number) {
        return this.http.get<any>(`${this.baseUrl}/ArticuloxId/${id}`);
    }

    crearArticulo(post: CrearArticulo) {
        const headers = new HttpHeaders({
            'Authorization': 'Bearer ' + this.token
        });
        return this.http.post<any>(`${this.baseUrl}/RegistrarArticulo`, post, { headers });
    }

    actualizarArticulo(idArticulo: number, put: ActualizarArticulo) {
        return this.http.put<any>(`${this.baseUrl}/ActualizarArticulo/${idArticulo}`, put);
    }

    eliminarArticulo(idArticulo: number) {
        return this.http.delete<any>(`${this.baseUrl}/EliminarArticulo/${idArticulo}`);
    }
}