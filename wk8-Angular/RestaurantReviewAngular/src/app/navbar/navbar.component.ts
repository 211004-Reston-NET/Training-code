import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  name:string | undefined = ""

  constructor(public auth0:AuthService) 
  { 
    this.auth0.user$.subscribe((response) => {
      this.name = response?.name;
    });

  }

  ngOnInit(): void {
  }

}
