import { Component } from '@angular/core';
import { ContaService } from '../conta.service';
import { Conta } from '../models/conta';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-lanc',
  templateUrl: './new-lanc.component.html',
  styleUrls: ['./new-lanc.component.scss']
})
export class NewLancComponent {

  conta: Conta = new Conta();

  constructor(private contaService: ContaService,private router: Router) {}

  createLancamento() {

   this.contaService.createNewLancamento(this.conta).subscribe({
    next: result => console.log(result),
    error: err => console.log(err),
    complete: () => this.goToConta()
   });

  }

  onSubimit() {
    console.log(this.conta);
    this.createLancamento();
  }

  goToConta() {
    this.router.navigate(['/']);
  }
}
