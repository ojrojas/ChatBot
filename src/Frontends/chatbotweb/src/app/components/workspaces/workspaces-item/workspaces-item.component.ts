import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-workspaces-item',
  imports: [
    CommonModule,
  ],
  templateUrl: './workspaces-item.component.html',
  styleUrl: './workspaces-item.component.scss',
})
export class WorkspacesItemComponent {
  chats = ['default'];
}
