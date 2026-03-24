import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login-component/login-component';
import { AuthService } from '../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-homecomponent',
  imports: [CommonModule],
  templateUrl: './homecomponent.html',
  styleUrl: './homecomponent.css',
})
export class Homecomponent {

  logout() {
    this.authService.logout();
    this.isLoginedIn = true;
  }

  constructor(private dialog: MatDialog, 
    private authService: AuthService
    ) {}
  
  isLoginedIn:  boolean  = true;

openLogin() {
  const dialogRef = this.dialog.open(LoginComponent, {
    width: '400px'
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.isLoginedIn = !this.isLoginedIn;
      console.log('Login data:', result);
    }
  });
}
}
