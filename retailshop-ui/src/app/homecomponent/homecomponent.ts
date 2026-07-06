import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login-component/login-component';
import { AuthService } from '../services/auth.service';
												 
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-homecomponent',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './homecomponent.html',
  styleUrls: ['./homecomponent.css']
})
export class Homecomponent {

}

