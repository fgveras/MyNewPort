import { Routes } from "@angular/router";
import { FinnasHome } from "./components/finnas-home/finnas-home";


export const FINNAS_ROUTING: Routes = [
    { path: "", component: FinnasHome, data: {Title: 'Controle Financeiro'} }
]