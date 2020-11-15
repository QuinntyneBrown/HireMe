import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Candidate } from './candidate';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CandidatesService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Candidate[]> {
    return this._client.get<{ candidates: Candidate[] }>(`${this._baseUrl}api/candidates`)
      .pipe(
        map(x => x.candidates)
      );
  }

  public getById(options: { candidateId: number }): Observable<Candidate> {
    return this._client.get<{ candidate: Candidate }>(`${this._baseUrl}api/candidates/${options.candidateId}`)
      .pipe(
        map(x => x.candidate)
      );
  }

  public remove(options: { candidate: Candidate }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/candidates/${options.candidate.candidateId}`);
  }

  public save(options: { candidate: Candidate }): Observable<{ candidateId: number }> {
    return this._client.post<{ candidateId: number }>(`${this._baseUrl}api/candidates`, { candidate: options.candidate });
  }  
}
