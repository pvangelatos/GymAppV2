import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking, CreateBooking } from '../models/booking';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = 'http://localhost:5112/api/bookings';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Booking[]> {
    return this.http.get<Booking[]>(this.apiUrl);
  }

  getById(id: number): Observable<Booking> {
    return this.http.get<Booking>(`${this.apiUrl}/${id}`);
  }

  getByMemberId(memberId: number): Observable<Booking[]> {
    return this.http.get<Booking[]>(`${this.apiUrl}/member/${memberId}`);
  }

  create(booking: CreateBooking): Observable<Booking> {
    return this.http.post<Booking>(this.apiUrl, booking);
  }

  updateStatus(id: number, status: string): Observable<Booking> {
    return this.http.put<Booking>(`${this.apiUrl}/${id}/status`, { status });
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}