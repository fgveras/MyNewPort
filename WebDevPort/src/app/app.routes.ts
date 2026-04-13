import { Routes } from '@angular/router';
import { Home } from './home/components/home.component';

export const routes: Routes = [

    {
        path: '',
        component: Home,
    },
    {
        path: "apod",
        loadChildren: () => 
            import('./APOD/APOD.routes').then(r => r.APOD_ROUTER)
    },
]