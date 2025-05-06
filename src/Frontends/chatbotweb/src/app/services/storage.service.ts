import { Injectable } from '@angular/core';
import { IStorageService } from '../core/interfaces/storage.interface';

@Injectable({
  providedIn: 'root'
})
export class StorageService implements IStorageService {

  constructor() { }
  getItem(key: string): string | null {
   return localStorage.getItem(key);
  }
  setItem(key: string, object: any): void {
    localStorage.setItem(key, object);
  }
  removeItem(key: string): void {
    localStorage.removeItem(key);
  }

  clear():void {
    localStorage.clear();
  }
}
