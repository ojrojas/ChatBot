// import { patchState, signalState, signalStore, withMethods, withState } from '@ngrx/signals';
// import { setFulfilled, setPending, withRequestStatus } from "./request.status.store";
// import { CatalogsService } from "../services/catalogs.service";
// import { inject, isDevMode } from "@angular/core";
// import { LoggerService } from "../services/loggers.service";
// import { IPaginationResponse } from "../dtos/paginate.response.dto";
// import { IGetCatalogItemByIdResponse } from "../dtos/getcatalogitembyidresponse.dto";

import { patchState, signalState, signalStore, withMethods, withState } from "@ngrx/signals";
import { setFulfilled, setPending, withRequestStatus } from "./request.status";
import { IMessage } from "../core/models/messages.model";
import { ChatService } from "../services/chat.service";
import { inject } from "@angular/core";
import { withLogger } from "./logger.store";

// type CatalogsState = {
//   paginationResponse: IPaginationResponse | undefined;
//   catalogItemResponse: IGetCatalogItemByIdResponse | undefined;
//   query: string;
// }

type ChatBotState = {
    messages: IMessage[];
    query: string;
}


const chatbotState = signalState<ChatBotState>({
    messages: [],
    query: ''
});

export const ChatBotStore = signalStore(
    { providedIn: 'root' },
    withState(chatbotState),
    withLogger("ChatBot-Logger"),
    withRequestStatus(),
    withMethods((store, chatService = inject(ChatService)) => ({
        sendMessage(message: string) {
            patchState(store, {},setPending());
            const messages = store.messages();
            chatService.sendMessageToChatApi(message).subscribe({
                next: response => {
                    if (response.status === 200) {
                        const message = chatService.createMessage("Bot", response.body![0].text!)
                        messages.push(message);
                        patchState(store, { messages: messages }, setFulfilled());
                    }
                }, error: (errorr) => console.error(errorr),
                complete: () => console.debug("complete")
            })
        },
        setMessageUser(message:string)
        {
            const messages = store.messages();
            const messageUser = chatService.createMessage("User", message);
            messages.push(messageUser);
            patchState(store, { messages: messages });
        }
    }))
);