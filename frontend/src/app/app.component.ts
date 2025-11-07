import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';   // <-- wichtig für *ngIf, *ngFor, date
import { TicketsService } from './services/tickets.service';
import { Ticket } from './models/ticket';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],                       // <-- hier CommonModule eintragen
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  tickets: Ticket[] = [];
  loading = true;
  error: string | null = null;

  constructor(private ticketsService: TicketsService) {}

  ngOnInit(): void {
    this.ticketsService.getTickets().subscribe({
      next: (data) => {
        this.tickets = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Error loading tickets';
        this.loading = false;
      }
    });
  }

  // Added method to satisfy the template (click)="openNewTicket()"
  openNewTicket(): void {
    // Minimal placeholder implementation:
    console.log('openNewTicket clicked');

    // Quick prompt to create a ticket for immediate UI feedback.
    const title = window.prompt('New ticket title:');
    if (!title) {
      return;
    }

    const newId = this.tickets && this.tickets.length
      ? Math.max(...this.tickets.map(t => (t as any).id || 0)) + 1
      : 1;

    const newTicket: Ticket = {
      // ...fill required fields; cast to Ticket to avoid strict type mismatches
      id: newId,
      title,
      clientId: 'Unknown',
      priority: 'Normal',
      status: 'Open',
      createdAt: new Date()
    } as unknown as Ticket;

    this.tickets = [newTicket, ...this.tickets];
  }
}
