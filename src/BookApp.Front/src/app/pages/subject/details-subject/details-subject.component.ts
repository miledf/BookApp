import { Component, numberAttribute, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SubjectService } from '../../../services/subject.service';
import { Subject } from '../../../models/subject';

@Component({
  selector: 'app-details-subject',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './details-subject.component.html',
  styleUrl: './details-subject.component.scss'
})
export class DetailsSubjectComponent implements OnInit {

  protected subject!: Subject;

  constructor(private subjectService: SubjectService, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.subjectService.GetSubjectById(id).subscribe(response => {
      this.subject = response;
    })
  }

}
