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
        this.error = 'Fehler beim Laden der Tickets';
        this.loading = false;
      }
    });
  }
}
