import { Component, OnInit } from '@angular/core';
import { TemplateService } from '../shared/services/template.service';
import { Template } from '../shared/models/template.model';

@Component({
  selector: 'templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.sass'],
})
export class TemplatesComponent implements OnInit {

  public templates: Array<Template>;
  public createMode: boolean;

  constructor(private templateService: TemplateService) { }

  async ngOnInit() {
    await this.templateService.getAll().subscribe((templates) => {
      this.templates = templates;
    })
  }

  public async onTemplateCreate(template: Template) {
    await this.templateService.create(template).subscribe(() => {
      this.templates.push(template)
    });
  }

  public toggleCreateMod(){
    this.createMode = !this.createMode;
  }

}
