# 📚 Student Management System

A **C# Console Application** for managing student records, built as a project to demonstrate core programming concepts. The application uses **.NET Framework 4.7.2**, **SQL Server** for data persistence, **ADO.NET** for database communication, and **Generic Collections** for in-memory data handling — all connected through a normalized database with a single stored procedure handling CRUD operations.

---

## ✨ Features

### ➕ Add Student

Capture and save details such as:

* Student Name
* Gender
* Age
* Phone Number
* Email
* Class
* Section
* Roll Number
* Course
* City
* State
* Country

### ✏️ Update Student

Modify details of any existing student record by specifying the Student ID.

### 📋 Display All Students

List all student records with complete details retrieved using SQL joins across normalized tables.

### 🔍 Search Student by ID

Quickly retrieve individual student information using a unique Student ID.

### ❌ Delete Student

Remove a student record from the system with a preview and confirmation step before deletion.

---

## 🛠️ Technical Stack

### 💻 Language & Framework

* **Language:** C# (.NET Framework 4.7.2)
* **Project Type:** Console Application
* **IDE:** Visual Studio 2022

### 🗄️ Database

* **RDBMS:** SQL Server (SQL Server Express)
* **Database Design:** Normalized relational schema
* **Stored Procedure:** `sp_Student_Management_System_DB`
* **SQL Operations:** CRUD Operations with INNER JOIN queries

---

## 🔌 Data Access — ADO.NET

| Class         | Usage                                  |
| ------------- | -------------------------------------- |
| SqlConnection | Establishes connection with SQL Server |
| SqlCommand    | Executes stored procedures             |
| SqlParameter  | Safely passes user input to SQL        |
| SqlDataReader | Reads database records row-by-row      |

---

## 📦 Collections — C# Generics

The application uses:

```csharp
List<T>
```

to store records retrieved from SQL Server before displaying them to the user.

### Model Classes

| Class         | Purpose                      |
| ------------- | ---------------------------- |
| AddStudent    | Add student data             |
| ReadStudent   | Display/Search student data  |
| DeleteStudent | Preview data before deletion |

---

## 🧠 OOP Concepts Applied

### Classes & Objects

Three dedicated model classes are used:

* AddStudent
* ReadStudent
* DeleteStudent

### Encapsulation

Student information is collected from the console, stored inside model objects, and passed throughout the application.

### Constructors

Constructors initialize model objects with student information.

### Resource Management

```csharp
using(...)
```

blocks ensure proper disposal of:

* SqlConnection
* SqlCommand
* SqlDataReader

---

## 🗂️ Database Design

### Lookup Tables

```text
Gender
Course
Address_City
Address_State
Address_Country
```

### Main Table

```text
Student
```

### Relationships

```text
Gender
   │
Course
   │
City
   │
State
   │
Country
   │
   ▼
Student
```

The Student table references lookup tables through Foreign Keys, reducing redundancy and maintaining data consistency.

---

## ⚙️ Stored Procedure Architecture

### Procedure Name

```sql
sp_Student_Management_System_DB
```

### Operations

| UserChoice | Operation            |
| ---------- | -------------------- |
| 1          | Add Student          |
| 2          | Update Student       |
| 3          | Display All Students |
| 4          | Search Student By ID |
| 5          | Delete Student       |

---

## 🖥️ Application Flow

### Main Menu

```text
===================================
      STUDENT MANAGEMENT SYSTEM
===================================

1. Add Student
2. Update Student
3. Display All Students
4. Search Student By ID
5. Delete Student
6. Exit
```

---

## 🗄️ Database Setup Instructions

### 1. Create Database

```sql
CREATE DATABASE Student_Management_System_DB;
GO

USE Student_Management_System_DB;
GO
```

### 2. Create Required Tables

Create:

* Gender
* Course
* Address_City
* Address_State
* Address_Country
* Student

### 3. Create Stored Procedure

Execute:

```sql
sp_Student_Management_System_DB
```

### 4. Update Connection String

```csharp
using (SqlConnection connect =
new SqlConnection(
"DATA SOURCE = YOUR_SERVER_NAME;
INITIAL CATALOG = Student_Management_System_DB;
INTEGRATED SECURITY = SSPI"))
```

---

## 🚀 How To Build and Run

### Build

```text
Ctrl + Shift + B
```

### Run

```text
F5
```

### Steps

1. Open solution in Visual Studio.
2. Build the project.
3. Run the application.
4. Use menu options to perform CRUD operations.

---

## 🎯 Learning Outcomes

This project demonstrates:

✅ C# Programming

✅ ADO.NET

✅ SQL Server Integration

✅ Stored Procedures

✅ SQL Joins

✅ CRUD Operations

✅ Generic Collections

✅ Object-Oriented Programming

✅ Resource Management

✅ Console Application Development

---

## 👨‍💻 Author

**Ayush Singh**

💻 Software Developer

📚 C# | .NET | SQL Server

🚀 Learning Enterprise Application Development Through Real-World Projects

---

## 📜 License

This project is intended for educational and learning purposes.
