import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {delay, Observable} from "rxjs";
import {Fio} from "../models/models";

@Injectable({
  providedIn: "root"
})
export class FioService {
  constructor(
    private http:HttpClient,
  ) {}
  getAllFio():Observable<Fio[]>{
    return this.http.get<any>('https://localhost:7014/api/fio/getall').pipe(
      delay(2000)
    )
  }
}
