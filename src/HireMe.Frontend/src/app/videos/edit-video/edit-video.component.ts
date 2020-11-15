import { Component, OnDestroy, OnInit } from '@angular/core';
import { VideosService } from '../videos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Video } from '../video';
import { takeUntil, map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-edit-video',
  templateUrl: './edit-video.component.html',
  styleUrls: ['./edit-video.component.scss']
})
export class EditVideoComponent implements OnInit, OnDestroy {

  public video: Video = {} as Video;
  private readonly _destroyed: Subject<void> = new Subject();

  public form = new FormGroup({     
    //name: new FormControl(this.video.name, [Validators.required]),      
  });
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private videosService: VideosService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.video.videoId = this.activatedRoute.snapshot.params.id;

    if(this.video.videoId) {
      this.videosService.getById({ videoId: this.activatedRoute.snapshot.params.id }).pipe(
        map(x => {
          this.form.patchValue({
            //title: x.name,
          });
        })
      ).subscribe();
    }
  }

  public handleSaveClick(): void {
    const video: Video = {} as Video;

    //this.video.name = this.form.value.name;

    this.videosService.save({ video: this.video }).pipe(
      takeUntil(this._destroyed)
    ).subscribe(
      () => this.form.reset(),
      errorResponse => {
        // handle error
      }
    );

  }

  public handleCancelClick(): void {
    this.router.navigateByUrl('/videos');
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
