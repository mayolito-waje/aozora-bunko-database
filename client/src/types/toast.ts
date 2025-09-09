export type AlertType = 'info' | 'success' | 'warning' | 'error';

export interface ToastContent {
  id: string;
  message: string;
  type?: AlertType;
}
