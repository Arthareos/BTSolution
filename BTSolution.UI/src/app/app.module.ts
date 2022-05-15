import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TokengenTitleComponent } from './shared/tokengen-title/tokengen-title.component';
import { TokengenUserbarComponent } from './shared/tokengen-userbar/tokengen-userbar.component';
import { TokengenUsercardComponent } from './shared/tokengen-usercard/tokengen-usercard.component';
import { TokengenAccesstokenbarComponent } from './shared/tokengen-accesstokenbar/tokengen-accesstokenbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TokengenAccesstokencardComponent } from './shared/tokengen-accesstokencard/tokengen-accesstokencard.component';

@NgModule({
  declarations: [
    AppComponent,
    TokengenTitleComponent,
    TokengenUserbarComponent,
    TokengenUsercardComponent,
    TokengenAccesstokenbarComponent,
    TokengenAccesstokencardComponent
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
