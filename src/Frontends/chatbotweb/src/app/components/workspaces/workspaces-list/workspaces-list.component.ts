import { Component } from '@angular/core';
import { WorkspacesItemComponent } from "../workspaces-item/workspaces-item.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-workspaces-list',
  imports: [
    WorkspacesItemComponent,
    CommonModule
  ],
  templateUrl: './workspaces-list.component.html',
  styleUrl: './workspaces-list.component.scss'
})
export class WorkspacesListComponent {
  workspaces = ['1'];
}
