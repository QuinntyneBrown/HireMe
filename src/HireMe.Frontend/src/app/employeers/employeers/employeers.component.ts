import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmployeersService } from '../employeers.service';
import { Observable, Subject } from 'rxjs';
import { Employeer } from '../employeer';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employeers',
  templateUrl: './employeers.component.html',
  styleUrls: ['./employeers.component.scss']
})
export class EmployeersComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.employeersService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private employeersService: EmployeersService,
    private router: Router
  ) { }

  public handleEditClick(employeer: Employeer): void {
    this.router.navigateByUrl(`employeers/edit/${employeer.employeerId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('employeers/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
