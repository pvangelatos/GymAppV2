import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MemberService } from '../../../core/services/member.service';
import { Member, CreateMember } from '../../../core/models/member';

declare var bootstrap: any;

@Component({
  selector: 'app-members-list',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './members-list.html',
  styleUrl: './members-list.scss',
})
export class MembersListComponent implements OnInit {
  members: Member[] = [];
  isLoading: boolean = true;
  errorMessage: string = '';
  isEditing: boolean = false;
  selectedId: number = 0;
  modal: any;

  form: CreateMember = {
    firstname: '',
    lastname: '',
    email: '',
    phone: '',
    birthdate: ''
  };

  constructor(private memberService: MemberService) {}

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers(): void {
    this.isLoading = true;
    this.memberService.getAll().subscribe({
      next: (data) => { this.members = data; this.isLoading = false; },
      error: () => { this.errorMessage = 'Failed to load members'; this.isLoading = false; }
    });
  }

  openAddModal(): void {
    this.isEditing = false;
    this.form = { firstname: '', lastname: '', email: '', phone: '', birthdate: '' };
    this.modal = new bootstrap.Modal(document.getElementById('memberModal'));
    this.modal.show();
  }

  openEditModal(member: Member): void {
    this.isEditing = true;
    this.selectedId = member.id;
    this.form = {
      firstname: member.firstname,
      lastname: member.lastname,
      email: member.email,
      phone: member.phone,
      birthdate: member.birthdate
    };
    this.modal = new bootstrap.Modal(document.getElementById('memberModal'));
    this.modal.show();
  }

  closeModal(): void {
    this.modal?.hide();
  }

  saveMember(): void {
    if (this.isEditing) {
      this.memberService.update(this.selectedId, {
        firstname: this.form.firstname,
        lastname: this.form.lastname,
        phone: this.form.phone
      }).subscribe({
        next: () => { this.closeModal(); this.loadMembers(); },
        error: () => this.errorMessage = 'Failed to update member'
      });
    } else {
      this.memberService.create(this.form).subscribe({
        next: () => { this.closeModal(); this.loadMembers(); },
        error: () => this.errorMessage = 'Failed to create member'
      });
    }
  }

  deleteMember(id: number): void {
    if (confirm('Are you sure you want to delete this member?')) {
      this.memberService.delete(id).subscribe({
        next: () => this.loadMembers(),
        error: () => this.errorMessage = 'Failed to delete member'
      });
    }
  }
}
