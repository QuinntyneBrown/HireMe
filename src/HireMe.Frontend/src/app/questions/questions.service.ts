import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { Question } from './question';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Question[]> {
    return this._client.get<{ questions: Question[] }>(`${this._baseUrl}api/questions`)
      .pipe(
        map(x => x.questions)
      );
  }

  public getById(options: { questionId: number }): Observable<Question> {
    return this._client.get<{ question: Question }>(`${this._baseUrl}api/questions/${options.questionId}`)
      .pipe(
        map(x => x.question)
      );
  }

  public remove(options: { question: Question }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/questions/${options.question.questionId}`);
  }

  public save(options: { question: Question }): Observable<{ questionId: number }> {
    return this._client.post<{ questionId: number }>(`${this._baseUrl}api/questions`, { question: options.question });
  }  
}
