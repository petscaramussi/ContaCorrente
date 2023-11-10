import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Conta } from './models/conta';

@Injectable({
  providedIn: 'root'
})
export class ContaService {

  baseUrl: string = 'https://localhost:7003/api/Conta';

  constructor(private http: HttpClient) { }

  getLancamentos() {
    return this.http.get<Conta[]>(this.baseUrl);
    
  }
}
