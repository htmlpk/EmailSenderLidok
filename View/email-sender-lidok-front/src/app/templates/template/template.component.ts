import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Template } from 'src/app/shared/models/template.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.sass']
})
export class TemplateComponent implements OnInit {
  @Input() template: Template = new Template();
  @Input() createMode : boolean = false;
  @Output() onTemplateSaved : EventEmitter<Template> = new EventEmitter();

  templateCreation  = new FormGroup({
    subject: new FormControl('',[Validators.required,Validators.minLength(6)]),
    body: new FormControl('',[Validators.required,Validators.minLength(20)]),
  }, );

  constructor() {
   }

  ngOnInit(): void {
    this.createMode;
  }

  public change(){
    this.templateCreation;
  }

  public saveTemplate(){
    this.onTemplateSaved.emit(this.template);
    this.createMode = !this.createMode;
  }

}
