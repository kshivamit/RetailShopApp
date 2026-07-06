import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ProductsService, Product } from '../services/products.service';

@Component({
  selector: 'app-product-component',
  imports: [CommonModule, MatCardModule, MatButtonModule],
  templateUrl: './product-component.html',
  styleUrls: ['./product-component.css'],
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  loading = true;
  error = '';

  constructor(private productsService: ProductsService) {}

  ngOnInit() {
    this.productsService.getProducts().subscribe({
      next: (res) => {
        this.products = res;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load products';
        this.loading = false;
      }
    });
  }
}
