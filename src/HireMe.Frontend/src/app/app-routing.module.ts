import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login/login-page/login-page.component';
import { AuthGuard } from './_core/auth.guard';

const routes: Routes = [
  { path: "login", component: LoginPageComponent },
  {
    path: "",
    component: AppComponent,
    children: [
      {
        path: "",
        canActivate:[AuthGuard],
        loadChildren: () => import("src/app/home/home.module").then(m => m.HomeModule)
      },
      {
        path: "opportunities",
        canActivate:[AuthGuard],
        loadChildren: () => import("src/app/opportunities/opportunities.module").then(m => m.OpportunitiesModule)
      }, 
      {
        path: "employeers",
        canActivate:[AuthGuard],
        loadChildren: () => import("src/app/employeers/employeers.module").then(m => m.EmployeersModule)
      },           
    ],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
