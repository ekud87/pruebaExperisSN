import { Component, OnInit } from '@angular/core';
import {TechnologyService} from '../../../api/technology.service'

@Component({
  selector: 'choose',
  templateUrl: './choose.component.html',
  styleUrls: ['./choose.component.css']
})
export class ChooseComponent implements OnInit {

  types:Array<any>
  constructor(private technologyService:TechnologyService) { }

  ngOnInit() {
    this.type();
  }

  type(){
    this.technologyService.index()
    .then((data)=>{this.types=data});
  }
}
