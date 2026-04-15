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

  public imageSource: string = '';
  public exp: string = '';

  public isLoading: boolean = false;

  public testeHttp(){    
    this.isLoading = true;
    this._service.teste().subscribe({
      next: response => {
        this.exp = response.explanation;
        this.imageSource = response.hdurl;
        this.isLoading = false;
      }, error: error => {
        this.isLoading = false;
      }
    })
  }

  public clearImage(){
    this.imageSource = '';
    this.exp = '';
  }

  public download(){
    
    const link = document.createElement('a');
    link.href = this.imageSource;
    link.download = 'Astronomic Image Of the Day';
    link.target = '_blank';

    document.body.appendChild(link);
    link.click();
  }
}
