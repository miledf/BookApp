import { Component, numberAttribute, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { BookService } from '../../../services/book.service';
import { Book } from '../../../models/book';

@Component({
  selector: 'app-details-book',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './details-book.component.html',
  styleUrl: './details-book.component.scss'
})
export class DetailsBookComponent implements OnInit {

  protected book!: Book;

  constructor(private bookService: BookService, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.bookService.GetBookById(id).subscribe(response => {
      this.book = response;
    })
  }

}
