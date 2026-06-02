import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TrainerService } from '../../../core/services/trainer.service';
import { Trainer, CreateTrainer } from '../../../core/models/trainer';

declare var bootstrap: any;

@Component({
  selector: 'app-trainers-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './trainers-list.html',
  styleUrl: './trainers-list.scss',
})
export class TrainersListComponent implements OnInit {
  trainers: Trainer[] = [];
  isLoading: boolean = true;
  errorMessage: string = '';
  isEditing: boolean = false;
  selectedId: number = 0;
  modal: any;

  form: CreateTrainer = {
    firstname: '',
    lastname: '',
    email: '',
    specialization: ''
  };

  constructor(private trainerService: TrainerService) {}

  ngOnInit(): void {
    this.loadTrainers();
  }

  loadTrainers(): void {
    this.isLoading = true;
    this.trainerService.getAll().subscribe({
      next: (data) => { this.trainers = data; this.isLoading = false; },
      error: () => { this.errorMessage = 'Failed to load trainers'; this.isLoading = false; }
    });
  }

  openAddModal(): void {
    this.isEditing = false;
    this.form = { firstname: '', lastname: '', email: '', specialization: '' };
    this.modal = new bootstrap.Modal(document.getElementById('trainerModal'));
    this.modal.show();
  }

  openEditModal(trainer: Trainer): void {
    this.isEditing = true;
    this.selectedId = trainer.id;
    this.form = {
      firstname: trainer.firstname,
      lastname: trainer.lastname,
      email: trainer.email,
      specialization: trainer.specialization
    };
    this.modal = new bootstrap.Modal(document.getElementById('trainerModal'));
    this.modal.show();
  }

  closeModal(): void {
    this.modal?.hide();
  }

  saveTrainer(): void {
    if (this.isEditing) {
      this.trainerService.update(this.selectedId, {
        firstname: this.form.firstname,
        lastname: this.form.lastname,
        specialization: this.form.specialization
      }).subscribe({
        next: () => { this.closeModal(); this.loadTrainers(); },
        error: () => this.errorMessage = 'Failed to update trainer'
      });
    } else {
      this.trainerService.create(this.form).subscribe({
        next: () => { this.closeModal(); this.loadTrainers(); },
        error: () => this.errorMessage = 'Failed to create trainer'
      });
    }
  }

  deleteTrainer(id: number): void {
    if (confirm('Are you sure?')) {
      this.trainerService.delete(id).subscribe({
        next: () => this.loadTrainers(),
        error: () => this.errorMessage = 'Failed to delete trainer'
      });
    }
  }
}
