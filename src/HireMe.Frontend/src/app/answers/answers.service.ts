import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Answer } from './answer';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AnswersService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Answer[]> {
    return this._client.get<{ answers: Answer[] }>(`${this._baseUrl}api/answers`)
      .pipe(
        map(x => x.answers)
      );
  }

  public getById(options: { answerId: number }): Observable<Answer> {
    return this._client.get<{ answer: Answer }>(`${this._baseUrl}api/answers/${options.answerId}`)
      .pipe(
        map(x => x.answer)
      );
  }

  public remove(options: { answer: Answer }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/answers/${options.answer.answerId}`);
  }

  public save(options: { answer: Answer }): Observable<{ answerId: number }> {
    return this._client.post<{ answerId: number }>(`${this._baseUrl}api/answers`, { answer: options.answer });
  }  
}
