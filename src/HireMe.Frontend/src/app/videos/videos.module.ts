import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VideosComponent } from './videos/videos.component';
import { VideosRoutingModule } from './videos-routing.module';
import { EditVideoComponent } from './edit-video/edit-video.component';
import { VideosService } from './videos.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [VideosComponent, EditVideoComponent],
  providers: [
    VideosService
  ],
  imports: [
    CommonModule,
    VideosRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class VideosModule { }
