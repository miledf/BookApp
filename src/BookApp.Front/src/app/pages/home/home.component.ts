import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Observable } from 'rxjs';
import { Book } from '../../models/book';
import { RouterLink } from '@angular/router';
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
