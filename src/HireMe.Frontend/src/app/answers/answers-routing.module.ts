import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { AnswersComponent } from './answers/answers.component';
import { EditAnswerComponent } from './edit-answer/edit-answer.component';

const routes: Routes = [
  { path: "", component: AnswersComponent },
  { path: "create", component: EditAnswerComponent },
  { path: "edit/:id", component: EditAnswerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AnswersRoutingModule {}
