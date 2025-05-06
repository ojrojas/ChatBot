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
  currentMessage: string = '';
  selectedProvider: string = 'provider1';
  selectedModel: string = 'model1';
  chatStore = inject(ChatBotStore);

  constructor() {
    this.chatStore.messages();
    this.chatStore.setMessage('Hi!, How can I help you today? ✨', 'assistant');
  }

  sendMessage(messageContent: string) {
    if (messageContent.trim()) {
      this.chatStore.setMessage(messageContent.trim(), 'user');
      this.chatStore.sendMessage(messageContent);
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
