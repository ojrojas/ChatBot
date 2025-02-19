import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponseChatBot } from '../core/models/response-chatbot';
import { IMessage } from '../core/models/messages.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http: HttpClient) { }

  sendMessageToChatApi = (message: string) => {
    return this.http.post<IResponseChatBot[]>("/apichatbot/api/chat", { message: message }, {
      observe: 'response'
    });
  }

  createMessage = (typeUser:string , toMessage: string) => {
    const message: IMessage = {
      user: typeUser === 'Bot' ? 'Bot': 'User',
      message: toMessage,
      date: Date.now()
    };

    return message;
  }
}
