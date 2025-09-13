import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Nav } from '../layouts/nav/nav';
import { Toast } from '../layouts/toast/toast';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Nav, Toast],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
