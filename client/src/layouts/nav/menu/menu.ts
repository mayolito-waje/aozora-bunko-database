import { Component, signal } from '@angular/core';
import { Login } from "../login/login";

@Component({
  selector: 'div[appNavMenu]',
  imports: [Login],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
  host: {
    class: "relative"
  }
})
export class Menu {
  protected showMenu = signal(false);
  protected showLogin = signal(false);

  toggleMenu() {
    this.showMenu.update((show) => !show);
  }

  openLogin() {
    this.showLogin.set(true);
    this.showMenu.set(false);
  }

  closeLogin() {
    this.showLogin.set(false);
  }
}
