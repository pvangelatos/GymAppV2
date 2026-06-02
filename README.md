# GymApp V2 💪

Σύστημα διαχείρισης γυμναστηρίου — Full Stack εφαρμογή ανεπτυγμένη ως portfolio project στο πλαίσιο της εκπαίδευσης στο **Coding Factory 9 (AUEB)**.

---

## Περιγραφή

Το GymApp V2 είναι μια ολοκληρωμένη web εφαρμογή για τη διαχείριση γυμναστηρίου. Επιτρέπει την παρακολούθηση μελών, εκπαιδευτών, συνδρομών, κρατήσεων και χρονοθυρίδων. Αναπτύχθηκε με **Clean Architecture** στο backend και **Angular 17** στο frontend.

---

## Τεχνολογίες

### Backend
- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- ASP.NET Core Identity + JWT Authentication
- AutoMapper
- SQL Server
- Scalar (API Documentation)

### Frontend
- Angular 17
- TypeScript
- Bootstrap 5
- JWT Interceptor / AuthGuard

### Αρχιτεκτονική
- Clean Architecture (Core / Application / Infrastructure / API)
- Repository Pattern
- Service Layer
- DTOs

---

## Λειτουργίες

- ✅ Εγγραφή & σύνδεση χρηστών (JWT Authentication)
- ✅ Διαχείριση μελών (CRUD)
- ✅ Διαχείριση εκπαιδευτών (CRUD)
- ✅ Διαχείριση συνδρομών & αυτόματη απενεργοποίηση (Background Service)
- ✅ Κρατήσεις χρονοθυρίδων με περιορισμό χωρητικότητας (Pilates Reformer: max 5 άτομα)
- ✅ Πολύγλωσση επικύρωση (Ελληνικά / Αγγλικά)
- ✅ Τεκμηρίωση API μέσω Scalar

---

## Προαπαιτούμενα

Για να τρέξεις την εφαρμογή τοπικά χρειάζεσαι:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (v18+) & npm
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ή SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ή VS Code

---

## Εγκατάσταση & Εκκίνηση

### 1. Κλωνοποίηση του repository

```bash
git clone https://github.com/pvangelatos/GymAppV2.git
cd GymAppV2
```

### 2. Ρύθμιση Backend

#### 2α. Σύνδεση με βάση δεδομένων

Άνοιξε το αρχείο `GymAppV2.API/appsettings.json` και ενημέρωσε το connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=GymAppV2;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

#### 2β. Εφαρμογή Migrations

```bash
cd GymAppV2.API
dotnet ef database update
```

#### 2γ. Εκκίνηση Backend

```bash
dotnet run
```

Το API θα τρέχει στο URL που εμφανίζεται στο terminal μετά το `dotnet run` (π.χ. `http://localhost:5112`)  
Η τεκμηρίωση Scalar στο: `http://localhost:{port}/scalar`

---

### 3. Ρύθμιση Frontend

```bash
cd gymapp-client
npm install
ng serve
```

Το frontend θα τρέχει στο: `http://localhost:4200`

---

### 4. Πρώτη Εκκίνηση — Δημιουργία Χρήστη

Μετά την εκκίνηση του backend, δημιούργησε τον πρώτο χρήστη μέσω του Scalar (`http://localhost:{port}/scalar`) ή του Postman:

```
POST http://localhost:{port}/api/auth/register
```

```json
{
  "firstname": "Admin",
  "lastname": "User",
  "email": "youremail@example.com",
  "password": "YourPassword@123",
  "phone": "6900000000",
  "birthdate": "1990-01-01"
}
```

> **Σημείωση για τον κωδικό:** Απαιτείται τουλάχιστον 8 χαρακτήρες, ένα κεφαλαίο γράμμα και ένας αριθμός.

Στη συνέχεια κάνε login από το frontend στο `http://localhost:4200`.

---

## Δομή Project

```
GymAppV2/
├── GymAppV2.Core/            # Entities, Interfaces
├── GymAppV2.Application/     # Services, DTOs, AutoMapper
├── GymAppV2.Infrastructure/  # EF Core, Repositories, Background Service
├── GymAppV2.API/             # Controllers, Auth, Scalar
├── gymapp-client/            # Angular 17 app
└── README.md
```

---

## API Documentation

Μετά την εκκίνηση του backend, η πλήρης τεκμηρίωση των endpoints είναι διαθέσιμη μέσω **Scalar** στο:

```
http://localhost:{port}/scalar
```

---

Αναπτύχθηκε από τον **Παναγιώτη Βαγγελάτο** ως portfolio project στο πλαίσιο της εκπαίδευσής του στο **Coding Factory 9 — AUEB** (Οκτ. 2025 – Ιούλ. 2026).
