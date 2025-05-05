import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NgIcon, provideIcons } from '@ng-icons/core';
import { matAttachFileOutline, matSettingsOutline } from "@ng-icons/material-icons/outline";

@Component({
  selector: 'app-workspaces-item',
  imports: [
    CommonModule,
    NgIcon
  ],
  templateUrl: './workspaces-item.component.html',
  styleUrl: './workspaces-item.component.css',
  viewProviders: [provideIcons({ matAttachFileOutline, matSettingsOutline })]
})
export class WorkspacesItemComponent {
  chats = ['default'];
}
