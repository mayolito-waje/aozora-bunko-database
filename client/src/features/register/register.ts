import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import type { UserRegister } from '../../types/user-register';
import { AccountService } from '../../core/services/account-service';
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
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

  async registerUser() {
    if (this.credentials().password !== this.credentials().confirmPassword) {
      this.toastService.update('パスワードが合ってません', 'error');
      return;
    }

    this.accountService.register(this.credentials()).subscribe({
      next: (response) => {
        this.toastService.update('新しいアカウントを作りました', 'success');
        console.log(response);

        this.router.navigateByUrl('/');
      },
      error: (error: Error) => this.toastService.update(error.message, 'error'),
    });
  }
}
