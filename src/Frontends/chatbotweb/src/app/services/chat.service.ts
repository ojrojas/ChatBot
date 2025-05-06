import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponseChatBot } from '../core/models/response-chatbot';
import { IMessage } from '../core/models/message.model';
import { IModel } from '../core/models/model-ia.model';

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

  listModels = () => {
    return this.http.get<IModel[]>("/apichatbot/api/models", { observe: 'response' });
  }

  createMessage = (typeUser: string, toMessage: string) => {
    const message: IMessage = {
      role: typeUser === 'assistant' ? 'assistant' : 'user',
      content: toMessage,
    };

    return message;
  }
}
