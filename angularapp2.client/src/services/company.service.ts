import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {delay, Observable} from "rxjs";
import {Company} from "../models/models";

@Injectable({
  providedIn: "root"
})
export class CompanyService {
  constructor(
    private http:HttpClient,
  ) {}
  getAllCompany():Observable<Company[]>{
    return this.http.get<any>('https://localhost:7014/api/company/getall').pipe(
      delay(2000))
  }
  addCompany(company: Company):Observable<boolean>{
       return this.http.post<any>('https://localhost:7014/api/company/add', company)
  }
  updateCompany(company: Company):Observable<boolean>{
    return this.http.put<any>('https://localhost:7014/api/company/update', company)
  }
  deleteCompany(id: number):Observable<boolean> {
    return this.http.delete<any>('https://localhost:7014/api/company/delete/'+ id)
  }
  searchByIdCompany(id: number):Observable<Company> {
    return this.http.get<any>('https://localhost:7014/api/company/getbyid/'+ id)
  }
}
