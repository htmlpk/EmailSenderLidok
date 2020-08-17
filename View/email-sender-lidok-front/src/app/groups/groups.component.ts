import { Component, OnInit } from '@angular/core';
import { Group } from '../shared/models/group.model';
import { GroupService } from '../shared/services/group.service';
import { EmailService } from '../shared/services/email.service';
import { SendEmailRecipientModel, SendEmailGroupModel } from '../shared/models/send-email-recipient.model';
import { AddRecipientToGroup } from '../material/add-user-to-group/add-user-to-group.component';
import { AddRecipientToGroupModel } from '../shared/models/add-recipient-to-group';

@Component({
  selector: 'groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.sass'],
})
export class GroupsComponent implements OnInit {

  public groups: Array<Group>;
  public createMode = false;

  constructor(private groupService: GroupService, private emailService: EmailService) { }

  async ngOnInit() {
    await this.groupService.getAll().subscribe((groups) => {
      debugger
      this.groups = groups;
    })
  }

  public async onGroupCreate(group: Group) {
    await this.groupService.create(group).subscribe(() => {
      this.groups.push(group)
      this.toggleCreateMode();
    });
  }

  public async onEmailSend(model: SendEmailGroupModel) {
    debugger
    await (await this.emailService.createGroup(model)).subscribe();
  }

  public async onRecipientAdd(model:AddRecipientToGroupModel){
    debugger
    if(model.groupId)
    await (await this.groupService.addRecipient(model)).subscribe();
  }

  public toggleCreateMode() {
    this.createMode = !this.createMode;
  }

}
