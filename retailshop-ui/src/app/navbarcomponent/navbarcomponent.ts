import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

import { LoginComponent } from '../login-component/login-component';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './navbarcomponent.html',
  styleUrls: ['./navbarcomponent.css']
})
export class NavbarComponent {

  searchText = '';

  isLoginedIn = true;

  constructor(
    private dialog: MatDialog,
    private authService: AuthService
  ) { }

  openLogin() {

    const dialogRef = this.dialog.open(LoginComponent, {
      width: '420px'
    });

    dialogRef.afterClosed().subscribe(result => {

      if (result === true) {

        this.isLoginedIn = false;
      }
    });
  }

  logout() 
  {
    this.authService.logout();
    this.isLoginedIn = true;
  }

  searchProduct() {
    console.log(this.searchText);

    // Later call Product Search API
  }
}