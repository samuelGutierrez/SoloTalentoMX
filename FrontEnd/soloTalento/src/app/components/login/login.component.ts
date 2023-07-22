import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import ValidateForm from "src/app/helpers/validationform";
import { AuthService } from "src/app/services/auth.service";
import { NgToastService } from 'ng-angular-popup';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    public loginForm!: FormGroup;
    type: string = 'password';
    isText: boolean = false;
    eyeIcon: string = 'fa-eye-slash';
    constructor(
        private fb: FormBuilder,
        private auth: AuthService,
        private router: Router,
        private toast: NgToastService,
        //   private userStore: UserStoreService
    ) { }

    ngOnInit() {
        this.loginForm = this.fb.group({
            correo: ['', Validators.required],
            password: ['', Validators.required],
        });
    }

    hideShowPass() {
        this.isText = !this.isText;
        this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
        this.isText ? (this.type = 'text') : (this.type = 'password');
      }

    onSubmit() {
        if (this.loginForm.valid) {
          console.log(this.loginForm.value);
          this.auth.signIn(this.loginForm.value).subscribe({
            next: (res) => {
              console.log(res.message);
              this.loginForm.reset();;
              this.toast.success({detail:"SUCCESS", summary:res.message, duration: 5000});
              this.router.navigate(['dashboard'])
            },
            error: (err) => {
              this.toast.error({detail:"ERROR", summary:"Something when wrong!", duration: 5000});
            },
          });
        } else {
          ValidateForm.validateAllFormFields(this.loginForm);
        }
      }
}