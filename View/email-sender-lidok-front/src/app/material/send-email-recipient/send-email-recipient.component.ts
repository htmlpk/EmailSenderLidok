import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Template } from '../../shared/models/template.model';
import { TemplateService } from '../../shared/services/template.service';

@Component({
  selector: 'send-email-recipient',
  templateUrl: 'send-email-recipient.component.html',
})
export class SendEmailRecipient implements OnInit {
  public selectedTemplateId: string;
  public templates: Template[];

  constructor(
    public dialogRef: MatDialogRef<SendEmailRecipient>,
    public templateService: TemplateService
  ) { }

  async ngOnInit() {
    await this.templateService.getAll().subscribe((templates) => {
      this.templates = templates;
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSendClick(): void {
    this.dialogRef.close(this.selectedTemplateId);
  }
}
