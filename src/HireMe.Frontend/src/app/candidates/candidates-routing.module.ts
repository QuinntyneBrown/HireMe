import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CandidatesComponent } from './candidates/candidates.component';
import { EditCandidateComponent } from './edit-candidate/edit-candidate.component';

const routes: Routes = [
  { path: "", component: CandidatesComponent },
  { path: "create", component: EditCandidateComponent },
  { path: "edit/:id", component: EditCandidateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidatesRoutingModule {}
