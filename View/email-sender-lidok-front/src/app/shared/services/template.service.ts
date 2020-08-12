import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Template } from '../models/template.model';

import { BaseService } from './base/base.service';


@Injectable({providedIn:"root"})
export class TemplateService extends BaseService<Template> {
  constructor(private http: HttpClient) {
    super(http,`${environment.apiUrl}template`)
   }
}