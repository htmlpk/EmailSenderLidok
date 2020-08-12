import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Recipient } from '../../shared/models/recipient.model';
import { SendEmailRecipientModel } from '../../shared/models/send-email-recipient.model';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { SendEmailRecipient } from 'src/app/material/send-email-recipient/send-email-recipient.component';


@Component({
  selector: 'recipient',
  templateUrl: './recipient.component.html',
  styleUrls: ['./recipient.component.sass']
})
export class RecipientComponent implements OnInit {
  @Input() recipient: Recipient = new Recipient();
  @Input() createMode: boolean = false;
  @Output() onRecipientCreated: EventEmitter<Recipient> = new EventEmitter();
  @Output() onEmailSended: EventEmitter<SendEmailRecipientModel> = new EventEmitter();

  recipientCreation = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
  });

  constructor(public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.createMode;
  }
  change(){
    this.recipientCreation;
  }

  public createRecipient() {
    this.onRecipientCreated.emit(this.recipient);
    this.createMode = !this.createMode;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(SendEmailRecipient, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      let model = new SendEmailRecipientModel();
      debugger
      model.recipientId = this.recipient.id;
      model.templateId = result
      this.onEmailSended.emit(model);
    });
  }
}
