import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RecipientsComponent} from "./recipients/recipients.component"
import { GroupsComponent } from './groups/groups.component';
import { TemplatesComponent } from './templates/templates.component';

const routes: Routes = [
  { path: "", redirectTo:"recipients",pathMatch:"full"},
  { path: "recipients",  component: RecipientsComponent },
  { path: "templates",  component: TemplatesComponent },
  { path: "groups",  component: GroupsComponent },
  // { path: 'second-component', component: SecondComponent },
  // { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
