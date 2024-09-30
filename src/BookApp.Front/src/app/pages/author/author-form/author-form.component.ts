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
import { Author } from '../../../models/author';

@Component({
  selector: 'app-author-form',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './author-form.component.html',
  styleUrl: './author-form.component.scss',
})
export class AuthorFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Author>();

  @Input() author: Author | null = null;
  @Input() btnAction!: string;
  @Input() btnDescription!: string;

  private formBuilder = inject(FormBuilder);

  protected form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
      name: ['', [Validators.required, Validators.maxLength(40)]],
    });

    if (this.author) {
      this.form.setValue(this.author);
    }
  }

  submit() {
    this.onSubmit.emit(this.form.value);
    this.form.controls  
  }

  get name(){    return this.form.get('name') }
}
