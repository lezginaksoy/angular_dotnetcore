import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Video } from '../model/Brand';
import { TerminalService } from '../terminal.service';
import { Terminal } from '../model/terminal';



@Component({
  selector: 'app-add-terminal',
  templateUrl: './add-terminal.component.html',
  styleUrls: ['./add-terminal.component.css']
})
export class AddTerminalComponent implements OnInit {

  public brands: string[];
  public terminal: Terminal = {};

  constructor(
    private router: Router,
    private terminalservice: TerminalService) {

    this.brands = ['', '1', '2', '3'];
  }

  ngOnInit() {
  }

  addTerminal() {
    this.terminalservice.addTerminal(this.terminal)
      .subscribe(() => {
        this.router.navigateByUrl('/'); });
    }
}
