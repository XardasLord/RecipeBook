import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { User } from '../user.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  user = new User();
  invalidLogin = false;

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
  }

  onSignIn() {
    this.authService.logIn(this.user).subscribe(jwt => {
      this.invalidLogin = false;
      localStorage.setItem('jwt', jwt.token);
      this.router.navigate(['/']);
    },
      (err: HttpErrorResponse) => {
      this.invalidLogin = true;
    });
  }

}
