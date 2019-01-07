import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(private toastrService: ToastrService) { }

  logout() {
    localStorage.removeItem('jwt');
    this.toastrService.success(`You have been successfully logged out!`, `Success`);
  }
}
