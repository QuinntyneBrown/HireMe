import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionsComponent } from './questions/questions.component';
import { QuestionsRoutingModule } from './questions-routing.module';
import { EditQuestionComponent } from './edit-question/edit-question.component';
import { QuestionsService } from './questions.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [QuestionsComponent, EditQuestionComponent],
  providers: [
    QuestionsService
  ],
  imports: [
    CommonModule,
    QuestionsRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class QuestionsModule { }
