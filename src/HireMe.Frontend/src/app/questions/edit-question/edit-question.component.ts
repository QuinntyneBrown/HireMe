import { Component, OnDestroy, OnInit } from '@angular/core';
import { QuestionsService } from '../questions.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Question } from '../question';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.scss']
})
export class EditQuestionComponent implements OnInit, OnDestroy {

  public question: Question = {} as Question;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    //name: new FormControl(this.question.name, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.question.questionId = this.activatedRoute.snapshot.params.id;

    if(this.question.questionId) {
      this.questionsService.getById({ questionId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            //title: x.name,
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const question: Question = {} as Question;

    //this.question.name = this.form.value.name;

    this.questionsService.save({ question: this.question }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        // handle error
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/questions');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
