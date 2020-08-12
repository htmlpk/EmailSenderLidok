import { Component, OnInit } from '@angular/core';
import { Group } from '../shared/models/group.model';
import { GroupService } from '../shared/services/group.service';

@Component({
  selector: 'groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.sass'],
})
export class GroupsComponent implements OnInit {

  public groups: Array<Group>;
  public createMode = false;

  constructor(private groupService:GroupService) { }

  async ngOnInit() {
   await this.groupService.getAll().subscribe((groups)=>{
     this.groups = groups;
   })
  }

  public async onGroupCreate(group: Group){
    await this.groupService.create(group).subscribe(() => {
      this.groups.push(group)
      this.toggleCreateMode();
    });
  }

  public toggleCreateMode(){
    this.createMode = !this.createMode;
  }

}
