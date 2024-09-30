import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectFormComponent } from "../subject-form/subject-form.component";
import { Subject } from '../../../models/subject';
import { SubjectService } from '../../../services/subject.service';

@Component({
  selector: 'app-update-Subject',
  standalone: true,
  imports: [SubjectFormComponent],
  templateUrl: './update-subject.component.html',
  styleUrl: './update-Subject.component.scss'
})
export class UpdateSubjectComponent implements OnInit{
  protected subject!: Subject;

  protected btnAction: string = 'Atualizar';
  protected btnDescription: string = 'Atualizar assuntos';

  constructor(private SubjectService: SubjectService, private router: Router, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.SubjectService.GetSubjectById(id).subscribe(response => {
      this.subject = response;
    });
  }

  updateSubject($event: Subject) {
    this.SubjectService.UpdateSubject($event).subscribe(response => {
      this.router.navigate(['/']);
    });
  }
}
