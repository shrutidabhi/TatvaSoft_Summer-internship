import { provideRouter } from '@angular/router';
import { LoginComponent } from './components/login.component';

export const appConfig = {
  providers: [
    provideRouter([
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent }
    ])
  ]
};
