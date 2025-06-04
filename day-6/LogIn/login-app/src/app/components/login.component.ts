import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  formValid: boolean = true;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      emailAddress: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  get emailAddress() {
    return this.loginForm.get('emailAddress')!;
  }

  get password() {
    return this.loginForm.get('password')!;
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const { emailAddress, password } = this.loginForm.value;

      this.authService.loginUser({ EmailAddress: emailAddress, Password: password })
        .subscribe({
          next: (res: any) => {
            if (res.result === 1 && res.data.message === "Login Successfully") {
              this.authService.setToken(res.data.data);
              const user = this.authService.decodedToken();
              this.authService.setCurrentUser(user);
              this.router.navigate(user.userType === 'admin' ? ['admin/dashboard'] : ['home']);
            } else {
              alert(res.message || "Login failed.");
            }
          },
          error: () => {
            alert("Login failed. Please try again.");
          }
        });
    } else {
      this.formValid = false;
    }
  }
}