import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Nav } from "../layouts/nav/nav";
import { Toast } from "../layouts/toast/toast";
import { User } from '../types/user';
import { AccountService } from '../core/services/account-service';
import { ToastService } from '../core/services/toast-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Nav, Toast],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected readonly title = signal('client');
  private toastService = inject(ToastService);
  private accountService = inject(AccountService);

  async ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;

    const user: User = JSON.parse(userString);
    this.accountService.currentUser.set(user);
    this.toastService.update("ログインしました", "success");
  }
}
