import { Component } from '@angular/core';
import { ApodService } from '../../services/apod-service.service';

@Component({
  selector: 'app-apod-component',
  imports: [],
  templateUrl: './apod-component.component.html',
  styleUrl: './apod-component.component.scss',
})
export class ApodComponent {

  constructor(
    private _service: ApodService,
  ){}

  public testeHttp(){
    this._service.teste().subscribe({
      next: response => {
        alert(response.Data);
      }, error: error => {
        
      }
    })
  }
}
