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
  Login(user: User):Observable<string>{
    return this.http.post<any>('https://localhost:7014/api/login', user)
  }
  GetAllUsersActive():Observable<User[]>{
    return this.http.get<any>('https://localhost:7014/api/user/getall')
  }
}
