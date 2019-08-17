import { Component, OnInit, Inject } from '@angular/core';

import { TerminalService } from '../terminal.service';
import { Terminal } from '../model/terminal';

@Component({
  selector: 'app-terminal-list',
  templateUrl: './terminal-list.component.html',
  styleUrls: ['./terminal-list.component.css']
})
export class TerminalListComponent implements OnInit {

  title = "Terminal List";
  public term: Terminal[];
  
  constructor(private termservice: TerminalService) { }

  ngOnInit() {

    this.termservice.getTerminals()
      .subscribe(terminal => this.term = terminal);
      
  }




}
