import { Component } from '@angular/core';
import { SubjectService } from '../../../services/subject.service';
import { Subject } from '../../../models/subject';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-list-subject',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './list-subject.component.html',
  styleUrl: './list-subject.component.scss'
})
export class ListSubjectComponent {
  subjects: Subject[] = [];
  generalsubjects: Subject[] = [];

  constructor(private subjectService: SubjectService) {}

  ngOnInit(): void {
    this.subjectService.GetSubjects().subscribe((response) => {
      this.subjects = response;
      this.generalsubjects = response;
    });
  }

  search($event: Event) {
    const target = $event.target as HTMLInputElement;

    const value = target.value.toLowerCase();

    this.subjects = this.generalsubjects.filter((subject) => {
      return subject.description.toLowerCase().includes(value);
    });
  }

  remove(id: number) {
    this.subjectService.DeleteSubject(id).subscribe((response) => {
      window.location.reload();
    });
  }
}
