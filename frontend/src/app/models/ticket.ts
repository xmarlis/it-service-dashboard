export interface Ticket {
  id: number;
  title: string;
  description: string;
  priority: string;
  status: string;
  clientId: number;
  createdAt: string;
  updatedAt?: string | null;
}
