import { Injectable } from "@angular/core";
import { environment } from "src/enviroment";
import { HttpClient } from '@angular/common/http';
import { LoginInterface } from "../models/login.interface";

@Injectable({
    providedIn: 'root'
})

export class LoginService {
    url: string = `${environment.APIURL}/api/Authentication/Login`;

    constructor(private http: HttpClient) { }

    postLogin(params: LoginInterface){
        return this.http.post<any>(`${this.url}`,params)
    }
}