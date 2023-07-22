import { Component, OnInit } from "@angular/core";
import { AuthService } from "src/app/services/auth.service";
import { UserStoreService } from "src/app/services/user-store.service";
import { UsuarioService } from "src/app/services/usuario.service";

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
    public users: any = [];
    public role!: 1;
    // public role!: number;

    public fullName: string = "";
    constructor(private user: UsuarioService, private auth: AuthService,private userStore:UserStoreService) { }

    ngOnInit() {

        this.userStore.getRoleFromStore()
        .subscribe(val=>{
          const roleFromToken = this.auth.getRoleFromToken();
          this.role = val || roleFromToken;
        })
      }

      getRoleText() {
        return this.role === 1 ? 'Admin' : 'User';
    }

    logout() {
        this.auth.signOut();
    }
}