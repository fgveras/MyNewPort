import { Component } from '@angular/core';
import { ApodService } from '../../services/apod-service.service';
import { GetPhotoModel } from '../../models/GetPhotoModel';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-apod-component',
  imports: [ReactiveFormsModule],
  templateUrl: './apod-component.component.html',
  styleUrl: './apod-component.component.scss',
})
export class ApodComponent {

  constructor(
    private _service: ApodService,
  ){}

  public imageSource: string = '';
  public imageSource2: string = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ48gR5XDZPpi5F8QEitXQUPEBvgeksGD2OKg&s';
  public imageSource3: string = 'https://i.pinimg.com/236x/d8/ba/8a/d8ba8a1b747682d7a91a76fedf7660b0.jpg';
  public imageList: GetPhotoModel[] = [];
  public exp: string = '';

  public isLoading: boolean = false;
  public showPeriod: boolean = false;

  public form: FormGroup = new FormGroup({
    initDate: new FormControl<Date | string | null>(null),
    endDate: new FormControl<Date | string | null>(null),
  })

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

  public show(): void {
    this.showPeriod = !this.showPeriod;
  }

  public searchPeriod(): void {

    this.isLoading = true;
    this._service.getPeriod(this.form.get('initDate')?.value, this.form.get('endDate')?.value).subscribe({
      next: response => {        
        this.imageList = response;
        this.imageList.forEach(i => {
          if(i.hdurl === '')
            this.imageList = this.imageList.filter(j => j !== i);
        })
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

  public formatDate(oldDate: string): string {

    var splittedDateAndTime = oldDate.split('T');
    var date = splittedDateAndTime[0].split('-');
    var time = splittedDateAndTime[1].split(':');

    return `${date[2]}/${date[1]}/${date[0]}, ${time[0]}:${time[1]}:${time[0]}`

  }
}
