import { Routes } from '@angular/router';
import { CreateBookComponent } from './pages/book/create-book/create-book.component';
import { HomeComponent } from './pages/home/home.component';
import { UpdateBookComponent } from './pages/book/update-book/update-book.component';
import { DetailsBookComponent } from './pages/book/details-book/details-book.component';

export const routes: Routes = [
  { path: 'create-book', component: CreateBookComponent },
  { path: 'update-book/:id', component: UpdateBookComponent },
  { path: 'details-book/:id', component: DetailsBookComponent },
  { path: '', component: HomeComponent },
];
