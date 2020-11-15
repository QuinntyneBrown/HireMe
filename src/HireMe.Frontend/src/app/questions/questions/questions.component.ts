import { Component, OnInit, OnDestroy } from '@angular/core';
import { QuestionsService } from '../questions.service';
import { Observable, Subject } from 'rxjs';
import { Question } from '../question';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.questionsService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private questionsService: QuestionsService,
    private router: Router
  ) { }

  public handleEditClick(question: Question): void {
    this.router.navigateByUrl(`questions/edit/${question.questionId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('questions/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
