import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Review } from '../models/review';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-review-table',
  templateUrl: './review-table.component.html',
  styleUrls: ['./review-table.component.css']
})
export class ReviewTableComponent implements OnInit, OnChanges {


  @Input()
  restId:number = 0;

  @Input()
  show:boolean = true;

  listOfReview:Review[] = [];
  overallRating:number = 0;

  constructor(private http:RevAPIService)
  { 

  }

  ngOnChanges(changes: SimpleChanges): void {

    this.http.getReviewByRestId(this.restId).subscribe((response) => {
      this.listOfReview = response.item1;
      this.overallRating = response.item2;
    }) 
  }

  ngOnInit(): void {
  }

}
