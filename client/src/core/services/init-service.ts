import { inject, Injectable } from '@angular/core';
import { AccountService } from './account-service';
import { Observable, of } from 'rxjs';

import { User } from '../../types/user';
import { ToastService } from './toast-service';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private accountService = inject(AccountService);
  private toastService = inject(ToastService);

  init(): Observable<null> {
    const userString = localStorage.getItem('user');
    if (!userString) return of(null);

    const user: User = JSON.parse(userString);
    this.accountService.currentUser.set(user);
    this.toastService.update('ログインしました', 'success');

    return of(null);
  }
}
