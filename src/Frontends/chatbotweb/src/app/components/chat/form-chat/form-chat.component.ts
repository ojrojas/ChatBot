import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIcon, provideIcons } from '@ng-icons/core';
import { matAttachFileOutline, matDownloadOutline, matMicOutline } from "@ng-icons/material-icons/outline";

@Component({
  selector: 'app-form-chat',
  imports: [
    CommonModule,
    NgIcon,
    FormsModule
  ],
  templateUrl: './form-chat.component.html',
  styleUrl: './form-chat.component.css',
  viewProviders: [provideIcons({ matAttachFileOutline, matDownloadOutline, matMicOutline })]
})
export class FormChatComponent {
  @Input() selectedProvider: string = 'provider1';
  @Input() selectedModel: string = 'model1';
  @Output() sendMessageEvent = new EventEmitter<string>();
  @Output() providerChangeEvent = new EventEmitter<string>();
  @Output() modelChangeEvent = new EventEmitter<string>();
  messageInput: string = '';

  providers: string[] = ['provider1', 'provider2', 'provider3'];
  models: string[] = ['model1', 'model2', 'model3'];

  constructor() { }

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
