import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantTableComponent } from './restaurant-table.component';

describe('RestaurantTableComponent', () => {
  let component: RestaurantTableComponent;
  let fixture: ComponentFixture<RestaurantTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
