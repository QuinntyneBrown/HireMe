import { Component, OnInit, OnDestroy } from '@angular/core';
import { OpportunitiesService } from '../opportunities.service';
import { Observable, Subject } from 'rxjs';
import { Opportunity } from '../opportunity';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-opportunities',
  templateUrl: './opportunities.component.html',
  styleUrls: ['./opportunities.component.scss']
})
export class OpportunitiesComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.opportunitiesService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private opportunitiesService: OpportunitiesService,
    private router: Router
  ) { }

  public handleEditClick(opportunity: Opportunity): void {
    this.router.navigateByUrl(`opportunities/edit/${opportunity.opportunityId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('opportunities/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
