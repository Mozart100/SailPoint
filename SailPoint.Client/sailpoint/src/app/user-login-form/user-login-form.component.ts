import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user-login-form',
  templateUrl: './user-login-form.component.html',
  styleUrls: ['./user-login-form.component.scss'],
})
export class UserLoginFormComponent implements OnInit {
  signupForm!: FormGroup;
  
  ngOnInit(): void {
    this.signupForm = new FormGroup({
      'userName':new FormControl(null),
      'email':new FormControl(null),
    });
  }
}
