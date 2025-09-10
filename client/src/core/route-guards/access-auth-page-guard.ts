import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account-service';

export const accessAuthPageGuard: CanActivateFn = () => {
  const accountService = inject(AccountService);

  return accountService.currentUser() === null;
};
