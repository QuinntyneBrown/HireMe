import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OpportunitiesComponent } from './opportunities/opportunities.component';
import { OpportunitiesRoutingModule } from './opportunities-routing.module';
import { EditOpportunityComponent } from './edit-opportunity/edit-opportunity.component';
import { OpportunitiesService } from './opportunities.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [OpportunitiesComponent, EditOpportunityComponent],
  providers: [
    OpportunitiesService
  ],
  imports: [
    CommonModule,
    OpportunitiesRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class OpportunitiesModule { }
