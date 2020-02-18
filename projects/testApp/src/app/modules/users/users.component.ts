import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router'
import { UsersService } from '../../api/users.service';
import {InterviewService} from '../../api/interview.service'
import {InterviewTypeService} from '../../api/interviewType.service'

import Utils from '../../utils/utils'

declare var $:any;
@Component({
  selector: 'users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  module
  users
  date
  idUser
  interviewType
  selectedOption
  scheduledUsers:any={value:0,msg:'',result:[]}

  utils
  constructor(private route:ActivatedRoute,
              private usersService:UsersService,
              private interviewService:InterviewService,
              private interviewTypeService:InterviewTypeService) {
                this.utils=new Utils();
               }

  ngOnInit() {
    this.module=parseInt(this.route.snapshot.paramMap.get('id'))%2==0?'par':'impar'
    this.getUsers();
    this.getIntervewType();
  }

  getUsers(){
    this.usersService.index()
    .then((data)=>{this.users=data})
  }

  save(){
    console.log(this.date);
    let user=this.utils.getDataUser(this.users.filter(item=>item.id==this.idUser));
    let data={user:user,type:parseInt(this.selectedOption),date:this.utils.convertDate(this.date)}
    this.interviewService.save(data)
    .then((data)=>{
      this.scheduledUsers=data;
      if (this.scheduledUsers.value!=1)
        $('#failedModal').modal('show');
      else
        $('#okModal').modal('show');
    })
  }

  getUser(id){
    this.idUser=id;
  }

  getIntervewType(){
    this.interviewTypeService.index()
    .then((data)=>{this.interviewType=data});
  }

  selectOption(id){
    this.selectedOption=id;
  }
}
