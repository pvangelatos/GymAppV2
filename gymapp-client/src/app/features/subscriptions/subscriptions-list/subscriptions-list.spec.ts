import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscriptionsListComponent } from './subscriptions-list';

describe('SubscriptionsListComponent', () => {
  let component: SubscriptionsListComponent;
  let fixture: ComponentFixture<SubscriptionsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubscriptionsListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SubscriptionsListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
