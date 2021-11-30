import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RestaurantTableComponent } from './restaurant-table/restaurant-table.component';
import { HttpClientModule } from "@angular/common/http";
import { ReviewTableComponent } from './review-table/review-table.component';
import { RouterModule } from '@angular/router';
import { AuthGuard, AuthModule } from '@auth0/auth0-angular';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { PokemonComponent } from './pokemon/pokemon.component';
import { ReactiveFormsModule } from '@angular/forms';

/*
  Like csproj in C#, app.module.ts defines all the dependencies that your angular application will need
*/

@NgModule({
  //This will hold reference to our components
  declarations: [
    AppComponent,
    RestaurantTableComponent,
    ReviewTableComponent,
    NavbarComponent,
    LoginComponent,
    PokemonComponent
  ],

  //This will hold references to Module
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
      clientId: "ZrLI7eQUchr5Kjq8i4sur34PoCLLV8bR",
      domain: "dev-7hg9m6jt.us.auth0.com"
    }),
    RouterModule.forRoot([
      //Order matters and wildcard should be at the very bottom
      {path: "restaurant", component:RestaurantTableComponent},
      {path: "review", component:ReviewTableComponent},
      {path: "pokemon", component:PokemonComponent, canActivate:[AuthGuard]},
      {path: "**", component:RestaurantTableComponent} //** is a wild card that any other url you ask for as a user will always point to restaurantTableComponent
    ]),
  ],

  //This is where you reference your services
  providers: [],


  bootstrap: [AppComponent]
})
export class AppModule { }
