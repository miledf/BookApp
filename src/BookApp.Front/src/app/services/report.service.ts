import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ReportService {
  apiUrl = `${environment.UrlApi}api/reports`;
  constructor(private http: HttpClient) {}

  Download(): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Accept', 'application/pdf')
    return this.http.get<any>(`${this.apiUrl}/download`);
  }
}
