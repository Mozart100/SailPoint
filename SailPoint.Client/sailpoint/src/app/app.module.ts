import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { AutoCompleteTextboxComponent } from './auto-complete-textbox/auto-complete-textbox.component';
import { RouterModule, Routes } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DisplayAllCitiesComponent } from './display-all-cities/display-all-cities.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserLoginFormComponent } from './user-login-form/user-login-form.component';
import { HttpInterceptorService } from './services/http-interceptor.service';

const appRoutes: Routes = [
  {
    path: '',
    component: DisplayAllCitiesComponent,
  },
  {
    path: 'autocomplete',
    component: AutoCompleteTextboxComponent,
  },
  {
    path: 'displayallcities',
    component: DisplayAllCitiesComponent,
  },

  {
    path: 'login',
    component: UserLoginFormComponent,
  },
];

@NgModule({
  declarations: [
    AppComponent,
    AutoCompleteTextboxComponent,
    DisplayAllCitiesComponent,
    UserLoginFormComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
