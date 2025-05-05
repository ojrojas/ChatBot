import { IMessage } from "./message.model";

export interface IHistoryChat {
  date: Date;
  messages: IMessage[];
}
