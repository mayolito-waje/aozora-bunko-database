import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthWrapper } from "../misc/auth-wrapper/auth-wrapper";
import { UserLogin } from '../../types/user';
import { AccountService } from '../../core/services/account-service';
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-login-page',
  imports: [AuthWrapper, FormsModule],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  private accountService = inject(AccountService);
  private toastService = inject(ToastService);
  private router = inject(Router);

  protected credentials = signal<UserLogin>({
    email: '',
    password: '',
  });

  login() {
    this.accountService.login(this.credentials()).subscribe({
      next: () => {
        this.router.navigateByUrl('/');
        this.toastService.update('ログインしました', 'success');
      },
      error: (error: Error) => this.toastService.update(error.message, 'error'),
    });
  }
}
