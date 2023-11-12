import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContaComponent } from './conta/conta.component';
import { NewLancComponent } from './new-lanc/new-lanc.component';
import { FormsModule } from '@angular/forms';
import { EditLancComponent } from './edit-lanc/edit-lanc.component';

@NgModule({
  declarations: [
    AppComponent,
    ContaComponent,
    NewLancComponent,
    EditLancComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
