import {Component, OnInit} from '@angular/core';
import {UserRegistrationDto} from "../../../models/models";
import {UserService} from "../../../services/user.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {dateTimestampProvider} from "rxjs/internal/scheduler/dateTimestampProvider";
import {formatDate} from "@angular/common";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit{

  user: UserRegistrationDto;

  regForm: FormGroup;

  date: Date;

  constructor(private service:UserService,) {}
  ngOnInit(): void {
    this.date = new Date(Date.now())
    this.date.setDate(this.date.getDate()-6570)
    this.regForm = new FormGroup({
      userName: new FormControl<string>("",[Validators.required,Validators.minLength(5)]),
      password: new FormControl<string>("",Validators.required),
      passwordReturn: new FormControl<string>("",Validators.required),
      name: new FormControl<string>("",Validators.required),
      lastName: new FormControl<string>("",Validators.required),
      patronymic: new FormControl<string>(""),
      birthdayDate: new FormControl<Date>(null,Validators.required),
      email: new FormControl<string>("",[Validators.required, Validators.email]),
      phoneNumber: new FormControl<string>("",[Validators.required, Validators.minLength(10)]),
      agreementAccept: new FormControl<boolean>(false,Validators.required)
    })
  }

  Registration(){

    if(this.regForm.get('password').value != this.regForm.get('passwordReturn').value){
      alert("Пароли не совпадают!")
      return;
    }

    if(this.regForm.get('login').value.length < 5){
      alert("У логина не может быть меньше 5 символов!")
      return;
    }

    if(this.regForm.get('password').value.length < 5){
      alert("У пароля не может быть меньше 5 символов!")
      return;
    }

    if(new Date(this.regForm.get('birthday').value).getTime() > this.date.getTime()){
      alert("Вам не должно быть меньше 18-ти лет")
      return;
    }

    if(!this.regForm.valid){
      alert("Не все поля заполнены или корректны!")
      return
    }

    delete this.regForm.value['passwordReturn']
    this.user = this.regForm.value
    // this.user.id = 1;
    this.user.phoneNumber = this.user.phoneNumber.toString()
    this.user.birthday = this.regForm.get('birthday').value


    console.log(this.user)
    // this.service.RegistrationUser(this.user).subscribe(
    //   result => {
    //     if(result == "Successfully"){
    //       this.regForm.reset()
    //       alert("Пользователь успешно зарегистрирован!")
    //     }
    //     else if(result == "LoginExist"){
    //       alert("Пользователь с таким логином уже существует!")
    //     }
    //     else{
    //       alert("One more error")
    //     }
    //   }
    // )
  }
}
