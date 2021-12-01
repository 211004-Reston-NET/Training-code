import { Component, OnInit } from '@angular/core';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Restaurant } from '../models/restaurant';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-add-restaurant',
  templateUrl: './add-restaurant.component.html',
  styleUrls: ['./add-restaurant.component.css']
})
export class AddRestaurantComponent implements OnInit {

  restGroup:FormGroup = new FormGroup({
    name: new FormControl("", Validators.required),
    city: new FormControl("", Validators.required),
    state: new FormControl("", Validators.required)
  });

  constructor(private restService:RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }

  createRestaurant(restGroup: FormGroup)
  {
    //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
    if (restGroup.valid) {
      let restaurant:Restaurant = {
        name: restGroup.get("name")?.value,
        city: restGroup.get("city")?.value,
        state: restGroup.get("state")?.value
      };
  
      // console.log(restaurant);
  
      this.restService.createRestaurant(restaurant).subscribe(
        (response) => {
          console.log(response.id);
          this.router.navigateByUrl("/restaurant");
        }
      )
    }
  }
}
