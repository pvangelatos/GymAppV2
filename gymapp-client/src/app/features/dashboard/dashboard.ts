import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MemberService } from '../../core/services/member.service';
import { SubscriptionService } from '../../core/services/subscription.service';
import { BookingService } from '../../core/services/booking.service';
import { TrainerService } from '../../core/services/trainer.service';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule, RouterModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class DashboardComponent implements OnInit {
  totalMembers: number = 0;
  totalTrainers: number = 0;
  totalSubscriptions: number = 0;
  totalBookings: number = 0;
  firstname: string = '';

  constructor(
    private memberService: MemberService,
    private subscriptionService: SubscriptionService,
    private bookingService: BookingService,
    private trainerService: TrainerService
  ) {}

  ngOnInit(): void {
    this.memberService.getAll().subscribe(d => this.totalMembers = d.length);
    this.trainerService.getAll().subscribe(d => this.totalTrainers = d.length);
    this.subscriptionService.getAll().subscribe(d => this.totalSubscriptions = d.length);
    this.bookingService.getAll().subscribe(d => this.totalBookings = d.length);
    this.firstname = localStorage.getItem('firstname') || '';
  }
}
