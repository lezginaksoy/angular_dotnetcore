import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Terminal } from './model/terminal';
import { Transaction } from './model/transaction';


@Injectable()
export class TransactionService {

  constructor(private httpClient: HttpClient) { }

  getTransactions(): Observable<Transaction[]> {
    return this.httpClient.get<Transaction[]>('/api/Transaction');
  }



  getTransactionByTermId(txn: Transaction): Observable<Terminal[]> {
 
    let params = new HttpParams()
      .set('termId', txn.id);  
    return this.httpClient.get<Terminal[]>('/api/Terminals/termId', {params});
  }

}
