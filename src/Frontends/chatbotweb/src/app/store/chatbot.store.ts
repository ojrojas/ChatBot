// import { patchState, signalState, signalStore, withMethods, withState } from '@ngrx/signals';
// import { setFulfilled, setPending, withRequestStatus } from "./request.status.store";
// import { CatalogsService } from "../services/catalogs.service";
// import { inject, isDevMode } from "@angular/core";
// import { LoggerService } from "../services/loggers.service";
// import { IPaginationResponse } from "../dtos/paginate.response.dto";
// import { IGetCatalogItemByIdResponse } from "../dtos/getcatalogitembyidresponse.dto";

import { patchState, signalState, signalStore, withHooks, withMethods, withState } from "@ngrx/signals";
import { setFulfilled, setPending, withRequestStatus } from "./request.status";
import { IMessage } from "../core/models/message.model";
import { ChatService } from "../services/chat.service";
import { inject } from "@angular/core";
import { withLogger } from "./logger.store";
import { StorageService } from "../services/storage.service";
import { IModel } from "../core/models/model-ia.model";

type ChatBotState = {
  messages: IMessage[];
  models: IModel[];
}


const chatbotState = signalState<ChatBotState>({
  messages: [],
  models: []
});

export const ChatBotStore = signalStore(
  { providedIn: 'root' },
  withState(chatbotState),
  withLogger("ChatBot-Logger"),
  withRequestStatus(),
  withMethods((store, chatService = inject(ChatService), storageService = inject(StorageService)) => ({
    sendMessage(message: string) {
      patchState(store, {}, setPending());
      const messages = store.messages();
      chatService.sendMessageToChatApi(JSON.stringify(messages)).subscribe({
        next: response => {
          if (response.status === 200) {
            let itemResponse = '';
            response.body?.forEach(item => {
              itemResponse += item.content;
            });
            const message = chatService.createMessage("assistant", itemResponse!);
            messages.push(message);
            patchState(store, { messages: messages }, setFulfilled());
            localStorage.setItem('chat-bot', JSON.stringify(chatbotState()));
          }
        }, error: (errorr) => console.error(errorr),
        complete: () => console.debug("complete")
      })
    },
    setMessage(message: string, type: string) {
      const messages = store.messages();
      const messageUser = chatService.createMessage(type, message);
      messages.push(messageUser);
      patchState(store, { messages: messages });
    },
    setStateStorage(state: ChatBotState) {
      patchState(store, state);
    },
    clearStorage() {
      storageService.clear();
      patchState(store, chatbotState);
    },
    getListModels() {
      patchState(store, {}, setPending());
      chatService.listModels().subscribe({
        next: response => {
          if (response.status === 200) {
            patchState(store, { models: response.body! }, setFulfilled());
            localStorage.setItem('chat-bot', JSON.stringify(chatbotState()));
          }
        }, error: (errorr) => console.error(errorr),
        complete: () => console.debug("complete")
      })

    }
  })),
  withHooks({
    onInit: (store) => {
      const storageService = inject(StorageService);
      const storageState = storageService.getItem('chat-bot');
      if (storageState !== null && storageState !== 'undefined') {
        const jsonObject = JSON.parse(storageState)
        store.setStateStorage(jsonObject as ChatBotState);
      }
    }
  }),
);
