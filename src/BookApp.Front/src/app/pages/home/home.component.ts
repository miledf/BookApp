import { Component } from '@angular/core';
import { ListBookComponent } from "../book/list-book/list-book.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ListBookComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  
}
