export interface Subscription {
  id: number;
  memberId: number;
  subscriptionPlanId: number;
  planName: string;
  startDate: string;
  endDate: string;
  isActive: boolean;
  sessionsRemaining: number | null;
}

export interface CreateSubscription {
  memberId: number;
  subscriptionPlanId: number;
  startDate: string;
}
