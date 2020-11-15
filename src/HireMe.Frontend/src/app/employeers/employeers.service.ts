import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Employeer } from './employeer';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeersService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Employeer[]> {
    return this._client.get<{ employeers: Employeer[] }>(`${this._baseUrl}api/employeers`)
      .pipe(
        map(x => x.employeers)
      );
  }

  public getById(options: { employeerId: number }): Observable<Employeer> {
    return this._client.get<{ employeer: Employeer }>(`${this._baseUrl}api/employeers/${options.employeerId}`)
      .pipe(
        map(x => x.employeer)
      );
  }

  public remove(options: { employeer: Employeer }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/employeers/${options.employeer.employeerId}`);
  }

  public save(options: { employeer: Employeer }): Observable<{ employeerId: number }> {
    return this._client.post<{ employeerId: number }>(`${this._baseUrl}api/employeers`, { employeer: options.employeer });
  }  
}
