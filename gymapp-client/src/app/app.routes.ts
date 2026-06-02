import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth-guard';
import { LoginComponent } from './features/auth/login/login';
import { DashboardComponent } from './features/dashboard/dashboard';
import { MembersListComponent } from './features/members/members-list/members-list';
import { MemberDetailComponent } from './features/members/member-detail/member-detail';
import { SubscriptionsListComponent } from './features/subscriptions/subscriptions-list/subscriptions-list';
import { BookingsListComponent } from './features/bookings/bookings-list/bookings-list';
import { TrainersListComponent } from './features/trainers/trainers-list/trainers-list';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: '',
    canActivate: [authGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'members', component: MembersListComponent },
      { path: 'members/:id', component: MemberDetailComponent },
      { path: 'subscriptions', component: SubscriptionsListComponent },
      { path: 'bookings', component: BookingsListComponent },
      { path: 'trainers', component: TrainersListComponent },
    ]
  },
  { path: '**', redirectTo: 'dashboard' }
];
