import { Component, OnInit, OnDestroy } from '@angular/core';
import { AnswersService } from '../answers.service';
import { Observable, Subject } from 'rxjs';
import { Answer } from '../answer';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-answers',
  templateUrl: './answers.component.html',
  styleUrls: ['./answers.component.scss']
})
export class AnswersComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.answersService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private answersService: AnswersService,
    private router: Router
  ) { }

  public handleEditClick(answer: Answer): void {
    this.router.navigateByUrl(`answers/edit/${answer.answerId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('answers/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
