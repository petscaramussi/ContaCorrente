import { Component } from '@angular/core';
import { Conta } from '../models/conta';
import { ContaService } from '../conta.service';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html',
  styleUrls: ['./conta.component.scss']
})
export class ContaComponent {

  title = 'client';
  contas: Conta[] = [];

  enumAvulso: string[] = [
    "NãoAvulso",
    "Avulso"
  ];

  enumStatus: string[] = [
    "Válido",
    "Cancelado"
  ];



  constructor(private contaService: ContaService) {

  }

  ngOnInit(): void {
    this.getLancamentosLastTwoDays();
  }

  onOptionSelected(event: any) {
    console.log("Selected option value:", event.target);

    if(event.target.value == 'Todos') {
      this.getAllLancamentos();
    }

    if(event.target.value == 'Últimos 30 dias') {
      this.getLancamentosLastThirtyDays();
    }

    if(event.target.value == 'Últimos 2 dias') {
      this.getLancamentosLastTwoDays();
    }
  }

  getAllLancamentos() {
    this.contaService.getAllLancamentos().subscribe({
      next: response => this.contas = response
    })
  }

  getLancamentosLastTwoDays() {
    this.contaService.getLancamentosLastTwoDays().subscribe({
      next: response => this.contas = response
    })
  }

  getLancamentosLastThirtyDays() {
    this.contaService.getLancamentosLastThirtyDays().subscribe({
      next: response => this.contas = response
    })
  }

  cancelaLancamento(id: number) {
    console.log(id)
    this.contaService.defineStatusLancamentoCancelado(id).subscribe({
      next: response => console.log(response),
      complete: () => {
        this.getAllLancamentos();
      }
    })
  }
}
