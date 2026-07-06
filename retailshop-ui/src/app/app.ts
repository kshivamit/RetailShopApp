import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./navbarcomponent/navbarcomponent";
import { Footercomponent } from './footercomponent/footercomponent';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, Footercomponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // protected readonly title = signal('retailshop-ui');
}
