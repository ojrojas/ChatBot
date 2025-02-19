import { DatePipe, getLocaleEraNames } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { IMessage } from '../../core/models/messages.model';
import { ChatBotStore } from '../../store/chatbot.store';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@Component({
  selector: 'app-chat',
  imports: [
    FormsModule,
    MatCardModule,
    MatDividerModule,
    MatInputModule,
    MatListModule,
    MatButtonModule,
    MatProgressBarModule,
    DatePipe],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {
  messages: IMessage[] = [];
  chatStore = inject(ChatBotStore);

  constructor() {
    this.messages = this.chatStore.messages();
  }

  // getNameRandom = () => {
  //   const result =Math.floor(Math.random() * 2);
  //   console.debug(result);
  //   if (result == 0)
  //     return "Bot"
  //   else return "User"
  // }

  sendMessageToBot = (message: HTMLTextAreaElement) => {
    this.chatStore.setMessageUser(message.value);
    this.chatStore.sendMessage(message.value);
    message.value = ''
  }

  getDate = () => {
    return Date.now();
  }
}
