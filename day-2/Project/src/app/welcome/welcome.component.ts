import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent {
  username: string | null = null;

  constructor(private router: Router) {
    this.username = localStorage.getItem('username');
  }

  goToLogin() {
    // Clear username on logout (optional)
    localStorage.removeItem('username');
    this.router.navigate(['/']);
  }
}
