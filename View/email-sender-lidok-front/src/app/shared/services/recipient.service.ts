import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipient } from '../models/recipient.model';
import { environment } from '../../../environments/environment';
import { BaseService } from './base/base.service';


@Injectable({providedIn:"root"})
export class RecipientService extends BaseService<Recipient> {
  constructor(private http: HttpClient) {
    super(http,`${environment.apiUrl}recipient`)
   }
}