import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule,JsonpModule} from '@angular/http'
import {FormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './modules/users/users.component';
import { ChooseComponent } from './modules/technology/choose/choose.component';
import { TechnologiesComponent } from './modules/technology/technologies/technologies.component';


import {TechnologyService} from './api/technology.service'
import {TechnologiesService} from './api/technologies.service'
import {UsersService} from './api/users.service'
import {InterviewService} from './api/interview.service'
import {InterviewTypeService} from './api/interviewType.service'
import {ScheduledService} from './api/schedule.service'


import {CalculateModulePipe} from './pipe/users.pipe'


import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import { ScheduleComponent } from './modules/schedule/schedule.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    ChooseComponent,
    TechnologiesComponent,
    CalculateModulePipe,
    ScheduleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    JsonpModule,
    FormsModule,
    DlDateTimeDateModule,
    DlDateTimePickerModule
  ],
  providers: [
    TechnologyService,
    TechnologiesService,
    UsersService,
    InterviewService,
    InterviewTypeService,
    ScheduledService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
