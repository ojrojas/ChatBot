import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { provideServerRouting } from '@angular/ssr';
import { appConfig } from './app.config';
import { serverRoutes } from './app.routes.server';
import { LOCAL_STORAGE } from './shred/tokens';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    provideServerRouting(serverRoutes),
    {
      provide: LOCAL_STORAGE,
      useFactory: () => ({
        getItem: () => { },
        setItem: () => { },
        removeItem: () => { }
      })
    }
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
