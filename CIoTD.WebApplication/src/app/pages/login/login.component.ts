import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginResponse } from '../../../@types/auth/login';
import { baseApi } from '../../../config/baseApi';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto = { username: '', password: '' };
  isLoading = false;
  error = '';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.router.navigate(['/devices']);
    }
  }

  async login(event: Event) {
    event.preventDefault();
    this.isLoading = true;
    this.error = '';
    try {
      const result: LoginResponse = await firstValueFrom(this.http.post<LoginResponse>(`${baseApi.url}/auth/login`, this.loginDto));
      if (result.token) {
        localStorage.setItem('token', result.token);
        console.log(result.token)
        this.router.navigate(['/devices']);
      }
    } catch (error: any) {
      this.isLoading = false;
      this.error = "Username or password is incorrect";
    } finally {
      this.isLoading = false;
    }
  }
}
