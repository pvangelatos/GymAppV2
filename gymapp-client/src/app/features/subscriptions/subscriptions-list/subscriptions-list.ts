import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SubscriptionService } from '../../../core/services/subscription.service';
import { Subscription, CreateSubscription } from '../../../core/models/subscription';

declare var bootstrap: any;

@Component({
  selector: 'app-subscriptions-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './subscriptions-list.html',
  styleUrl: './subscriptions-list.scss',
})
export class SubscriptionsListComponent implements OnInit {
  subscriptions: Subscription[] = [];
  isLoading: boolean = true;
  errorMessage: string = '';
  modal: any;

  form: CreateSubscription = {
    memberId: 0,
    subscriptionPlanId: 0,
    startDate: ''
  };

  constructor(private subscriptionService: SubscriptionService) {}

  ngOnInit(): void {
    this.loadSubscriptions();
  }

  loadSubscriptions(): void {
    this.isLoading = true;
    this.subscriptionService.getAll().subscribe({
      next: (data) => { this.subscriptions = data; this.isLoading = false; },
      error: () => { this.errorMessage = 'Failed to load subscriptions'; this.isLoading = false; }
    });
  }

  openAddModal(): void {
    this.form = { memberId: 0, subscriptionPlanId: 0, startDate: '' };
    this.modal = new bootstrap.Modal(document.getElementById('subscriptionModal'));
    this.modal.show();
  }

  closeModal(): void {
    this.modal?.hide();
  }

  saveSubscription(): void {
    this.subscriptionService.create(this.form).subscribe({
      next: () => { this.closeModal(); this.loadSubscriptions(); },
      error: () => this.errorMessage = 'Failed to create subscription'
    });
  }

  deleteSubscription(id: number): void {
    if (confirm('Are you sure?')) {
      this.subscriptionService.delete(id).subscribe({
        next: () => this.loadSubscriptions(),
        error: () => this.errorMessage = 'Failed to delete subscription'
      });
    }
  }
}
