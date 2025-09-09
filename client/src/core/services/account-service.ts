import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { catchError, tap, throwError } from 'rxjs';

import type { User, UserLogin } from '../../types/user';
import { ToastService } from './toast-service';
import { UserRegister } from '../../types/user-register';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  private toastService = inject(ToastService);
  currentUser = signal<User | null>(null);

  private baseUrl = 'https://localhost:5001/api/users/';

  login(credentials: UserLogin) {
    return this.http.post<User>(this.baseUrl + 'login', credentials).pipe(
      tap((user) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }

  register(credentials: UserRegister) {
    return this.http
      .post<User>(this.baseUrl, {
        email: credentials.email,
        username: credentials.username,
        password: credentials.password,
      })
      .pipe(
        tap((user) => {
          localStorage.setItem('user', JSON.stringify(user));
          if (user) this.currentUser.set(user);
        })
      );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);

    this.toastService.update('ログアウトしました', 'warning');
  }
}
