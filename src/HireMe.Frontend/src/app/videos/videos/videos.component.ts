import { Component, OnInit, OnDestroy } from '@angular/core';
import { VideosService } from '../videos.service';
import { Observable, Subject } from 'rxjs';
import { Video } from '../video';
import { MatTableDataSource } from '@angular/material/table';
import { map, takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss']
})
export class VideosComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();
  
  public columnsToDisplay: string[] = [

    'edit'
  ];

  public dataSource$ = this.videosService.get().pipe(
    takeUntil(this._destroyed),
    map(x => new MatTableDataSource(x))
  );

  constructor(
    private videosService: VideosService,
    private router: Router
  ) { }

  public handleEditClick(video: Video): void {
    this.router.navigateByUrl(`videos/edit/${video.videoId}`);
  }

  public handleCreateClick(): void {
    this.router.navigateByUrl('videos/create');
  }
  
  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
