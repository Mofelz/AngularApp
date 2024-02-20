import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Company} from "../models/models";

@Injectable({
  providedIn: "root"
})
export class CompanyService {
  constructor(
    private http:HttpClient,
  ) {}
  getAllCompany():Observable<Company[]>{
    return this.http.get<any>('https://localhost:7014/api/company/getall')
  }
}
