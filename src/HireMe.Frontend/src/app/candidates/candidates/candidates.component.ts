import { Component, OnInit, OnDestroy } from '@angular/core';
import { CandidatesService } from '../candidates.service';
import { Observable, Subject } from 'rxjs';
import { Candidate } from '../candidate';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.scss']
})
export class CandidatesComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.candidatesService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private candidatesService: CandidatesService,
    private router: Router
  ) { }

  public handleEditClick(candidate: Candidate): void {
    this.router.navigateByUrl(`candidates/edit/${candidate.candidateId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('candidates/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
