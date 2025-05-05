import { Component } from '@angular/core';
import { WorkspacesListComponent } from "./workspaces-list/workspaces-list.component";

@Component({
  selector: 'app-workspaces',
  imports: [WorkspacesListComponent],
  templateUrl: './workspaces.component.html',
  styleUrl: './workspaces.component.css'
})
export class WorkspacesComponent {

}
