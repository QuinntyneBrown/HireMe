import { Component, OnDestroy, OnInit } from '@angular/core';
import { CandidatesService } from '../candidates.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Candidate } from '../candidate';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-candidate',
  templateUrl: './edit-candidate.component.html',
  styleUrls: ['./edit-candidate.component.scss']
})
export class EditCandidateComponent implements OnInit, OnDestroy {

  public candidate: Candidate = {} as Candidate;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    //name: new FormControl(this.candidate.name, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private candidatesService: CandidatesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.candidate.candidateId = this.activatedRoute.snapshot.params.id;

    if(this.candidate.candidateId) {
      this.candidatesService.getById({ candidateId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            //title: x.name,
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const candidate: Candidate = {} as Candidate;

    //this.candidate.name = this.form.value.name;

    this.candidatesService.save({ candidate: this.candidate }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        // handle error
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/candidates');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
