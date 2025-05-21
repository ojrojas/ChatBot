import { Component, Input } from '@angular/core';
import { IMessage } from '../../../../core/models/message.model';
import { CommonModule } from '@angular/common';
import hljs from 'highlight.js';

@Component({
  selector: 'app-bot-message',
  imports: [
    CommonModule
  ],
  templateUrl: './bot-message.component.html',
  styleUrl: './bot-message.component.scss'
})
export class BotMessageComponent {
  @Input() message!: IMessage;
}
