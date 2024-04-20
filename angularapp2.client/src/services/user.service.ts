import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/models";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UserService{
  constructor(
    private http:HttpClient,
  ) {}
  RegistrationUser(user: User):Observable<string>{
    return this.http.post<any>('https://localhost:7014/api/registration', user)
  }
}
