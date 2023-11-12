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

  createNewLancamento(conta: Conta) {
    return this.http.post<Conta[]>(this.baseUrl, conta);
  }

  getLancamentoById(id: number) {
    return this.http.get<Conta>(`${this.baseUrl}/${id}`); 
  }

  updateLancamento(conta: Conta) {
    return this.http.put<Conta[]>(this.baseUrl, conta);
  }

}
