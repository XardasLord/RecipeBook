import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isUserLoggedIn = false;
  loggedUserEmail = '';

  constructor(private toastrService: ToastrService,
              private authService: AuthService,
              private jwtHelper: JwtHelperService,
              private router: Router) { }

  ngOnInit() {
    this.authService.onUserLoggedIn.subscribe(loggedUser => {
      this.isUserLoggedIn = true;
      this.loggedUserEmail = loggedUser.email;
    });

    this.authService.onUserLoggedOut.subscribe(() => {
      this.isUserLoggedIn = false;
      this.loggedUserEmail = '';
    });

    if (this.isTokenAvailableAndValid()) {
      this.isUserLoggedIn = true;
      // Name of the logged in user from token?
    }
  }

  logout() {
    localStorage.removeItem('jwt');
    this.toastrService.success(`You have been successfully logged out!`, `Success`);
    this.authService.onUserLoggedOut.next(true);

    this.router.navigate(['/']);
  }

  private isTokenAvailableAndValid() {
    const token = localStorage.getItem('jwt');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }

    return false;
  }
}
