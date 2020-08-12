// import './polyfills';

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, NgModel } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
// import {MaterialModule} from './material/material.module';
import { RecipientsComponent } from './recipients/recipients.component';
import { RecipientComponent } from './recipients/recipient/recipient.component';
import { GroupsComponent } from './groups/groups.component';
import { GroupComponent } from './groups/group/group.component';
import { TemplatesComponent } from './templates/templates.component';
import { TemplateComponent } from './templates/template/template.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SendEmailRecipient } from './material/send-email-recipient/send-email-recipient.component';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';


@NgModule({
  imports: [
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    // MaterialModule,
    CommonModule,
    // MatDialogRef,
    NgSelectModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  entryComponents: [SendEmailRecipient],
  declarations: [AppComponent,
    RecipientsComponent,
    RecipientComponent,
    GroupsComponent,
    GroupComponent,
    TemplatesComponent,
    TemplateComponent,
    ],
  // exports: [AppComponent,
  //   RecipientsComponent,
  //   RecipientComponent,
  //   GroupsComponent,
  //   GroupComponent,
  //   TemplatesComponent,
  //   TemplateComponent],
  bootstrap: [AppComponent],
  providers: [
    // { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },
  ]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));