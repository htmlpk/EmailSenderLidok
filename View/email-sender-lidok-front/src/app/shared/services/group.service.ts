import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Group } from '../models/group.model';
import { environment } from '../../../environments/environment';
import { BaseService } from './base/base.service';
import { AddRecipientToGroupModel } from '../models/add-recipient-to-group';


@Injectable({providedIn:"root"})
export class GroupService extends BaseService<Group> {
  constructor(private http: HttpClient) {
    super(http,`${environment.apiUrl}group`)
   }
   public async addRecipient(model:AddRecipientToGroupModel){
     return await this.http.post(`${environment.apiUrl}group/addRecipientToGroup`,model)
   }
}