import { inject, Injectable } from '@angular/core';
import { IStorageService } from '../core/interfaces/storage.interface';
import { LOCAL_STORAGE } from '../shred/tokens';

@Injectable({
  providedIn: 'root'
})
export class StorageService implements IStorageService {
 private storage = inject(LOCAL_STORAGE);
  constructor() { }
  getItem(key: string): string | null {
   return this.storage.getItem(key);
  }
  setItem(key: string, object: any): void {
    this.storage.setItem(key, object);
  }
  removeItem(key: string): void {
    this.storage.removeItem(key);
  }

  clear():void {
    this.storage.clear();
  }
}
