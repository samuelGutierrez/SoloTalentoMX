import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";

@Injectable({
    providedIn: 'root'
})
export class ArticulosService {
    private baseUrl: string = `${environment.APIURL}/api/Articulos`;

    constructor(private http: HttpClient, private router: Router) { }

    listArticulos() {
        return this.http.get<any>(`${this.baseUrl}/ListaArticulos`);
    }

    articulo(id: number) {
        return this.http.get<any>(`${this.baseUrl}/ArticuloxId/${id}`);
    }
}