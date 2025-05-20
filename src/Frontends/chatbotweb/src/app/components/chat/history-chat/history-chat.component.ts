import { Component, ElementRef, inject, Input, SimpleChanges, ViewChild } from '@angular/core';
import { UserMessageComponent } from './user-message/user-message.component';
import { BotMessageComponent } from './bot-message/bot-message.component';
import { IMessage } from '../../../core/models/message.model';
import { CommonModule } from '@angular/common';
import { ChatBotStore } from '../../../store/chatbot.store';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-history-chat',
  imports: [
    UserMessageComponent,
    BotMessageComponent,
    CommonModule,
    MatCardModule
  ],
  templateUrl: './history-chat.component.html',
  styleUrl: './history-chat.component.scss'
})
export class HistoryChatComponent {
  @Input() messages: IMessage[] = [];
  @ViewChild('messageList') messageList!: ElementRef;
  chatStore = inject(ChatBotStore);

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['messages'] && !changes['messages'].firstChange) {
      setTimeout(() => {
        this.scrollToBottom();
      }, 0);
    }
  }

  scrollToBottom(): void {
    try {
      this.messageList.nativeElement.scrollTop = this.messageList.nativeElement.scrollHeight;
    } catch(err) { }
  }
}
