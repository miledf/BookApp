import { Routes } from '@angular/router';
import { CreateBookComponent } from './pages/book/create-book/create-book.component';
import { HomeComponent } from './pages/home/home.component';
import { UpdateBookComponent } from './pages/book/update-book/update-book.component';
import { DetailsBookComponent } from './pages/book/details-book/details-book.component';
import { ListSubjectComponent } from './pages/subject/list-subject/list-subject.component';
import { ListBookComponent } from './pages/book/list-book/list-book.component';
import { CreateSubjectComponent } from './pages/subject/create-subject/create-subject.component';
import { UpdateSubjectComponent } from './pages/subject/update-subject/update-subject.component';
import { DetailsSubjectComponent } from './pages/subject/details-subject/details-subject.component';
import { ListAuthorComponent } from './pages/author/list-author/list-author.component';
import { CreateAuthorComponent } from './pages/author/create-author/create-author.component';
import { UpdateAuthorComponent } from './pages/author/update-author/update-author.component';
import { DetailsAuthorComponent } from './pages/author/details-author/details-author.component';

export const routes: Routes = [
  { path: 'create-book', component: CreateBookComponent },
  { path: 'update-book/:id', component: UpdateBookComponent },
  { path: 'details-book/:id', component: DetailsBookComponent },

  { path: 'create-subject', component: CreateSubjectComponent },
  { path: 'update-subject/:id', component: UpdateSubjectComponent },
  { path: 'details-subject/:id', component: DetailsSubjectComponent },

  { path: 'create-author', component: CreateAuthorComponent },
  { path: 'update-author/:id', component: UpdateAuthorComponent },
  { path: 'details-author/:id', component: DetailsAuthorComponent },


  { path: 'subjects', component: ListSubjectComponent },
  { path: 'authors', component: ListAuthorComponent },
  // { path: 'reports', component: ListSubjectComponent },
  { path: 'books', component: ListBookComponent },
  { path: '', component: HomeComponent },
];
