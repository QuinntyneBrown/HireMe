import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Opportunity } from './opportunity';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OpportunitiesService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Opportunity[]> {
    return this._client.get<{ opportunities: Opportunity[] }>(`${this._baseUrl}api/opportunities`)
      .pipe(
        map(x => x.opportunities)
      );
  }

  public getById(options: { opportunityId: number }): Observable<Opportunity> {
    return this._client.get<{ opportunity: Opportunity }>(`${this._baseUrl}api/opportunities/${options.opportunityId}`)
      .pipe(
        map(x => x.opportunity)
      );
  }

  public remove(options: { opportunity: Opportunity }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/opportunities/${options.opportunity.opportunityId}`);
  }

  public save(options: { opportunity: Opportunity }): Observable<{ opportunityId: number }> {
    return this._client.post<{ opportunityId: number }>(`${this._baseUrl}api/opportunities`, { opportunity: options.opportunity });
  }  
}
