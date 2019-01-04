import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../user.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private authService: AuthService,
              private router: Router,
              private toastrService: ToastrService) { }

  ngOnInit() {
  }

  onSignUp(form: NgForm) {
    if (form.invalid) {
      return;
    }

    const user = new User();
    user.email = form.value.email;
    user.password = form.value.password;

    this.authService.register(user).subscribe(() => {
      this.router.navigate(['/']);
      this.toastrService.success(`User with email: ${user.email} has been registered! Please log in.`, `New user`);
    });
  }

}
