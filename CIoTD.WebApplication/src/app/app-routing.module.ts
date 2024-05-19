import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { RegisterComponent } from './pages/register/register.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { ConfigureCommandsComponent } from './pages/configure-commands/configure-commands.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  {
    path: '', component: LayoutComponent, children: [
      { path: 'devices', component: DevicesComponent },
      { path: '', component: DevicesComponent },
      { path: 'configure-commands', component: ConfigureCommandsComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
