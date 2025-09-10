import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import type { UserRegister } from '../../types/user-register';
import { AccountService } from '../../core/services/account-service';
import { ToastService } from '../../core/services/toast-service';
import { AuthWrapper } from "../misc/auth-wrapper/auth-wrapper";

@Component({
  selector: 'app-register',
  imports: [FormsModule, AuthWrapper],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  private accountService = inject(AccountService);
  private toastService = inject(ToastService);
  private router = inject(Router);

  protected credentials = signal<UserRegister>({
    email: '',
    username: '',
    password: '',
    confirmPassword: '',
  });

  registerUser() {
    if (this.credentials().password !== this.credentials().confirmPassword) {
      this.toastService.update('パスワードが合ってません', 'error');
      return;
    }

    this.accountService.register(this.credentials()).subscribe({
      next: () => {
        this.router.navigateByUrl('/');
        this.toastService.update('新しいアカウントを作りました', 'success');
      },
      error: (error: Error) => this.toastService.update(error.message, 'error'),
    });
  }
}
