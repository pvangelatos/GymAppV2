import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookingService } from '../../../core/services/booking.service';
import { Booking, CreateBooking } from '../../../core/models/booking';

declare var bootstrap: any;

@Component({
  selector: 'app-bookings-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './bookings-list.html',
  styleUrl: './bookings-list.scss',
})
export class BookingsListComponent implements OnInit {
  bookings: Booking[] = [];
  isLoading: boolean = true;
  errorMessage: string = '';
  modal: any;

  form: CreateBooking = {
    memberId: 0,
    timeSlotId: 0,
    bookingDate: ''
  };

  constructor(private bookingService: BookingService) {}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.isLoading = true;
    this.bookingService.getAll().subscribe({
      next: (data) => { this.bookings = data; this.isLoading = false; },
      error: () => { this.errorMessage = 'Failed to load bookings'; this.isLoading = false; }
    });
  }

  openAddModal(): void {
    this.form = { memberId: 0, timeSlotId: 0, bookingDate: '' };
    this.modal = new bootstrap.Modal(document.getElementById('bookingModal'));
    this.modal.show();
  }

  closeModal(): void {
    this.modal?.hide();
  }

  saveBooking(): void {
    this.bookingService.create(this.form).subscribe({
      next: () => { this.closeModal(); this.loadBookings(); },
      error: () => this.errorMessage = 'Failed to create booking'
    });
  }

  deleteBooking(id: number): void {
    if (confirm('Are you sure?')) {
      this.bookingService.delete(id).subscribe({
        next: () => this.loadBookings(),
        error: () => this.errorMessage = 'Failed to delete booking'
      });
    }
  }
}
