import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Terminal } from './model/terminal';


@Injectable()
export class TerminalService {

  constructor(private httpClient: HttpClient) { }

  getTerminals(): Observable<Terminal[]> {
    return this.httpClient.get<Terminal[]>('/api/Terminals');
  }

  addTerminal(term: Terminal) {
    return this.httpClient.post('/api/Terminals', term);
  }



}
