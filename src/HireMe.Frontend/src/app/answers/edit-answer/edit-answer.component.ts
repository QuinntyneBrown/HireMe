import { Component, OnDestroy, OnInit } from '@angular/core';
import { AnswersService } from '../answers.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Answer } from '../answer';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-answer',
  templateUrl: './edit-answer.component.html',
  styleUrls: ['./edit-answer.component.scss']
})
export class EditAnswerComponent implements OnInit, OnDestroy {

  public answer: Answer = {} as Answer;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    //name: new FormControl(this.answer.name, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private answersService: AnswersService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.answer.answerId = this.activatedRoute.snapshot.params.id;

    if(this.answer.answerId) {
      this.answersService.getById({ answerId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            //title: x.name,
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const answer: Answer = {} as Answer;

    //this.answer.name = this.form.value.name;

    this.answersService.save({ answer: this.answer }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        // handle error
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/answers');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
