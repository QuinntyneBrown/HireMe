import { Component, OnInit, OnDestroy } from '@angular/core';

import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_core/auth.service';
import { UsersService } from '../users.service';
import { LocalStorageService } from 'src/app/_core/local-storage.service';
import { currentUserKey, roles } from 'src/app/_core/constants';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  constructor(
    private authService: AuthService,
    private usersService: UsersService,
    private router: Router,
    private localStorageService: LocalStorageService
  ) { }

  public handleTryToLogin($event: { username: string, password: string }) {
    this.authService
    .tryToLogin({
      username: $event.username,
      password: $event.password
    })
    .pipe(
      takeUntil(this._destroyed),
      switchMap(x => this.usersService.current()),
      tap(user => {
        this.localStorageService.put({ name: currentUserKey, value: user });
        this.authService.currentUser$.next(user);
      }),
    )
    .subscribe(
      (user) => {
        this.router.navigateByUrl('/');
      }
    );  
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
