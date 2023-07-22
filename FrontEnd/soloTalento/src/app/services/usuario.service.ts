import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";

@Injectable({
    providedIn: 'root',
})
export class UsuarioService {
    private baseUrl: string = `${environment.APIURL}/api/Usuario`;

    constructor(private http: HttpClient, private router: Router) { }

    GetUserRol(idUser: number) {
        return this.http.get<any>(`${this.baseUrl}/ObtenerUsuario/${idUser}`);
    }


} 