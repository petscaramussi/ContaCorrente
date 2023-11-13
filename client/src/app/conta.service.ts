import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Conta } from './models/conta';

@Injectable({
  providedIn: 'root'
})

export class ContaService {

  baseUrl: string = 'https://localhost:7003/api/Conta';

  constructor(private http: HttpClient) { }

  getAllLancamentos() {
    return this.http.get<Conta[]>(this.baseUrl); 
  }

  getLancamentosLastTwoDays() {
    return this.http.get<Conta[]>(`${this.baseUrl}/Filter/2`); 
  }

  getLancamentosLastThirtyDays() {
    return this.http.get<Conta[]>(`${this.baseUrl}/Filter/30`);
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

  defineStatusLancamentoCancelado(id: number) {
    return this.http.put(`${this.baseUrl}/Cancel/${id}`, {});
  }

}
