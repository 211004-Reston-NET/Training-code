import { DOCUMENT } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-spa-js';
import { first, firstValueFrom, lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public auth0:AuthService, @Inject(DOCUMENT) public document:Document, private http:HttpClient) { }

  ngOnInit(): void {
    this.auth0.loginWithPopup({screen_hint:'signup'});

    // this.auth0.user$.subscribe((response) => {
    //   response?.name;
    // });
    
    this.test();
  }

  async test()
  {
    let endpoint:string = "it exists";

    let user: User | null | undefined;
    user = await firstValueFrom(this.auth0.user$);

    let userId: number;
    userId = await firstValueFrom(this.http.get<number>(`${endpoint}/user/userid/${user?.email}`));

    let favoriteList;
    favoriteList = await firstValueFrom(this.http.get<any>(`${endpoint}/favoriteList/user/${userId}`));


    // this.auth0.user$.subscribe((user) => {
    //   this.http.get<number>(`${this.endpoint}/user/userid/${user?.email}`).subscribe((userId) => {
    //     console.log(userId);
    //     return this.http.get<any>(`${this.endpoint}/favoriteList/user/${userId}`);
    //   })
    // })

  }



}
