import { Component, OnInit } from '@angular/core';
import {ScheduledService} from '../../api/schedule.service'

@Component({
  selector: 'schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

  scheduleds
  constructor(private scheduledService:ScheduledService) { }

  ngOnInit() {
    this.getScheduled();
  }

  getScheduled(){
    this.scheduledService.index()
    .then((data)=>{this.scheduleds=data});
  }

}
