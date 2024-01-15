import {Component, OnDestroy, OnInit} from '@angular/core'
import {FormControl} from '@angular/forms'
import {Observable, catchError, debounceTime, map, of, startWith, switchMap, Subject, takeUntil} from 'rxjs'
import {CityLocatorService} from '../services/city.locator.service'

@Component({
  selector: 'app-auto-complete-textbox',
  templateUrl: './auto-complete-textbox.component.html',
  styleUrls: ['./auto-complete-textbox.component.scss'],
})
export class AutoCompleteTextboxComponent implements OnInit, OnDestroy {

  formControl: FormControl = new FormControl('')
  cities: string[] = []

  private $destroy = new Subject()

  constructor(private cityservice: CityLocatorService) {
  }

  lookup(value: string): Observable<string[]> {
    return this.cityservice.search(value.toLowerCase(), 2).pipe(
      map(results => results.cities),
      catchError(_ => {
        return of([])
      })
    )
  }

  ngOnInit() {
    this.formControl.valueChanges.pipe(
      takeUntil(this.$destroy),
      startWith(''),
      debounceTime(300),
      switchMap(value => value !== '' ? this.lookup(value) : of([]))
    ).subscribe(cities => this.cities = cities)
  }

  select(city: string) {
    this.formControl.setValue(city, {emitEvent: false})
    this.cities = []
  }

  ngOnDestroy(): void {
    this.$destroy.next(null)
  }

}
