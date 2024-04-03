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
      company => {
        this.companies = []
        this.companies.push(...company)
      }
    )
  }
  addCompany(){
    if(this.company.nameCompany == '' ||
      this.company.addresCompany == ''){

      alert("Не все поля заполнены")
      return
    }
    this.service.addCompany(this.company).subscribe(
      res => {
        if (res){

          this.company.nameCompany = ''
          this.company.addresCompany = ''

          alert("Пользолватель зарегистрирован!")
        }else {
          alert("Абшибка!")
        }
      }
    )
  }

  updateCompany(company: Company) {
    if(this.company.nameCompany == '' ||
      this.company.addresCompany == ''){

      alert("Не все поля заполнены!")
      return
    }else if(company.nameCompany == this.company.nameCompany ||
      company.addresCompany == this.company.addresCompany){
      alert("Такие данные уже существуют!")
    }
    company.nameCompany = this.company.nameCompany
    company.addresCompany = this.company.addresCompany

    this.service.updateCompany(company).subscribe(
      res => {
        if (res == "Success"){
          alert("Данные успешно обновлены!")
          this.company.nameCompany = ''
          this.company.addresCompany = ''

        }else if(res == "Enter anything!"){
          alert("Введите данные!")
        }else {
          alert(res)
        }
      }
    )
  }
  deleteCompany(company_id: number){
    this.service.deleteCompany(company_id).subscribe(
      res => {
        if (res){
          this.getCompany()
          alert("Данные успешно удалены!")
        }else {
          alert("Абшибка!")
        }
      }
    )
  }
  searchCompany(){
    if(this.company.nameCompany == '' ||
      this.company.addresCompany == ''){

      alert("Не все поля заполнены")
      return
    }
    this.service.searchByIdCompany(this.company.id).subscribe(
      res => {
        this.company.nameCompany = res.nameCompany
        this.company.addresCompany = res.addresCompany
      }
    )
  }
}
