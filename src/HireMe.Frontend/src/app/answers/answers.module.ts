import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnswersComponent } from './answers/answers.component';
import { AnswersRoutingModule } from './answers-routing.module';
import { EditAnswerComponent } from './edit-answer/edit-answer.component';
import { AnswersService } from './answers.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AnswersComponent, EditAnswerComponent],
  providers: [
    AnswersService
  ],
  imports: [
    CommonModule,
    AnswersRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AnswersModule { }
