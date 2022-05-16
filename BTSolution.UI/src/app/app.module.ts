import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TitleComponent } from './components/title/title.component';
import { TokenCardComponent } from './components/token-card/token-card.component';
import { UserCardComponent } from './components/user-card/user-card.component';
import { UserBarComponent } from './components/user-bar/user-bar.component';
import { HttpClientModule } from "@angular/common/http";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { TokenBarComponent } from './components/token-bar/token-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    TitleComponent,
    TokenCardComponent,
    UserCardComponent,
    UserBarComponent,
    TokenBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
