import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";
import { HttpClient } from "@angular/common/http";
import { LoginInterface } from "../models/login.interface";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private baseUrl: string = `${environment.APIURL}/api/Authentication`;

    constructor(private http: HttpClient, private router: Router) { }

    signIn(loginObj: LoginInterface) {
        return this.http.post<any>(`${this.baseUrl}/Login`, loginObj)
    }

    isLoggedIn(): boolean {
        return !!localStorage.getItem('token')
    }
}