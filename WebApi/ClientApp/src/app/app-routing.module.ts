import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_services/auth.guard';
import { AnonymousGuard } from './_services/anonymousguard.guard'
import { RegisterComponent } from './login/register.component';
//import { WrongrouteComponent } from './_other/wrongroute/wrongroute.component';
import { ProfileComponent } from './user/profile/profile.component';

const routes: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full',canActivate:[AnonymousGuard]},
    { path: 'login', component: LoginComponent, canActivate: [AnonymousGuard]},
    { path: 'register', component: RegisterComponent},
    { path: 'home', component: HomeComponent,  canActivate: [AuthGuard]},
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
