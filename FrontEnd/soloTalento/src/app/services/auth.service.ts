import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/enviroment";
import { HttpClient } from "@angular/common/http";
import { LoginInterface } from "../models/login.interface";
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private baseUrl: string = `${environment.APIURL}/api/Authentication`;
    private userPayload: any;
    constructor(private http: HttpClient, private router: Router) {
        this.userPayload = this.decodedToken();
    }

    signIn(loginObj: LoginInterface) {
        return this.http.post<any>(`${this.baseUrl}/Login`, loginObj)
    }

    isLoggedIn(): boolean {
        return !!localStorage.getItem('token')
    }

    signOut() {
        localStorage.clear();
        this.router.navigate(['login'])
    }

    storeToken(tokenValue: string) {
        localStorage.setItem('token', tokenValue)
    }
    storeRefreshToken(tokenValue: string) {
        localStorage.setItem('refreshToken', tokenValue)
    }

    getToken() {
        return localStorage.getItem('token')
    }

    decodedToken() {
        const jwtHelper = new JwtHelperService();
        const token = this.getToken()!;
        console.log(jwtHelper.decodeToken(token))
        return jwtHelper.decodeToken(token)
    }

    getRoleFromToken() {
        if (this.userPayload)
            return this.userPayload.role;
    }
}