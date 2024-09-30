import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../../models/book';
import { BookFormComponent } from "../book-form/book-form.component";

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [BookFormComponent],
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.scss'
})
export class UpdateBookComponent implements OnInit{
  protected book!: Book;

  protected btnAction: string = 'Atualizar';
  protected btnDescription: string = 'Atualizar Livros ';

  constructor(private bookService: BookService, private router: Router, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.bookService.GetBookById(id).subscribe(response => {
      this.book = response;
    });
  }

  updateBook($event: Book) {
    this.bookService.UpdateBook($event).subscribe(response => {
      this.router.navigate(['/']);
    });
  }
}
