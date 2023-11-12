import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaComponent } from './conta/conta.component';
import { NewLancComponent } from './new-lanc/new-lanc.component';
import { EditLancComponent } from './edit-lanc/edit-lanc.component';

const routes: Routes = [
  {path: '', redirectTo: 'conta', pathMatch: 'full'},
  {path: 'conta', component: ContaComponent},
  {path: 'new-lanc', component: NewLancComponent},
  {path: 'edit-lanc/:id', component: EditLancComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
