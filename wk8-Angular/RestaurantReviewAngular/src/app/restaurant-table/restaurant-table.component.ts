import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Restaurant } from '../models/restaurant';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  //selector property is used to identity this particular component in an html file
  selector: 'app-restaurant-table',

  /*
    templateUrl property - references the html file associated with this component
    styleUrls property - references the css file(s) associated with this component
  */
  templateUrl: './restaurant-table.component.html',
  styleUrls: ['./restaurant-table.component.css']
})
export class RestaurantTableComponent implements OnInit {

  listOfRest:Restaurant[] = [];
  show:boolean | null = false;

  constructor(private revApi:RevAPIService, private router:Router, public auth0:AuthService) 
  { 
    /*
      - getAllRestaurant() returns an observable
      - An observable can subscribe to some publisher (mostly an api)
      - When subscribed, it will continue to listen to the publish and will consume any data they publish
      - We used an arrow function to grab that response and do some sort of logic to it
    */

    revApi.getAllRestaurant().subscribe((response) => {
      
      //It will set the show property to false to each element and also add it to our listOfRest
      response.forEach(element => {
        element.show = false;
        this.listOfRest.push(element);
      });
    });
  }

  //@method decorator
  ngOnInit(): void {

  }

  showTable()
  {
    this.show = !this.show;
  }

  showReview(p_id:number|undefined)
  {
    //This gets the current index of the element it found on the array
    let index:number = this.listOfRest.findIndex(rest => rest.id==p_id);

    //This flips that show property of it
    this.listOfRest[index].show = !this.listOfRest[index].show;
  }

  redirectToAddRest()
  {
    this.router.navigateByUrl("addRest");
  }

}
