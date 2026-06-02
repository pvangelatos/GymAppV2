export interface Booking {
  id: number;
  memberId: number;
  timeSlotId: number;
  bookingDate: string;
  status: string;
}

export interface CreateBooking {
  memberId: number;
  timeSlotId: number;
  bookingDate: string;
}
