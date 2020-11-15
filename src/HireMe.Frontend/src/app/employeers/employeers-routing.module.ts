import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { EmployeersComponent } from './employeers/employeers.component';
import { EditEmployeerComponent } from './edit-employeer/edit-employeer.component';

const routes: Routes = [
  { path: "", component: EmployeersComponent },
  { path: "create", component: EditEmployeerComponent },
  { path: "edit/:id", component: EditEmployeerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeersRoutingModule {}
