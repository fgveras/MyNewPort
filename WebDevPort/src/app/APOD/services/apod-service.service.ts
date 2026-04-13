import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take, tap } from 'rxjs';
import { GlobalResponse } from '../../../models/returns-types/global-response';

@Injectable({
  providedIn: 'root',
})

export class ApodService {
  
  private readonly _BASE_URL: string = 'http://localhost:5278';
  
  constructor(
    private _HttpClient: HttpClient
  ){
    this._BASE_URL = `http://localhost:5278/Apod`;
  }

  public teste(): Observable<GlobalResponse> {

    const params = new HttpParams()

    const headers = new HttpHeaders()
    
    const url = `${this._BASE_URL}/teste`;

    return this._HttpClient.get<GlobalResponse>(url, {params: params, headers: headers})
      .pipe(take(1), tap(response => {
        this.showErrorMessage(response)
    }))

  }

  private showErrorMessage(response: GlobalResponse): void { if (response.Error) throw Error(response.Error); }
}
