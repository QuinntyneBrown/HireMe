import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from './login/user';
import { AuthService } from './_core/auth.service';
import { roles } from './_core/constants';
import { LocalStorageService } from './_core/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public user$: Observable<User> = this.authService.currentUser$;

  public isAdmin$: Observable<boolean> = this.user$.pipe(
    map(x => {
      if(!x || !x.roles)
        return false;

      return x.roles.map(x=> x.name).indexOf(roles.admin) > -1;
    })
  );

  constructor(private authService: AuthService) {

  }
}
