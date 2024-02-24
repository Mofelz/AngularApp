import {Component, OnInit} from '@angular/core';
import {User} from "../../../models/models";
import {UserService} from "../../../services/user.service";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit{

  user: User = {name: '',password: '',role: ''}
  authUser: boolean = false;
  activeUsers: User[];
  constructor(private service:UserService,) {}
  ngOnInit(): void {
    this.GetAllUsersActive()
  }
  LoginUser(){
    this.service.Login(this.user).subscribe(
      res => {
        if (res == "Success"){
          this.user.name = ''
          this.user.password = ''
          alert("Пользователь успешно вошел!")
          this.authUser = true
        }else if(res == "Password error"){
          alert("Неверный пароль")
        }else if(res == "User not found"){
          alert("Такой пользователь не найден")
        }else {
          alert(res)
        }
      }
    )
  }
  GetAllUsersActive(){
    this.service.GetAllUsersActive().subscribe(
      res => {
        this.activeUsers = res
      }
    )
  }
}
