import { Component } from '@angular/core';

import { Menu } from "./menu/menu";

@Component({
  selector: 'app-nav',
  imports: [Menu],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {

}
