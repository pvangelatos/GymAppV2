import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainersListComponent } from './trainers-list';

describe('TrainersListComponent', () => {
  let component: TrainersListComponent;
  let fixture: ComponentFixture<TrainersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainersListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(TrainersListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
