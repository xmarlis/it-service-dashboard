# 🖥️ IT Service Dashboard

A full-stack web application built with **Angular** (frontend) and **.NET 9 Web API** (backend) to manage clients, servers, and service tickets.  
This project was developed as a practice app to prepare for software engineering roles using C#, .NET, and TypeScript.

---

## 🚀 Features

- CRUD REST API with .NET 9 + Entity Framework Core + SQLite  
- Angular standalone frontend using HttpClient and TypeScript  
- Live connection between backend and frontend via CORS  
- Swagger UI for testing endpoints  
- Displays list of service tickets in a simple dashboard view  

---

## 🏗️ Project Structure

it-service-dashboard/
│
├── backend/ # ASP.NET Core Web API
│ ├── Controllers/
│ ├── Models/
│ ├── Data/
│ ├── Program.cs
│ └── appsettings.json
│
└── frontend/ # Angular standalone app
├── src/
├── angular.json
└── package.json

yaml
Code kopieren

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the repo

```bash
git clone https://github.com/xmarlis/it-service-dashboard.git
cd it-service-dashboard
2️⃣ Run the backend
bash
Code kopieren
cd backend
dotnet run
Backend runs on:
➡️ http://localhost:5023

Swagger UI:
➡️ http://localhost:5023/swagger

3️⃣ Run the frontend
Open a new terminal:

bash
Code kopieren
cd frontend
ng serve
Frontend runs on:
➡️ http://localhost:4200

🧩 Example API Usage
Create a Client

json
Code kopieren
POST /api/Clients
{
  "name": "Testkunde A",
  "industry": "IT",
  "contactPerson": "Max Mustermann",
  "email": "testkunde@example.com"
}
Create a Ticket

json
Code kopieren
POST /api/Tickets
{
  "title": "Login issue",
  "description": "User cannot log in.",
  "priority": "High",
  "status": "Open",
  "clientId": 1
}
💡 Tech Stack
Backend:

C#, .NET 9, Entity Framework Core, SQLite, Swagger

Frontend:

Angular 18 (standalone)

TypeScript, RxJS, HTML, CSS