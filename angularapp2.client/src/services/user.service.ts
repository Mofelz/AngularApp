import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {UserLoginDto, UserRegistrationDto} from "../models/models";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UserService{
  constructor(
    private http:HttpClient,
  ) {}
  RegistrationUser(user: UserRegistrationDto):Observable<string>{
    return this.http.post<any>('https://localhost:7014/api/registration', user)
  }
  LoginUser(user: UserLoginDto):Observable<string>{
    return this.http.post<any>('https://localhost:7014/api/registration', user)
  }
}
