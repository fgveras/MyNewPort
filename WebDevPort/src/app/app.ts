import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/components/home.component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  
}
