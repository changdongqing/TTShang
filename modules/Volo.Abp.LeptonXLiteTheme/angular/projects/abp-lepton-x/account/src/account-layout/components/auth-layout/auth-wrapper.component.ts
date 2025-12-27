import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TenantBoxComponent } from '../tenant-box/tenant-box.component';
import { LanguageSelectionComponent } from '@volo/ngx-lepton-x.lite';
import { LocalizationPipe, ReplaceableTemplateDirective } from '@abp/ng.core';
import { AccountLayoutService } from '../../services/account-layout.service';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'lpx-auth-wrapper',
  templateUrl: './auth-wrapper.component.html',
  imports: [
    CommonModule,
    LocalizationPipe,
    ReplaceableTemplateDirective,
    TenantBoxComponent,
    LanguageSelectionComponent,
  ],
  providers: [AccountLayoutService],
})
export class AuthWrapperComponent {
  service = inject(AccountLayoutService);
}
