import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-login-form',
  templateUrl: './user-login-form.component.html',
  styleUrls: ['./user-login-form.component.scss'],
})
export class UserLoginFormComponent implements OnInit {
  signupForm!: FormGroup;
  userNamesInvalid =["xxx","kkk"];
  
  ngOnInit(): void {
    this.signupForm = new FormGroup({
      'userName':new FormControl(null,[Validators.required,this.forbiddenNames.bind(this)]),
      'email':new FormControl(null,[Validators.required,Validators.email]),
    });
  }

  onSubmit()
  {
    console.log(this.signupForm);
  }

  forbiddenNames(control:FormControl): {[key:string]:boolean} | null
  {
    if(this.userNamesInvalid.indexOf(control.value)>=0)
    {
        return {"xxx":true};
    }

    return null;
  }
}
