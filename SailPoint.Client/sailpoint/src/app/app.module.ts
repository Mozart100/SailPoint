import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { AutoCompleteTextboxComponent } from './auto-complete-textbox/auto-complete-textbox.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { DisplayAllCitiesComponent } from './display-all-cities/display-all-cities.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserLoginFormComponent } from './user-login-form/user-login-form.component';

const appRoutes: Routes = [
  {
    path: '',
    component: UserLoginFormComponent,
  },
  {
    path: 'autocomplete',
    component: AutoCompleteTextboxComponent,
  },
  {
    path: 'displayallcities',
    component: DisplayAllCitiesComponent,
  },
   
];

@NgModule({
  declarations: [
    AppComponent,
    AutoCompleteTextboxComponent,
    DisplayAllCitiesComponent,
    UserLoginFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
