import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginResponse } from '../../../@types/login';
import { baseApi } from '../../../config/baseApi';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto = { username: '', password: '' };

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.router.navigate(['/dashboard']);
    }
  }

  login() {
    this.http.post<LoginResponse>(`${baseApi.url}/auth/login`, this.loginDto,).subscribe(
      (result: LoginResponse) => {
        if (result.token) {
          this.router.navigate(['/dashboard']);
          localStorage.setItem('token', result.token);
        }
      },
      (error) => {
      }
    );
  }
}
