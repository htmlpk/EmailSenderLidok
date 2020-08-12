import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Group } from '../models/group.model';
import { environment } from '../../../environments/environment';
import { BaseService } from './base/base.service';


@Injectable({providedIn:"root"})
export class GroupService extends BaseService<Group> {
  constructor(private http: HttpClient) {
    super(http,`${environment.apiUrl}group`)
   }
}