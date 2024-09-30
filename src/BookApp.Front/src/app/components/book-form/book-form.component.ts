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
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-form',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.scss',
})
export class BookFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Book>();

  @Input() book: Book | null = null;
  @Input() btnAction!: string;
  @Input() btnDescription!: string;

  private formBuilder = inject(FormBuilder);

  protected form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
      title: ['', [Validators.required, Validators.maxLength(40)]],
      publisher: ['', [Validators.required ,Validators.maxLength(40)]],
      edition: [null, [Validators.required, Validators.min(1)]],
      yearPublication: ['', [Validators.required, Validators.maxLength(4)]],
    });

    if (this.book) {
      this.form.setValue(this.book);
    }
  }

  submit() {
    this.onSubmit.emit(this.form.value);
    this.form.controls  
  }

  get title(){    return this.form.get('title') }
  get publisher() {    return this.form.get('publisher')  }
  get edition() {    return this.form.get('edition')  }
  get yearPublication() {    return this.form.get('yearPublication')  }
}
