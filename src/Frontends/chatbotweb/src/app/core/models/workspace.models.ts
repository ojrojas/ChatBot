import { IModel } from "./model-ia.model";

export interface IConfigureChat {
  workspaceId:string;
  modelChat: IModel;
  modelAgent: IModel;
  maxNumberChat: number | 20;
  type: 'chat | ask';
  prompt: string;
  temperature: number;
}

export interface IWorkSpace {
  id:string;
  name:string;
}
