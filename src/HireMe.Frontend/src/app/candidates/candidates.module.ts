import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidatesComponent } from './candidates/candidates.component';
import { CandidatesRoutingModule } from './candidates-routing.module';
import { EditCandidateComponent } from './edit-candidate/edit-candidate.component';
import { CandidatesService } from './candidates.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [CandidatesComponent, EditCandidateComponent],
  providers: [
    CandidatesService
  ],
  imports: [
    CommonModule,
    CandidatesRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class CandidatesModule { }
