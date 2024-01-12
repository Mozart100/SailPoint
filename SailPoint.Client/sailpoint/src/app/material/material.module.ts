import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';



const modules = [MatIconModule,MatListModule,MatCardModule, MatTabsModule ,MatInputModule,MatFormFieldModule,MatSidenavModule,MatButtonModule, BrowserAnimationsModule, MatToolbarModule,  MatTableModule];

@NgModule({
  imports: [modules],
  exports: [modules]
})
export class MaterialModule { }