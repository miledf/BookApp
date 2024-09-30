import { Component, numberAttribute, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { AuthorService } from '../../../services/author.service';
import { Author } from '../../../models/author';

@Component({
  selector: 'app-details-author',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './details-author.component.html',
  styleUrl: './details-author.component.scss'
})
export class DetailsAuthorComponent implements OnInit {

  protected author!: Author;

  constructor(private authorService: AuthorService, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.authorService.GetAuthorById(id).subscribe(response => {
      this.author = response;
    })
  }

}
