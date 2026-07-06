import { Component } from '@angular/core';

@Component({
  selector: 'app-aboutuscomponent',
  imports: [],
  templateUrl: './aboutuscomponent.html',
  styleUrl: './aboutuscomponent.css',
})
export class Aboutuscomponent {

  companyName = 'RetailShop';

  features = [
    'Wide range of quality products',
    'Secure online payments',
    'Fast and reliable delivery',
    'Easy returns and refunds',
    '24/7 Customer Support'
  ];

}
