import { Component, inject } from '@angular/core';
import { AccountService } from '../../../core/services/account-service';
import { DropdownButton } from "../../dropdown-button/dropdown-button";

@Component({
  selector: 'app-nav-profile-overview',
  imports: [DropdownButton],
  templateUrl: './nav-profile-overview.html',
  styleUrl: './nav-profile-overview.css'
})
export class NavProfileOverview {
  protected accountService = inject(AccountService);

  logout() {
    this.accountService.logout();
  }
}
