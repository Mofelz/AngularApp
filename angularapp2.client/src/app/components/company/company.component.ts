import {Component, OnInit} from '@angular/core';
import {Company, Fio} from "../../../models/models";
import {CompanyService} from "../../../services/company.service";

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent implements OnInit{

  public company: Company;
  constructor(
    private service:CompanyService,
  ) {
  }
  ngOnInit() {
    this.getCompany();
  }
  getCompany(){
    this.service.getAllCompany().subscribe(
      company => this.company = company.find(x => x.id == 2)
    )
  }
}
