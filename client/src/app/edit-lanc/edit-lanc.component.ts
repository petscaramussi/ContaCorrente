import { Component, OnInit } from '@angular/core';
import { Conta } from '../models/conta';
import { ContaService } from '../conta.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-lanc',
  templateUrl: './edit-lanc.component.html',
  styleUrls: ['./edit-lanc.component.scss']
})
export class EditLancComponent implements OnInit{
  
  id: number = 0;

  conta: Conta = {
    id: 0,
    descricao: '',
    data: '',
    valor: 0,
    avulso: 0,
    status: 0
  }

  constructor (private contaService: ContaService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.conta.id = this.route.snapshot.params['id'];
    this.findById();
  }

  findById() {
    return this.contaService.getLancamentoById(this.conta.id).subscribe({
      next: response => {
        this.conta = response;
        this.conta.data = this.conta.data.split('T')[0];
      }
    })
  }

  

  onSubimit() {
    this.contaService.updateLancamento(this.conta).subscribe({
      next: response => {
        console.log(response);
        this.goToConta()
      }
    })
  }

  goToConta() {
    this.router.navigate(['/']);
  }
}
