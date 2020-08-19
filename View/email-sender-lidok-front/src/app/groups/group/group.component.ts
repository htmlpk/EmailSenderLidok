import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Group } from 'src/app/shared/models/group.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { SendEmailRecipient } from 'src/app/material/send-email-recipient/send-email-recipient.component';
import { SendEmailGroupModel } from 'src/app/shared/models/send-email-recipient.model';
import { AddRecipientToGroup } from 'src/app/material/add-user-to-group/add-user-to-group.component';
import { AddRecipientToGroupModel } from 'src/app/shared/models/add-recipient-to-group';

@Component({
  selector: 'group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.sass']
})
export class GroupComponent implements OnInit {
  @Input() group: Group = new Group();
  @Input() createMode: boolean = false;
  @Output() onGroupCreated: EventEmitter<Group> = new EventEmitter();
  @Output() onSendEmail: EventEmitter<SendEmailGroupModel> = new EventEmitter();
  @Output() onRecipientAdd: EventEmitter<AddRecipientToGroupModel> = new EventEmitter();
  @Output() onCancell: EventEmitter<null> = new EventEmitter();

  groupCreation = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.min(5)]),
  });

  constructor(public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.createMode;
  }

  public sendEmailToGroup() {
    const dialogRef = this.dialog.open(SendEmailRecipient, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe(result => {
      let model = new SendEmailGroupModel();
      model.groupId = this.group.id;
      model.templateId = result
      this.onSendEmail.emit(model);
    });
  }

  public createGroup() {
    this.onGroupCreated.emit(this.group);
    this.createMode = !this.createMode;
  }

  public onCancel(){
    this.createMode = !this.createMode;
    this.onCancell.emit();
  }

  public addRecipient(){
    const dialogRef = this.dialog.open(AddRecipientToGroup, {
      width: '600px',
      data:{users:this.group.recipients}
    });

    dialogRef.afterClosed().subscribe(result => {
      let model = new AddRecipientToGroupModel();
      model.groupId = this.group.id;
      model.userId = result
      this.onRecipientAdd.emit(model);
    });
  }
}