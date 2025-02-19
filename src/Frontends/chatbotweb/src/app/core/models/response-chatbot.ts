export interface IResponseChatBot {
    mimeType: string,
    modelId: string,
    metadata: {
        additionalProp1: string,
        additionalProp2: string,
        additionalProp3: string
    },
    text: string
}