import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, catchError, debounceTime, map, of, startWith, switchMap } from 'rxjs';
import { CityLocatorService } from '../services/city.locator.service';

@Component({
  selector: 'app-auto-complete-textbox',
  templateUrl: './auto-complete-textbox.component.html',
  styleUrls: ['./auto-complete-textbox.component.scss'],
})
export class AutoCompleteTextboxComponent implements OnInit {
  cities$!:Observable<string[]>;
  formControl: FormControl = new FormControl('');

  constructor(private cityservice: CityLocatorService) {}

  lookup(value: string): Observable<string[]> {
    return this.cityservice.search(value.toLowerCase(),2).pipe(
      map(results => results.cities),
      catchError(_ => {
        return of([]);
      })
    );
  }

  ngOnInit() {
    this.cities$ = this.formControl.valueChanges.pipe(
      startWith(''),
      debounceTime(300),
      switchMap(value => {
        if (value !== '') {
          return this.lookup(value);
        } else {
          // if no value is pressent, return null
          return of([]);
        }
      })
    );
  }
}
