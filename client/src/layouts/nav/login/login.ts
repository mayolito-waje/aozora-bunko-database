import { Component, inject, output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

import { UserLogin } from '../../../types/user';
import { ToastService } from '../../../core/toast-service';
import { AccountService } from '../../../core/account-service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  protected toastService = inject(ToastService);
  private accountService = inject(AccountService);

  protected credentials: UserLogin = { email: '', password: '' };
  protected closeLoginTemplate = output<void>();

  onLogin() {
    this.accountService.login(this.credentials).subscribe({
      next: (response) => {
        this.toastService.update('ログインしました', 'success');
        console.log(response);
        this.closeLoginTemplate.emit();
      },
      error: (error: Error) => this.toastService.update(error.message, 'error'),
    });
  }
}
