import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Video } from './video';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VideosService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Video[]> {
    return this._client.get<{ videos: Video[] }>(`${this._baseUrl}api/videos`)
      .pipe(
        map(x => x.videos)
      );
  }

  public getById(options: { videoId: number }): Observable<Video> {
    return this._client.get<{ video: Video }>(`${this._baseUrl}api/videos/${options.videoId}`)
      .pipe(
        map(x => x.video)
      );
  }

  public remove(options: { video: Video }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/videos/${options.video.videoId}`);
  }

  public save(options: { video: Video }): Observable<{ videoId: number }> {
    return this._client.post<{ videoId: number }>(`${this._baseUrl}api/videos`, { video: options.video });
  }  
}
