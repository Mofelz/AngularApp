import {Component, OnInit} from '@angular/core';
import {User} from "../../../models/models";
import {UserService} from "../../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {dateTimestampProvider} from "rxjs/internal/scheduler/dateTimestampProvider";
import {formatDate} from "@angular/common";


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit{

  user: User;

  regForm: FormGroup;

  constructor(private service:UserService,) {}
  ngOnInit(): void {
    let date = new Date(Date.now())
    date.setDate(date.getDate()-6570)
    this.regForm = new FormGroup({
      login: new FormControl<string>("",Validators.required),
      password: new FormControl<string>("",Validators.required),
      passwordReturn: new FormControl<string>("",Validators.required),
      name: new FormControl<string>("",Validators.required),
      surname: new FormControl<string>("",Validators.required),
      patronomic: new FormControl<string>(""),
      birthday: new FormControl<Date>(date,Validators.required),
      mail: new FormControl<string>("",[Validators.required, Validators.email]),
      phoneNumber: new FormControl<string>("",Validators.required)
    })
  }

  Registration(){

    if(this.regForm.get('password').value != this.regForm.get('passwordReturn').value){
      alert("Пароли не совпадают!")
      return;
    }

    if(this.regForm.get('login').value.length < 5){
      alert("Логин не может быть меньше 5 символов!")
      return;
    }

    if(this.regForm.get('password').value.length < 5){
      alert("Пароль не может быть меньше 5 символов!")
      return;
    }

    if(!this.regForm.valid){
      alert("Не все данные заполнены либо корректны!")
      return
    }

    delete this.regForm.value['passwordReturn']
    this.user = this.regForm.value
    this.user.id = 1;
    this.user.phoneNumber = this.user.phoneNumber.toString()
    this.user.birthday = new Date(this.regForm.get('birthday').value)

    this.service.RegistrationUser(this.user).subscribe(
      result => {
        if(result == "Successfully"){
          this.regForm.reset()
          alert("Пользователь успешно зарегистрирован!")
        }
        else if(result == "LoginExist"){
          alert("Пользователь с таким логином уже существует!")
        }
        else{
          alert("One more error")
        }
      }
    )
  }
}
