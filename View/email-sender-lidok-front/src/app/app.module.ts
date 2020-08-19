import { HttpClientModule } from '@angular/common/http';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule, NgModel } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule } from '@angular/material/form-field';
import {MaterialModule} from './material/material.module';
import { RecipientsComponent } from './recipients/recipients.component';
import { RecipientComponent } from './recipients/recipient/recipient.component';
import { GroupsComponent } from './groups/groups.component';
import { GroupComponent } from './groups/group/group.component';
import { TemplatesComponent } from './templates/templates.component';
import { TemplateComponent } from './templates/template/template.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SendEmailRecipient } from './material/send-email-recipient/send-email-recipient.component';
import { AddRecipientToGroup } from './material/add-user-to-group/add-user-to-group.component';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {MatSelectModule} from '@angular/material/select';
import { MatRippleModule } from '@angular/material/core';
import { NgxSelectModule, INgxSelectOptions } from 'ngx-select-ex';
import {Sidenav} from './material/sidenav/sidenav.component'

@NgModule({
  imports: [
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    MatDialogModule,
    BrowserAnimationsModule,
    NgxSelectModule
  ],
  entryComponents: [SendEmailRecipient,
    AddRecipientToGroup],
  declarations: [AppComponent,
    RecipientsComponent,
    RecipientComponent,
    GroupsComponent,
    GroupComponent,
    TemplatesComponent,
    TemplateComponent,
    SendEmailRecipient,
    AddRecipientToGroup,
    Sidenav
    ],
  bootstrap: [AppComponent],
  providers: [
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },
  ],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));