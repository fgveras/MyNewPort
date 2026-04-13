import { Routes } from '@angular/router';
import { ApodComponent } from './components/apod-component/apod-component.component';

export const APOD_ROUTER: Routes = [
    { path: "", component: ApodComponent, data: { title: "Astronomy Photo of the Day" } }
]