import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import {TechnologiesService} from '../../../api/technologies.service'

@Component({
  selector: 'technologies',
  templateUrl: './technologies.component.html',
  styleUrls: ['./technologies.component.css']
})
export class TechnologiesComponent implements OnInit {

  technologies
  constructor(private technologiesService:TechnologiesService,                          
              private  route:ActivatedRoute,
              private router:Router ) { }

  ngOnInit() {
    let id=this.route.snapshot.paramMap.get('id')
    this.getTechnologies(id);
  }

  getTechnologies(id){
    this.technologiesService.index(id)
    .then((data)=>{this.technologies=data});
  }

}
