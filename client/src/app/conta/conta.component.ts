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
  ]
  enumStatus: string[] = [
    "Válido",
    "Cancelado"
  ]

  constructor(private contaService: ContaService) {

  }

  ngOnInit(): void {
    this.getLancamentos();
  }

  getLancamentos() {
    this.contaService.getLancamentos().subscribe({
      next: response => this.contas = response
    })
  }
}
