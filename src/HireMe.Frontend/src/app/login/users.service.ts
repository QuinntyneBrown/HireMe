import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '../_core/constants';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public current(): Observable<User> {
    return this._client.get<{ currentUser: User }>(`${this._baseUrl}api/users/current`)
      .pipe(
        map(x => x.currentUser)
      );
  }
}
