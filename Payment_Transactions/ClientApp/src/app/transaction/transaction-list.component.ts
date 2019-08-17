import { Component, OnInit, Inject } from '@angular/core';

import { Transaction } from '../model/transaction';
import { transition } from '@angular/core/src/animation/dsl';
import { TransactionService } from '../transaction.service';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

  public transactions: Transaction[];

  constructor(private transactionService: TransactionService) { }

  ngOnInit() {

    this.transactionService.getTransactions()
      .subscribe(transaction => this.transactions = transaction);
  }

  getTransactionByTermId(txn: Transaction) {
    this.transactionService.getTransactionByTermId(txn);
  }


}
