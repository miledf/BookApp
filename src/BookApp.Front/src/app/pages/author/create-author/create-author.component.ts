import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorService } from '../../../services/author.service';
import { Author } from '../../../models/author';
import { AuthorFormComponent } from '../author-form/author-form.component';

@Component({
  selector: 'app-create-subject',
  standalone: true,
  imports: [AuthorFormComponent],
  templateUrl: './create-author.component.html',
  styleUrl: './create-author.component.scss',
})
export class CreateAuthorComponent {
  protected btnAction: string = 'Cadastrar';
  protected btnDescription: string = 'Cadastrar Autores';

  constructor(private authorService: AuthorService, private router: Router) { }
  
  createAuthor($event: Author) {
    this.authorService.CreateAuthor($event).subscribe((response) => {
      this.router.navigate(['/authors']);
    });
  }
}
