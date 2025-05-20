import { Component, Input } from '@angular/core';
import { IMessage } from '../../../../core/models/message.model';

@Component({
  selector: 'app-user-message',
  imports: [],
  templateUrl: './user-message.component.html',
  styleUrl: './user-message.component.scss'
})
export class UserMessageComponent {
  @Input() message!: IMessage;
}
