import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { CityLocatorService } from '../services/city.locator.service';
import { Observable, map, tap } from 'rxjs';
import { LoaderIndicatorService } from '../services/loader-indicator.service';

@Component({
  selector: 'app-display-all-cities',
  templateUrl: './display-all-cities.component.html',
  styleUrls: ['./display-all-cities.component.scss'],
})
export class DisplayAllCitiesComponent implements OnInit {
  cities$: Observable<string[]> = new Observable<string[]>();

  col: number = 4;
  rowHeight = '3rem';

  loading$ = this.loaderService.loader$;

  constructor(
    private cityLocatorService: CityLocatorService,
    private breakpointObserver: BreakpointObserver,
    private loaderService: LoaderIndicatorService
  ) {
    this.breakpointObserver
      .observe([Breakpoints.Small, Breakpoints.Medium, Breakpoints.Large])
      .subscribe((result) => {
        const breakpoints = result.breakpoints;

        if (breakpoints[Breakpoints.Large]) {
          this.col = 10;
          this.rowHeight = '2rem';
        } else {
          if (breakpoints[Breakpoints.Medium]) {
            this.col = 7;
            this.rowHeight = '2.5rem';
          } else {
            this.col = 4;
            this.rowHeight = '3rem';
          }
        }
      });
  }

  ngOnInit(): void {
    this.cities$ = this.cityLocatorService.getAllCities().pipe(
      tap((res) => {
        console.log(res.cities);
      }),
      map((response) => response.cities)
    );
  }

  getColor(city: string): string {
    // debugger;
    if (city.indexOf('test') === 0) {
      return 'red';
    }
    return 'black';
  }
}
