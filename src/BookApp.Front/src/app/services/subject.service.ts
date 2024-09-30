import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { Subject } from '../models/subject';

@Injectable({
  providedIn: 'root',
})
export class SubjectService {
  apiUrl = `${environment.UrlApi}api/subjects`;
  constructor(private http: HttpClient) {}

  GetSubjects(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.apiUrl);
  }

  GetSubjectById(id: Number): Observable<Subject> {
    return this.http.get<Subject>(`${this.apiUrl}/${id}`);
  }

  DeleteSubject(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }

  CreateSubject(request: Subject) {
    return this.http.post<any>(`${this.apiUrl}`, request);
  }

  UpdateSubject(request: Subject) {
    return this.http.put<any>(`${this.apiUrl}/${request.id}`, request);
  }
}
