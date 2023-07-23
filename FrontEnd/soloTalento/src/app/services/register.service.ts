import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";
import { Registro } from "../models/register.interface";

@Injectable({
    providedIn: 'root',
})
export class RegisterService {
    private baseUrl: string = `${environment.APIURL}/api/Cliente`;

    constructor(private http: HttpClient, private router: Router) { }

    Registro(registro: Registro) {
        return this.http.post<any>(`${this.baseUrl}/RegisterUser`, registro);
    }
}