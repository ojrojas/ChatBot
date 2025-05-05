import { Component } from '@angular/core';
import { ChatComponent } from "../chat/chat.component";
import { WorkspacesComponent } from "../workspaces/workspaces.component";

@Component({
  selector: 'app-layout',
  imports: [ChatComponent, WorkspacesComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
