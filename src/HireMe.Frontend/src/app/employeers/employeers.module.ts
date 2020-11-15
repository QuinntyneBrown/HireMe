import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeersComponent } from './employeers/employeers.component';
import { EmployeersRoutingModule } from './employeers-routing.module';
import { EditEmployeerComponent } from './edit-employeer/edit-employeer.component';
import { EmployeersService } from './employeers.service';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [EmployeersComponent, EditEmployeerComponent],
  providers: [
    EmployeersService
  ],
  imports: [
    CommonModule,
    EmployeersRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class EmployeersModule { }
