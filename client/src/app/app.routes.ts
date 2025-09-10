import { Routes } from '@angular/router';

import { Home } from '../features/home/home';
import { Register } from '../features/register/register';
import { LoginPage } from '../features/login-page/login-page';
import { accessAuthPageGuard } from '../core/route-guards/access-auth-page-guard';

export const routes: Routes = [
  { path: '', component: Home },
  {
    path: '',
    canActivate: [accessAuthPageGuard],
    children: [
      { path: 'register', component: Register },
      { path: 'login', component: LoginPage },
    ],
  },
  { path: '**', component: Home },
];
