import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FioComponent } from './components/fio/fio.component';
import { CompanyComponent } from './components/company/company.component';
import {FormsModule} from "@angular/forms";
@NgModule({
  declarations: [
    AppComponent,
    FioComponent,
    CompanyComponent,
  ],
    imports: [
        BrowserModule, HttpClientModule,
        AppRoutingModule, FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
