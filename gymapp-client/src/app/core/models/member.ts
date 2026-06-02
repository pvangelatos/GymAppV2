export interface Member {
  id: number;
  firstname: string;
  lastname: string;
  email: string;
  phone: string;
  birthdate: string;
  isActive: boolean;
}

export interface CreateMember {
  firstname: string;
  lastname: string;
  email: string;
  phone: string;
  birthdate: string;
}

export interface UpdateMember {
  firstname: string;
  lastname: string;
  phone: string;
}
