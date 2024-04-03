import {Component, OnInit} from '@angular/core';
import {User} from "../../../models/models";
import {UserService} from "../../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit{

  // user: User = {name: '',password: '',role: ''}
  authUser: boolean = false;

  user: User;

  regForm: FormGroup;

  activeUsers: User[];
  constructor(private service:UserService,) {}
  ngOnInit(): void {
    this.GetAllUsersActive()

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
  // LoginUser(){
  //   this.service.Login(this.user).subscribe(
  //     res => {
  //       if (res == "Success"){
  //         this.user.name = ''
  //         this.user.password = ''
  //         alert("Пользователь успешно вошел!")
  //         this.authUser = true
  //       }else if(res == "Password error"){
  //         alert("Неверный пароль")
  //       }else if(res == "User not found"){
  //         alert("Такой пользователь не найден")
  //       }else {
  //         alert(res)
  //       }
  //     }
  //   )
  // }

  Registration(){

    if(this.regForm.get('password').value != this.regForm.get('passwordReturn').value){
      alert("Пароли не совпадают!")
      return;
    }

    if(!this.regForm.valid){
      alert("Не все данные валидны!")
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

  GetAllUsersActive(){
    this.service.GetAllUsersActive().subscribe(
      res => {
        this.activeUsers = res
      }
    )
  }
  ExitUser() {
    this.authUser = false
  }
}
