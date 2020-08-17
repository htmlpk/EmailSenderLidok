import { Component, Input, Type } from '@angular/core';
 
@Component({
  selector: 'dropdown',
  templateUrl: './drop-down.component.html'
})

export class DropDown {
@Input() items = T[];

}