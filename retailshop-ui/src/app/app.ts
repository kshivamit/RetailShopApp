import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Homecomponent } from './homecomponent/homecomponent';

@Component({
  selector: 'app-root',
  imports: [Homecomponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // protected readonly title = signal('retailshop-ui');
}
