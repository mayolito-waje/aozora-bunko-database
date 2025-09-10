import { Component, inject, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { UserLogin } from '../../../types/user';
import { ToastService } from '../../../core/services/toast-service';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  protected toastService = inject(ToastService);
  private accountService = inject(AccountService);
  private router = inject(Router);

  protected credentials: UserLogin = { email: '', password: '' };
  protected closeLoginTemplate = output<void>();

  onLogin() {
    this.accountService.login(this.credentials).subscribe({
      next: () => {
        this.router.navigateByUrl('/');
        this.toastService.update('ログインしました', 'success');
        this.closeLoginTemplate.emit();
      },
      error: (error: Error) => this.toastService.update(error.message, 'error'),
    });
  }

  onCloseLogin() {
    this.closeLoginTemplate.emit();
  }
}
