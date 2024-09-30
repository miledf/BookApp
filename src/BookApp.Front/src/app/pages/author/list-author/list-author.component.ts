import { Component } from '@angular/core';
import { AuthorService } from '../../../services/author.service';
import { Author } from '../../../models/author';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-list-author',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './list-author.component.html',
  styleUrl: './list-author.component.scss'
})
export class ListAuthorComponent {
  authors: Author[] = [];
  generalAuthors: Author[] = [];

  constructor(private authorService: AuthorService) {}

  ngOnInit(): void {
    this.authorService.GetAuthors().subscribe((response) => {
      this.authors = response;
      this.generalAuthors = response;
    });
  }

  search($event: Event) {
    const target = $event.target as HTMLInputElement;

    const value = target.value.toLowerCase();

    this.authors = this.generalAuthors.filter((author) => {
      return author.name.toLowerCase().includes(value);
    });
  }

  remove(id: number) {
    this.authorService.DeleteAuthor(id).subscribe((response) => {
      window.location.reload();
    });
  }
}
