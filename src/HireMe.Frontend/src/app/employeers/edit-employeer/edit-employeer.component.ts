import { Component, OnDestroy, OnInit } from '@angular/core';
import { EmployeersService } from '../employeers.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Employeer } from '../employeer';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-employeer',
  templateUrl: './edit-employeer.component.html',
  styleUrls: ['./edit-employeer.component.scss']
})
export class EditEmployeerComponent implements OnInit, OnDestroy {

  public employeer: Employeer = {} as Employeer;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    firstName: new FormControl(this.employeer.firstName, [Validators.required]),
    lastName: new FormControl(this.employeer.lastName, [Validators.required]),
    email: new FormControl(this.employeer.email, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private employeersService: EmployeersService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.employeer.employeerId = this.activatedRoute.snapshot.params.id;

    if(this.employeer.employeerId) {
      this.employeersService.getById({ employeerId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            firstName: x.firstName,
            lastName: x.lastName,
            email: x.email
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const employeer: Employeer = {} as Employeer;

    this.employeer.firstName = this.form.value.firstName;
    this.employeer.lastName = this.form.value.lastName;
    this.employeer.email = this.form.value.email;

    this.employeersService.save({ employeer: this.employeer }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/employeers');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
