import { Component, EventEmitter, inject,  OnInit, Output, Input, input } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Subject } from '../../../models/subject';

@Component({
  selector: 'app-subject-form',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './subject-form.component.html',
  styleUrl: './subject-form.component.scss',
})
export class SubjectFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Subject>();

  @Input() subject: Subject | null = null;
  @Input() btnAction!: string;
  @Input() btnDescription!: string;

  private formBuilder = inject(FormBuilder);

  protected form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
      description: ['', [Validators.required, Validators.maxLength(20)]],
    });

    if (this.subject) {
      this.form.setValue(this.subject);
    }
  }

  submit() {
    this.onSubmit.emit(this.form.value);
    this.form.controls  
  }

  get description(){    return this.form.get('description') }
}
