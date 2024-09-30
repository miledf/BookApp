import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiUrl = `${environment.UrlApi}api/books`;
  constructor(private http: HttpClient) {}

  GetBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  GetBookById(id: Number): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }

  DeleteBook(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  CreateBook(book: Book) {
    return this.http.post(`${this.apiUrl}`, book);
  }

  UpdateBook(book: Book) {
    return this.http.put(`${this.apiUrl}/${book.id}`, book);
  }
}
