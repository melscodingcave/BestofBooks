# 🎱 BestofBooks — Pool & Billiards Book & DVD Inventory System

BestofBooks is a full-stack inventory management system built for a pool and billiards specialty shop, managing their catalog of instructional books and DVDs.

Originally built as part of the **Purdue Global Internship Program (2023–2024)**, the project has since been significantly modernized with a focus on security, maintainability, and a contemporary UI.

---

## 💡 Project Overview

BestofBooks supports two user types with role-based permissions:

**Store Owner / Admin**
- Full inventory management (add, edit, remove titles)
- User account management with granular permission control
- Change history audit log with date and user filtering
- Available inventory reports with genre and author filtering

**Customer / Staff**
- Browse full inventory with stock status at a glance
- Search by title, author, or genre
- View shelf location for any title

---

## ✨ Features

| Feature | Description |
|--------|-------------|
| Inventory management | Add, edit, and track books and DVDs |
| Role-based auth | Cookie-based authentication with claim-driven permissions |
| Admin panel | Live permission toggles per user, self-edit protection |
| Stock reporting | Color-coded badges for in stock, low stock, and out of stock |
| Search & filter | Partial, case-insensitive search across title, author, genre |
| Change history | Full audit log with username, date range, and action filters |
| Dark / light mode | Tournament blue accent with persistent theme preference |
| Print reports | Clean print view scoped to results only |

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|------------|
| Frontend | HTML5, CSS3 (CSS custom properties), JavaScript, Bootstrap 5.3 |
| Backend | C# / ASP.NET Core MVC (.NET 6) |
| Database | SQL Server with Dapper ORM |
| Auth | ASP.NET Core Cookie Authentication with claims |
| Security | PBKDF2 password hashing, CSRF protection, HttpOnly cookies |
| UI Libraries | DataTables, Google Fonts (Inter + Syne) |

---

## 🔐 Security Highlights

- Passwords hashed with **PBKDF2-SHA256** (100,000 iterations + random salt)
- Legacy SHA256 passwords silently upgraded on first login
- Global CSRF protection via `AutoValidateAntiforgeryToken`
- Auth cookie is `HttpOnly`, `Secure`, and `SameSite=Strict`
- Role-based authorization enforced at the controller level via named policies

---

## 🚀 Running the Project

### Prerequisites
- .NET 6 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 (or Rider)

### Setup

```bash
# Clone the repo
git clone https://github.com/melscodingcave/BestofBooks.git
cd BestofBooks
```

### Database Setup
1. Create a new SQL database named `BestofBooks`
2. Run the SQL scripts in the `/SQL Scripts` folder in order:
   - `BoB_DB_GenerationScript.sql` — creates all tables
   - `InsertSampleData.sql` — seeds initial data
   - Stored proc scripts — creates all required procedures
3. Update the connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "BestofBooks": "Server=.;Database=BestofBooks;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### Run
Open the solution in Visual Studio → Build → Run.  
The app will launch at `https://localhost:####/` in your browser.

---

## 📁 Project Structure

```
BestofBooks/
├── Controllers/         # HomeController (MVC), UserController (API)
├── Models/              # Domain models and ViewModels
├── Repo/                # Repository pattern with Dapper (IBookRepo, IUserRepo, IAuditRepo)
├── Views/               # Razor views with shared _Layout
├── wwwroot/
│   ├── css/site.css     # Full design system (CSS custom properties, dark/light mode)
│   └── js/              # site.js, login.js, inventoryList.js
├── SQL Scripts/         # DB generation, stored procs, seed data
├── SecurityUtilities.cs # PBKDF2 hashing + legacy SHA256 fallback
└── Startup.cs           # Auth, authorization policies, middleware pipeline
```

---

## 🧪 Planned Enhancements

- 🗄️ Entity Framework Core migration (replace Dapper + stored procs)
- 📦 ISBN barcode scanning for inventory updates
- 📊 Advanced analytics and sales tracking
- 🧾 PDF / Excel report export

---

## 🤝 Contributors

Originally developed by **Melanie Basso** and a fellow student engineer during the Purdue Global Internship Program (2023–2024).

Subsequently redesigned and modernized by Melanie Basso with a billiards-oriented theme, updated UI design system, security overhaul, and architectural improvements.