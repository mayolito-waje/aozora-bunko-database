import { Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-auth-wrapper',
  imports: [FormsModule],
  templateUrl: './auth-wrapper.html',
  styleUrl: './auth-wrapper.css'
})
export class AuthWrapper {
  submit = output();
  label = input.required<string>();

  handleSubmit() {
    this.submit.emit();
  }
}
