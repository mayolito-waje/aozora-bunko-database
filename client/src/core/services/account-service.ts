import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { catchError, tap, throwError } from 'rxjs';

import type { User, UserLogin } from '../../types/user';
import { ToastService } from './toast-service';

@Injectable({
  providedIn: 'root'
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
      }),
      catchError((error: HttpErrorResponse) => {
        console.log(error);

        if (error.status === 401)
          return throwError(() => new Error('メールアドレスまたはパスワードが間違ってます'));

        return throwError(() => new Error('エラーが発生しました'));
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);

    this.toastService.update('ログアウトしました', 'warning');
  }
}
