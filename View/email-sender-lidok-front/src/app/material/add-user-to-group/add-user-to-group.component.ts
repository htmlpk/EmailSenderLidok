import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Template } from '../../shared/models/template.model';
import { TemplateService } from '../../shared/services/template.service';
import { Recipient } from 'src/app/shared/models/recipient.model';
import { RecipientService } from 'src/app/shared/services/recipient.service';

export interface DialogData {
  users: Recipient[];
}

@Component({
  selector: 'add-user-to-group',
  templateUrl: 'add-user-to-group.component.html',
})


export class AddRecipientToGroup implements OnInit {
  public selectedUserId: string;
  public users: Recipient[];

  constructor(
    public dialogRef: MatDialogRef<AddRecipientToGroup>,
    public templateService: TemplateService,
    public recipientService: RecipientService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  async ngOnInit() {
    await this.recipientService.getAll().subscribe((users) => {
      debugger
      this.users = users.filter(x=>!this.data.users.some(r=>r.email == x.email));
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSendClick(): void {
    this.dialogRef.close(this.selectedUserId);
  }
}
