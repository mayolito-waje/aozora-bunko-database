import { Component, inject } from '@angular/core';
import { ToastService } from '../../core/toast-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toast',
  imports: [CommonModule],
  templateUrl: './toast.html',
  styleUrl: './toast.css'
})
export class Toast {
  protected toastService = inject(ToastService);
}
