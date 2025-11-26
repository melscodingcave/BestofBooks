# 📚 BestofBooks — Full-Stack Book Inventory Web App

BestofBooks is a full-stack book inventory system designed for bookstore management and customer lookup.  
It was built as part of the **Purdue Global Internship Program** to explore full-stack development using **C#, SQL, HTML, CSS, and JavaScript**.

---

## 💡 Project Overview

BestofBooks supports two types of users with different goals:

**Book Store Owner**
- Track and manage inventory
- View reports for:
  - Newly added books
  - Recently updated inventory
  - Out-of-stock books

**Customer**
- Check whether a book is in stock
- See where the book is located in the store (by shelf/section)

> 🛒 The goal: provide a fast and simple way to view availability and inventory without complex software.

---

## ✨ Features

| Feature | Description |
|--------|-------------|
| Inventory management | Add, update, remove books |
| Stock reporting | Out-of-stock, low quantity, and change history |
| Location lookup | Displays bookshelf/section for customers |
| Search + filter | Look up books by title, author, genre |
| Full web stack | C#/ASP.NET backend + SQL database + custom frontend |

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|------------|
| Frontend | HTML5, CSS3, JavaScript |
| Backend | C# (ASP.NET) |
| Database | SQL (Relational schema for inventory & history) |
| Other | CRUD operations, REST endpoints, data validation |

---

## 🚀 Running the Project

### **Prerequisites**
- .NET SDK (latest recommended)
- Local SQL Server or SQL Express
- IDE like Visual Studio or Rider

### **Setup**
```bash
# Clone the repo
git clone https://github.com/melscodingcave/BestofBooks.git
cd BestofBooks
```

### **Database Setup**

1. Create a new SQL database.
2. Run the SQL setup script (if provided in /database folder).
3. Update the connection string in the project config file.

## Run
- Open the solution in Visual Studio → Build → Run.
- The app will launch in your browser on a localhost URL (typically https://localhost:####/).

## 🧪 Sample Future Enhancements

- 🔐 Authentication (admin vs. customer accounts)
- 📊 Advanced analytics & sales data
- 📱 Responsive UI for mobile devices
- 📦 Support ISBN scanning for inventory updates
- 🧾 PDF/Excel report export

## 🤝 Contributors

Developed by Melanie Basso and another student engineer during the
Purdue Global Internship Program (2023–2024).
