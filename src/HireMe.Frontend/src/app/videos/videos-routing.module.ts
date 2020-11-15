import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { VideosComponent } from './videos/videos.component';
import { EditVideoComponent } from './edit-video/edit-video.component';

const routes: Routes = [
  { path: "", component: VideosComponent },
  { path: "create", component: EditVideoComponent },
  { path: "edit/:id", component: EditVideoComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VideosRoutingModule {}
