import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChatBotStore } from '../../../store/chatbot.store';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-form-chat',
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule,
    MatButtonModule
  ],
  templateUrl: './form-chat.component.html',
  styleUrl: './form-chat.component.scss',
})
export class FormChatComponent {
  readonly chatStore = inject(ChatBotStore);
  @Input() selectedProvider: string = '';
  @Input() selectedModel: string = '';
  @Output() sendMessageEvent = new EventEmitter<string>();
  @Output() providerChangeEvent = new EventEmitter<string>();
  @Output() modelChangeEvent = new EventEmitter<string>();
  messageInput: string = '';

  providers: string[] = ['Chat', 'Generate'];
  models: string[] = [];

  constructor() {
    this.chatStore.getListModels();
  }

  onSendMessage() {
    this.sendMessageEvent.emit(this.messageInput);
    this.messageInput = '';
  }

  onProviderSelectChange(event: Event) {
    const target = event.target as HTMLSelectElement;
    this.providerChangeEvent.emit(target.value);
  }

  onModelSelectChange(event: Event) {
    const target = event.target as HTMLSelectElement;
    this.modelChangeEvent.emit(target.value);
  }

  onKeyPress(event: KeyboardEvent) {
    if (event.key === 'Enter' && !event.shiftKey) {
      event.preventDefault();
      this.onSendMessage();
    }
  }
}
