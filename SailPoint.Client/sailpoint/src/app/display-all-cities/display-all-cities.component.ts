import { Component, OnInit } from '@angular/core';
import { CityLocatorService } from '../services/city.locator.service';
import { map } from 'rxjs';

@Component({
  selector: 'app-display-all-cities',
  templateUrl: './display-all-cities.component.html',
  styleUrls: ['./display-all-cities.component.scss'],
})
export class DisplayAllCitiesComponent implements OnInit {
  cities: string[] = [];
  cities$ = this.cityLocatorService
    .getAllCities()
    .pipe(map((response) => response.cities));

  constructor(private cityLocatorService: CityLocatorService) {}

  ngOnInit(): void {
    // this.cityLocatorService.getAllCities().pipe(
    //   map((response) => {
    //     this.cities = response.cities;
    //   })
    // );
  }

  getColor(city: string): string {
    // debugger;
    if (city.indexOf('test') === 0) {
      return 'red';
    }
    return 'black';
  }
}
