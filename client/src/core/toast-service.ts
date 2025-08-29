import { Injectable, signal } from '@angular/core';
import { v4 as uuid } from 'uuid';

import { AlertType, ToastContent } from '../types/toast';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  toastContent = signal<ToastContent[]>([]);

  update(message: string, type: AlertType) {
    const info: ToastContent = { id: uuid(), message, type }
    this.toastContent.update(content => [info, ...content]);

    const interval = setInterval(() => {
      this.toastContent.update(content => content.slice(0, -1));

      if (this.toastContent().length === 0) clearInterval(interval);
    }, 5000);
  }
}
