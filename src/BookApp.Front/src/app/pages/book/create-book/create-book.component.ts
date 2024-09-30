import { Component } from '@angular/core';
import { BookFormComponent } from '../book-form/book-form.component';
import { Book } from '../../../models/book';
import { BookService } from '../../../services/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-book',
  standalone: true,
  imports: [BookFormComponent],
  templateUrl: './create-book.component.html',
  styleUrl: './create-book.component.scss',
})
export class CreateBookComponent {
  protected btnAction: string = 'Cadastrar';
  protected btnDescription: string = 'Cadastrar Livros';

  constructor(private bookservice: BookService, private router: Router) {}
  createBook($event: Book) {
    this.bookservice.CreateBook($event).subscribe((response) => {
      this.router.navigate(['/']);
    });
  }
}
