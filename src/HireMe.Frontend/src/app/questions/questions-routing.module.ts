import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { QuestionsComponent } from './questions/questions.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';

const routes: Routes = [
  { path: "", component: QuestionsComponent },
  { path: "create", component: EditQuestionComponent },
  { path: "edit/:id", component: EditQuestionComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionsRoutingModule {}
