import { Component, inject, output, signal, ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';

import { Login } from "../login/login";
import { AccountService } from '../../../core/services/account-service';
import { NavProfileOverview } from "../nav-profile-overview/nav-profile-overview";
import { DropdownButton } from "../../dropdown-button/dropdown-button";

@Component({
  selector: 'app-menu',
  imports: [Login, NavProfileOverview, DropdownButton, RouterLink],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
  host: {
    class: "relative flex-none"
  }
})
export class Menu {
  @ViewChild('dropdown') dropdownButton!: DropdownButton;
  protected accountService = inject(AccountService);
  protected showLogin = signal(false);

  openLogin() {
    this.showLogin.set(true);
    this.dropdownButton.closeMenu();
  }

  closeLogin() {
    this.showLogin.set(false);
  }

  onCloseMenu() {
    this.dropdownButton.closeMenu();
  }
}
