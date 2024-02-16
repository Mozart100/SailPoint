import { Component, OnInit } from '@angular/core';
import { CityLocatorService } from '../services/city.locator.service';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-display-all-cities',
  templateUrl: './display-all-cities.component.html',
  styleUrls: ['./display-all-cities.component.scss'],
})
export class DisplayAllCitiesComponent implements OnInit {
  cities$:Observable<string[]> = new Observable<string[]>();
  
  constructor(private cityLocatorService: CityLocatorService) {}

  ngOnInit(): void {
    this.cities$ = this.cityLocatorService
    .getAllCities()
    .pipe(map((response) => response.cities));
  }

  getColor(city: string): string {
    // debugger;
    if (city.indexOf('test') === 0) {
      return 'red';
    }
    return 'black';
  }
}
