import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ChooseComponent} from './modules/technology/choose/choose.component'
import {TechnologiesComponent} from './modules/technology/technologies/technologies.component'
import {UsersComponent} from './modules/users/users.component'
import {ScheduleComponent} from './modules/schedule/schedule.component'


const routes: Routes = [
  { path: '', redirectTo: 'choose-technology', pathMatch: 'full' },
  { path: 'choose-technology', component: ChooseComponent },
  { path: 'technoligies/:id', component: TechnologiesComponent },
  { path: 'users/:id', component: UsersComponent },
  { path: 'scheduled', component: ScheduleComponent },
  { path: '**', redirectTo: 'choose-technology' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
