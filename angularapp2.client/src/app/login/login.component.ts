import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {UserRegistrationDto} from "../../models/models";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  user: UserRegistrationDto;

  regForm: FormGroup;

  constructor(private service:UserService,) {}
  ngOnInit(): void {
    this.regForm = new FormGroup({
      password: new FormControl<string>("",Validators.required),
      email: new FormControl<string>("",[Validators.required, Validators.email]),
    })
  }
  Login() {

    if (this.regForm.get('password').value.length < 5) {
      alert("У пароля не может быть меньше 5 символов!")
      return;
    }

    if (!this.regForm.valid) {
      alert("Не все поля заполнены или корректны!")
      return
    }

    console.log(this.user)
    this.service.LoginUser(this.user).subscribe(
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
