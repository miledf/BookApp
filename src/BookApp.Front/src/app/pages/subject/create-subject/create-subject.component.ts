import { Component } from '@angular/core';
import { SubjectFormComponent } from '../subject-form/subject-form.component';
import { Subject } from '../../../models/subject';

import { Router } from '@angular/router';
import { SubjectService } from '../../../services/subject.service';

@Component({
  selector: 'app-create-subject',
  standalone: true,
  imports: [SubjectFormComponent],
  templateUrl: './create-subject.component.html',
  styleUrl: './create-subject.component.scss',
})
export class CreateSubjectComponent {
  protected btnAction: string = 'Cadastrar';
  protected btnDescription: string = 'Cadastrar Assuntos';

  constructor(private subjectService: SubjectService, private router: Router) { }
  
  createSubject($event: Subject) {
    this.subjectService.CreateSubject($event).subscribe((response) => {
      this.router.navigate(['/subjects']);
    });
  }
}
