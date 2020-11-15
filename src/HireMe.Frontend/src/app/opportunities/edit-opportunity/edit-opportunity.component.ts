import { Component, OnDestroy, OnInit } from '@angular/core';
import { OpportunitiesService } from '../opportunities.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Opportunity } from '../opportunity';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-opportunity',
  templateUrl: './edit-opportunity.component.html',
  styleUrls: ['./edit-opportunity.component.scss']
})
export class EditOpportunityComponent implements OnInit, OnDestroy {

  public opportunity: Opportunity = {} as Opportunity;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    //name: new FormControl(this.opportunity.name, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private opportunitiesService: OpportunitiesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.opportunity.opportunityId = this.activatedRoute.snapshot.params.id;

    if(this.opportunity.opportunityId) {
      this.opportunitiesService.getById({ opportunityId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            //title: x.name,
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const opportunity: Opportunity = {} as Opportunity;

    //this.opportunity.name = this.form.value.name;

    this.opportunitiesService.save({ opportunity: this.opportunity }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        // handle error
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/opportunities');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
