import {Component, OnInit} from '@angular/core';
import {Company, Fio} from "../../../models/models";
import {CompanyService} from "../../../services/company.service";

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent implements OnInit{

  companies: Company[];
  company: Company = {nameCompany: '',addresCompany: ''}

  constructor(private service:CompanyService,) {}
  ngOnInit() {
    this.getCompany()
  }
  getCompany(){
    this.service.getAllCompany().subscribe(
      company => this.companies = company
    )
  }
  addCompany(){
    this.service.addCompany(this.company).subscribe(
      res => {
        if (res){
          this.company = null
          alert("Успешно добавлен!")
        }else {
          alert("Абшибка!")
        }
      }
    )
  }
  updateCompany(){
    this.service.updateCompany(this.company).subscribe(
      res => {
        if (res){
          this.company = null
          alert("Данные успешно обновлены!")
        }else {
          alert("Абшибка!")
        }
      }
    )
  }
  deleteCompany(){
    this.service.deleteCompany(this.company.id).subscribe(
      res => {
        if (res){
          this.company.id = null
          alert("Данные успешно удалены!")
        }else {
          alert("Абшибка!")
        }
      }
    )
  }
  searchCompany(){
    this.service.searchByIdCompany(this.company.id).subscribe(
      res => {
        this.company.nameCompany = res.nameCompany
        this.company.addresCompany = res.addresCompany
      }
    )
  }
}
