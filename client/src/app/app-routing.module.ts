import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaComponent } from './conta/conta.component';
import { NewLancComponent } from './new-lanc/new-lanc.component';

const routes: Routes = [
  {path: '', redirectTo: 'conta', pathMatch: 'full'},
  {path: 'conta', component: ContaComponent},
  {path: 'new-lanc', component: NewLancComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
