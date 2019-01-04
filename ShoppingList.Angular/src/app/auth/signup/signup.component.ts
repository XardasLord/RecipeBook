import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../user.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  user = new User();

  constructor(private authService: AuthService,
              private router: Router,
              private toastrService: ToastrService) { }

  ngOnInit() {
  }

  onSignUp() {
    this.authService.register(this.user).subscribe(() => {
      this.router.navigate(['/']);
      this.toastrService.success(`User with email: ${this.user.email} has been registered! Please log in.`, `New user`);
    });
  }

}
