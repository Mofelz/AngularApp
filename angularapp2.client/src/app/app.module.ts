import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FioComponent } from './components/fio/fio.component';
import { CompanyComponent } from './components/company/company.component';
@NgModule({
  declarations: [
    AppComponent,
    FioComponent,
    CompanyComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
