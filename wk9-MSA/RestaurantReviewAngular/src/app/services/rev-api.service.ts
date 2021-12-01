import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Restaurant } from '../models/restaurant';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class RevAPIService {

  private endpoint:string = "https://211004-rr-web-app.azurewebsites.net/api";

  constructor(private http:HttpClient) { }

  //This will give us a list of restaurant from RevWebAPI
  //Will return an observable that is a list of restaurant
  getAllRestaurant() :Observable<Restaurant[]>
  {
    //httpclient get() method will do a get request to the api
    //Make sure you got the endpoint right
    return this.http.get<Restaurant[]>(this.endpoint + "/Restaurant/All");
  }

  //This will give me a list of reviews based on the restId
  getReviewByRestId(p_id:number) : Observable<any>
  {
    return this.http.get<any>(this.endpoint + "/Review/" + p_id);
  }


}
