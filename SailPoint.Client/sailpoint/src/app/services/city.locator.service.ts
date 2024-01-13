import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CitiesDto } from '../Models/CitiesDto';

@Injectable({
  providedIn: 'root'
})
export class CityLocatorService {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = "https://localhost:7138/cities";
  }

  getAllCities(): Observable<CitiesDto> {
    return this.http.get<CitiesDto>(this.baseUrl);
  }

  search(prefix:string , level: number): Observable<CitiesDto> {
    const url = `${this.baseUrl}/${prefix}/level/${level}`;
    return this.http.get<CitiesDto>(url);
  }


}
