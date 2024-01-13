import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';

@Component({
  selector: 'app-auto-complete-textbox',
  templateUrl: './auto-complete-textbox.component.html',
  styleUrls: ['./auto-complete-textbox.component.scss'],
})
export class AutoCompleteTextboxComponent implements OnInit {
  colorArray = ['red', 'blue', 'green'];
  filterOptions!: Observable<string[]>;
  formControl: FormControl = new FormControl('');

  ngOnInit(): void {
    this.filterOptions = this.formControl.valueChanges.pipe(
      startWith(''),
      map((value) => this._FILTER(value || ''))
    );
  }

  private _FILTER(target: string): string[] {
    const searchValue = target.toLocaleLowerCase();
    return this.colorArray.filter((x) =>
      x.toLocaleLowerCase().includes(searchValue)
    );
  }
}
