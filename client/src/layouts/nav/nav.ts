import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

import { Menu } from "./menu/menu";

@Component({
  selector: 'app-nav',
  imports: [Menu, RouterLink],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {

}
