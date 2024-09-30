import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorFormComponent } from "../author-form/author-form.component";
import { Author } from '../../../models/author';
import { AuthorService } from '../../../services/author.service';

@Component({
  selector: 'app-update-author',
  standalone: true,
  imports: [AuthorFormComponent],
  templateUrl: './update-author.component.html',
  styleUrl: './update-author.component.scss'
})
export class UpdateAuthorComponent implements OnInit{
  protected author!: Author;

  protected btnAction: string = 'Atualizar';
  protected btnDescription: string = 'Atualizar assuntos';

  constructor(private AuthorService: AuthorService, private router: Router, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.AuthorService.GetAuthorById(id).subscribe(response => {
      this.author = response;
    });
  }

  updateAuthor($event: Author) {
    this.AuthorService.UpdateAuthor($event).subscribe(response => {
      this.router.navigate(['/authors']);
    });
  }
}
