import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IMessage } from '../../core/models/message.model';
import { ChatBotStore } from '../../store/chatbot.store';
import { HistoryChatComponent } from './history-chat/history-chat.component';
import { FormChatComponent } from './form-chat/form-chat.component';

@Component({
  selector: 'app-chat',
  imports: [
    HistoryChatComponent,
    FormChatComponent,
    FormsModule
],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {
  messages: IMessage[] = [];
  currentMessage: string = '';
  selectedProvider: string = 'provider1';
  selectedModel: string = 'model1';

  constructor() {
    this.messages.push({ type: 'bot', text: 'Hi!, How can I help you today? ✨', date: new Date() });
  }

  sendMessage(messageContent: string) {
    if (messageContent.trim()) {
      this.messages.push({ type: 'user', text: messageContent.trim()+"112", date: new Date() });
      this.currentMessage = '';
    }
  }

  onProviderChange(provider: string) {
    this.selectedProvider = provider;
    console.log('selected provider:', this.selectedProvider);
  }

  onModelChange(model: string) {
    this.selectedModel = model;
    console.log('selected model:', this.selectedModel);
  }
}
