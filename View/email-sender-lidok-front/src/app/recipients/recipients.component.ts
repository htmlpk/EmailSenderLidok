import { Component, OnInit } from '@angular/core';
import { EmailService } from '../shared/services/email.service';
import { RecipientService } from '../shared/services/recipient.service';
import { Recipient } from '../shared/models/recipient.model';
import { SendEmailRecipientModel } from '../shared/models/send-email-recipient.model';

@Component({
  selector: 'app-recipients',
  templateUrl: './recipients.component.html',
  styleUrls: ['./recipients.component.sass'],
})
export class RecipientsComponent implements OnInit {

  public recipients: Array<Recipient>;
  public createMode = false;

  constructor(private recipientService: RecipientService, private emailService: EmailService) {
   }

  async ngOnInit() {
    await this.recipientService.getAll().subscribe((recipients) => {
      this.recipients = recipients;
    })
  }

  public async onRecipientCreate(recipient: Recipient) {
    await this.recipientService.create(recipient).subscribe(() => {
      this.recipients.push(recipient)
      this.toggleCreateMode();
    });
  }

  public toggleCreateMode() {
    this.createMode = !this.createMode;
  }

  public async onEmailSend(model: SendEmailRecipientModel) {
    debugger
    if(model.templateId)
    await (await this.emailService.createSingle(model)).subscribe()
  }
}
