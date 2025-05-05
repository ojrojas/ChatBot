import { Routes } from '@angular/router';
import { ChatComponent } from './components/chat/chat.component';
import { LayoutComponent } from './components/layout/layout.component';

export const routes: Routes = [
    {
        path:'layout',
        component: LayoutComponent
    },
    {
        path:'',
        redirectTo: 'layout',
        pathMatch: "full"
      },
      {
        path: '**',
        redirectTo: 'layout',
      }
];
