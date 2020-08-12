import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { BaseService } from './base/base.service';
import { SendEmailRecipientModel } from '../models/send-email-recipient.model';
import { Email } from '../models/email.model';
import { Observable } from 'rxjs';


@Injectable({providedIn:"root"})
export class EmailService extends BaseService<Email> {
  constructor(private http: HttpClient) {
    super(http,`${environment.apiUrl}email`)
   }

   public async createSingle(model:SendEmailRecipientModel){
       return await this.http.post(`${environment.apiUrl}email/createSingle`,model) as Observable<null>;
   }

}