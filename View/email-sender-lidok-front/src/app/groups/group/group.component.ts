import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Group } from 'src/app/shared/models/group.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.sass']
})
export class GroupComponent implements OnInit {
  @Input() group: Group = new Group();
  @Input() createMode: boolean = false;
  @Output() onGroupCreated: EventEmitter<Group> = new EventEmitter();

  groupCreation = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.min(5)]),
  });

  constructor() {
  }

  ngOnInit(): void {
    this.createMode;
  }

  public createGroup() {
    this.onGroupCreated.emit(this.group);
    this.createMode = !this.createMode;
  }
}