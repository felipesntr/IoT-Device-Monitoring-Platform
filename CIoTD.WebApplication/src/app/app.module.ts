import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { RegisterComponent } from './pages/register/register.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { DeviceListComponent } from './components/device-list/device-list.component';
import { DeviceService } from './services/devices/device.service';
import { MatTableModule } from '@angular/material/table';
import { authInterceptor } from './interceptors/auth/auth.interceptor';
import { MatButton } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatButtonToggleGroup } from '@angular/material/button-toggle';
import { ConfigureCommandsComponent } from './pages/configure-commands/configure-commands.component';
import { MatPseudoCheckboxModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LayoutComponent,
    RegisterComponent,
    DeviceListComponent,
    DevicesComponent,
    ConfigureCommandsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule, FormsModule, MatToolbarModule,
    MatIconModule, MatTableModule, MatButtonToggleModule,
    MatButton, MatButtonToggleGroup, MatPseudoCheckboxModule, MatCheckboxModule
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors(
      [authInterceptor]
    )),
    DeviceService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
