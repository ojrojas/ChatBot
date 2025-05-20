import { IMessage } from "./message.model";

export interface IChat {
  name: string;
  messages: IMessage[];
}
