import { Component } from '@angular/core';
import { ChatComponent } from "../chat/chat.component";
import { WorkspacesComponent } from "../workspaces/workspaces.component";
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';


@Component({
  selector: 'app-layout',
  imports: [
    ChatComponent,
    WorkspacesComponent,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatToolbarModule
  ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  showFiller = false;
}
