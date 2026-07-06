import { Routes } from '@angular/router';
import { Homecomponent } from './homecomponent/homecomponent';
import { LoginComponent } from './login-component/login-component';
import { ProductComponent } from './product-component/product-component';
import { Aboutuscomponent } from './aboutuscomponent/aboutuscomponent';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: Homecomponent },
  { path: 'login', component: LoginComponent },
  { path: 'products', component: ProductComponent },
  { path: 'abouts', component: Aboutuscomponent },
  { path: '**', redirectTo: 'home' }
];
