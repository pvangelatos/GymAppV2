export interface Trainer {
  id: number;
  firstname: string;
  lastname: string;
  email: string;
  specialization: string;
  isActive: boolean;
}

export interface CreateTrainer {
  firstname: string;
  lastname: string;
  email: string;
  specialization: string;
}

export interface UpdateTrainer {
  firstname: string;
  lastname: string;
  specialization: string;
}
