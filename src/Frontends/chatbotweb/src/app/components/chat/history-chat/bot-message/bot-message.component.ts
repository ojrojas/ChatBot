import { Component, Input } from '@angular/core';
import { IMessage } from '../../../../core/models/message.model';

@Component({
  selector: 'app-bot-message',
  imports: [],
  templateUrl: './bot-message.component.html',
  styleUrl: './bot-message.component.css'
})
export class BotMessageComponent {
  @Input() message!: IMessage;
}
