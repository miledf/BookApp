import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { Author } from '../models/author';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  apiUrl = `${environment.UrlApi}api/authors`;
  constructor(private http: HttpClient) {}

  GetAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.apiUrl);
  }

  GetAuthorById(id: Number): Observable<Author> {
    return this.http.get<Author>(`${this.apiUrl}/${id}`);
  }

  DeleteAuthor(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }

  CreateAuthor(request: Author) {
    return this.http.post<any>(`${this.apiUrl}`, request);
  }

  UpdateAuthor(request: Author) {
    return this.http.put<any>(`${this.apiUrl}/${request.id}`, request);
  }
}
