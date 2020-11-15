import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { OpportunitiesComponent } from './opportunities/opportunities.component';
import { EditOpportunityComponent } from './edit-opportunity/edit-opportunity.component';

const routes: Routes = [
  { path: "", component: OpportunitiesComponent },
  { path: "create", component: EditOpportunityComponent },
  { path: "edit/:id", component: EditOpportunityComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OpportunitiesRoutingModule {}
