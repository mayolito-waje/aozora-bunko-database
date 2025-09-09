import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-dropdown-button',
  imports: [],
  templateUrl: './dropdown-button.html',
  styleUrl: './dropdown-button.css',
  host: {
    class: "relative",
  }
})
export class DropdownButton {
  protected showMenu = signal(false);

  toggleMenu() {
    this.showMenu.update((show) => !show);
  }

  closeMenu() {
    this.showMenu.set(false);
  }
}
