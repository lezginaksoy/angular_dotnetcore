import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TerminalService } from './terminal.service'

import { TerminalListComponent } from './terminal/terminal-list.component';
import { AddTerminalComponent } from './add-terminal/add-terminal.component';
import { TransactionService } from './transaction.service';
import { TransactionListComponent } from './transaction/transaction-list.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TerminalListComponent,
    AddTerminalComponent,
    TransactionListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'terminal', component: TerminalListComponent },  
      { path: 'addterminal', component: AddTerminalComponent },
      { path: 'transaction', component: TransactionListComponent }


    ])
  ],
  providers: [TerminalService, TransactionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
