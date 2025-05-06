export interface IStorageService {
  getItem(key: string): string | null;
  setItem(key: string, object: any): void;
  removeItem(key: string): void;
  clear(): void;
}
