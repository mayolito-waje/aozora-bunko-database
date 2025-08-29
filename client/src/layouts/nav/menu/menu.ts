import { Component, inject, signal } from '@angular/core';

import { Login } from "../login/login";
import { AccountService } from '../../../core/services/account-service';
import { NavProfileOverview } from "../nav-profile-overview/nav-profile-overview";
import { DropdownButton } from "../../dropdown-button/dropdown-button";

@Component({
  selector: 'app-menu',
  imports: [Login, NavProfileOverview, DropdownButton],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
  host: {
    class: "relative flex-none"
  }
})
export class Menu {
  protected accountService = inject(AccountService);
  protected showLogin = signal(false);

  openLogin() {
    this.showLogin.set(true);
  }

  closeLogin() {
    this.showLogin.set(false);
  }
}
