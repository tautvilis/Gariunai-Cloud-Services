import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_services/auth.guard';
import { AnonymousGuard } from './_services/anonymousguard.guard'
import { RegisterComponent } from './login/register.component';

const routes: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full',canActivate:[AnonymousGuard]},
    { path: 'login', component: LoginComponent, canActivate: [AnonymousGuard]},
    { path: 'register', component: RegisterComponent},
    { path: 'home', component: HomeComponent,  canActivate: [AuthGuard]},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
