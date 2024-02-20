import {Component, OnInit} from '@angular/core';
import {FioService} from "../../../services/fio.service";
import {Fio} from "../../../models/models";

@Component({
  selector: 'app-fio',
  templateUrl: './fio.component.html',
  styleUrl: './fio.component.css'
})
export class FioComponent implements OnInit{
  fios: Fio[];

  constructor(private service:FioService,) {}
  ngOnInit() {
    this.getFio();


    // this.service.getAllFio().subscribe(fios => {
    //   this.fios = fios
    // })
  }
  getFio(){
    this.service.getAllFio().subscribe(
      fios => {
        this.fios = fios

      }
    )
    // this.service.getAllFio().subscribe(
    //   fios => {
    //     this.fios = fios
    //     this.loading = false
    //     console.log(fios)
    //   }
    // )
  }
}
