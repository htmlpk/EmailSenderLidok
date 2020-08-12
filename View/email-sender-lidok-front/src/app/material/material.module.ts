import {NgModule} from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SendEmailRecipient } from './send-email-recipient/send-email-recipient.component';

@NgModule({
  exports: [
    MatDialogRef
  ],
  entryComponents:[SendEmailRecipient],
  declarations:[SendEmailRecipient]

})
export class MaterialModule {}

