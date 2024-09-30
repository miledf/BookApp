import { Component } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { Book } from '../../../models/book';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-list-book',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './list-book.component.html',
  styleUrl: './list-book.component.scss'
})
export class ListBookComponent {
  books: Book[] = [];
  generalBooks: Book[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.bookService.GetBooks().subscribe((response) => {
      this.books = response;
      this.generalBooks = response;
    });
  }

  search($event: Event) {
    const target = $event.target as HTMLInputElement;

    const value = target.value.toLowerCase();

    this.books = this.generalBooks.filter((book) => {
      return book.title.toLowerCase().includes(value);
    });
  }

  remove(id: number) {
    this.bookService.DeleteBook(id).subscribe((response) => {
      window.location.reload();
    });
  }
}
