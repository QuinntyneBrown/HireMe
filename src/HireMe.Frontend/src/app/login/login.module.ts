import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginPageComponent } from './login-page/login-page.component';
import { UsersService } from './users.service';


@NgModule({
  declarations: [
    LoginComponent,
    LoginPageComponent
  ],
  providers: [
    UsersService
  ],
  exports :[
    LoginComponent,
    LoginPageComponent  
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class LoginModule { }
