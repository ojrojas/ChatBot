import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponseChatBot } from '../core/models/response-chatbot';
import { IMessage } from '../core/models/message.model';
import { IModel } from '../core/models/model-ia.model';
import { IModelCompletion } from '../core/models/model.completion';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http: HttpClient) { }

  sendMessageToChatApi = (modelCompletion: IModelCompletion, type: string) => {
    if (type === 'Chat')
      return this.http.post<IResponseChatBot[]>("/apichatbot/api/chat", modelCompletion, {
        observe: 'response'
      });
    else
      return this.http.post<IResponseChatBot[]>("/apichatbot/api/generate", modelCompletion, {
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
