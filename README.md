# 📚 Student Management System

A **C# Console Application** for managing student records, built as a project to demonstrate core programming concepts. The application uses **.NET Framework 4.7.2**, **SQL Server** for data persistence, **ADO.NET** for database communication, and **Generic Collections** for in-memory data handling — all connected through a normalized database with a single stored procedure handling CRUD operations.

---

# ✨ Features

## ➕ Add Student

Capture and save details such as:

- Student Name
- Gender
- Age
- Phone Number
- Email
- Class
- Section
- Roll Number
- Course
- City
- State
- Country

---

## ✏️ Update Student

Modify details of any existing student record using the Student ID.

---

## 📋 Display All Students

Display complete student records along with:

- Personal Information
- Academic Information
- Course Information
- Address Information

using SQL JOIN operations.

---

## 🔍 Search Student By ID

Quickly retrieve student details using:

```text
Student ID
```

---

## ❌ Delete Student

Remove a student record safely through:

```text
Record Preview
Confirmation Prompt
Permanent Deletion
```

---

# 🛠️ Technical Stack

## 💻 Language & Framework

| Technology | Description |
|------------|-------------|
| C# | Programming Language |
| .NET Framework 4.7.2 | Application Runtime |
| Console Application | User Interface |
| Visual Studio 2022 | Development Environment |

---

## 🗄️ Database

| Component | Purpose |
|------------|----------|
| SQL Server | Data Storage |
| Stored Procedures | CRUD Operations |
| Foreign Keys | Data Integrity |
| SQL Joins | Data Retrieval |

### Database Design

The project follows a **Normalized Database Design** where the main Student table references multiple lookup tables:

```text
Gender
Course
Address_City
Address_State
Address_Country
```

through Foreign Key relationships.

This approach:

✅ Eliminates Data Redundancy

✅ Improves Data Integrity

✅ Simplifies Data Maintenance

---

# 🔌 Data Access — ADO.NET

| Class | Usage |
|---------|---------|
| SqlConnection | Establishes connection with SQL Server |
| SqlCommand | Executes Stored Procedures |
| SqlParameter | Passes parameters safely |
| SqlDataReader | Reads records row-by-row |

---

# 📦 Collections — C# Generics

The application uses:

```csharp
List<T>
```

to collect records returned by SqlDataReader before displaying them.

### Model Classes

| Class | Purpose |
|---------|---------|
| AddStudent | Add operation data |
| ReadStudent | Display/Search records |
| DeleteStudent | Delete preview data |

---

# 🧠 OOP Concepts Applied

## Classes & Objects

Dedicated model classes are used:

```text
AddStudent
ReadStudent
DeleteStudent
```

---

## Encapsulation

Student information is wrapped inside model objects and passed throughout the application.

---

## Constructors

Constructors initialize objects with student information.

---

## Resource Management

```csharp
using(...)
```

used for:

- SqlConnection
- SqlCommand
- SqlDataReader

to ensure proper disposal of resources.

---

# 🗂️ Project Structure

```text
Student_Management_System
│
├── Program.cs
│
├── Models
│   ├── AddStudent.cs
│   ├── ReadStudent.cs
│   └── DeleteStudent.cs
│
├── SQL Scripts
│   ├── Student_Management_System_DB_Main_Table.sql
│   ├── Student_Management_System_DB_Normalise_Table.sql
│   ├── Student_Management_System_DB_STORED_PROCEDURE_ADD_STUDENT.sql
│   ├── Student_Management_System_DB_All other Operations Miscellaneous.sql
│   └── use Student_Management_System_DB_SELECT_JOINS.sql
│
└── Student_Management_System.sln
```

---

# 🗄️ Database Schema

## Lookup Tables

### Gender

```sql
CREATE TABLE Gender (
    Gender_Id INT PRIMARY KEY,
    Gender VARCHAR(10) UNIQUE
);
```

### Course

```sql
CREATE TABLE Course (
    Course_Id INT PRIMARY KEY,
    Course_Name VARCHAR(50) UNIQUE
);
```

### Address_City

```sql
CREATE TABLE Address_City (
    City_Id INT PRIMARY KEY,
    City VARCHAR(50) UNIQUE
);
```

### Address_State

```sql
CREATE TABLE Address_State (
    State_Id INT PRIMARY KEY,
    State VARCHAR(50) UNIQUE
);
```

### Address_Country

```sql
CREATE TABLE Address_Country (
    Country_Id INT PRIMARY KEY,
    Country VARCHAR(50) UNIQUE
);
```

---

## Main Student Table

```sql
CREATE TABLE Student (
    Student_ID INT IDENTITY(1,1) PRIMARY KEY,
    Student_Name VARCHAR(50) NOT NULL,
    Gender_ID INT FOREIGN KEY REFERENCES Gender(Gender_Id),
    Age INT NOT NULL,
    Phone_Number VARCHAR(15),
    Email VARCHAR(100),
    Student_Class INT NOT NULL,
    Section VARCHAR(10),
    Roll_No INT NOT NULL UNIQUE,
    Course_ID INT FOREIGN KEY REFERENCES Course(Course_Id),
    City_ID INT FOREIGN KEY REFERENCES Address_City(City_Id),
    State_ID INT FOREIGN KEY REFERENCES Address_State(State_Id),
    Country_ID INT FOREIGN KEY REFERENCES Address_Country(Country_Id)
);
```

---

# 🗃️ Sample SQL Queries

## Display All Students

```sql
SELECT
    s.Student_ID,
    s.Student_Name,
    g.Gender,
    s.Age,
    s.Phone_Number,
    s.Email,
    s.Student_Class,
    s.Section,
    s.Roll_No,
    c.Course_Name,
    cty.City,
    st.State,
    cy.Country
FROM Student s
INNER JOIN Gender g ON s.Gender_ID = g.Gender_Id
INNER JOIN Course c ON s.Course_ID = c.Course_Id
INNER JOIN Address_City cty ON s.City_ID = cty.City_Id
INNER JOIN Address_State st ON s.State_ID = st.State_Id
INNER JOIN Address_Country cy ON s.Country_ID = cy.Country_Id;
```

---

## Search Student By ID

```sql
SELECT
    s.Student_ID,
    s.Student_Name,
    g.Gender,
    s.Age,
    s.Phone_Number,
    s.Email,
    s.Student_Class,
    s.Section,
    s.Roll_No,
    c.Course_Name,
    cty.City,
    st.State,
    cy.Country
FROM Student s
INNER JOIN Gender g ON s.Gender_ID = g.Gender_Id
INNER JOIN Course c ON s.Course_ID = c.Course_Id
INNER JOIN Address_City cty ON s.City_ID = cty.City_Id
INNER JOIN Address_State st ON s.State_ID = st.State_Id
INNER JOIN Address_Country cy ON s.Country_ID = cy.Country_Id
WHERE s.Student_ID = @Student_ID;
```

---

## Execute Stored Procedure

### Add Student

```sql
EXEC sp_Student_Management_System_DB
     @UserChoice = 1,
     @Student_Name = 'Rahul Kumar',
     @Gender = 'Male',
     @Age = 22,
     @Phone_Number = '9876543210',
     @Email = 'rahul@gmail.com',
     @Student_Class = 12,
     @Section = 'A',
     @Roll_No = 101,
     @Course_Name = '.NET',
     @City = 'Bengaluru',
     @State = 'Karnataka',
     @Country = 'India';
```

### Search Student

```sql
EXEC sp_Student_Management_System_DB
     @UserChoice = 4,
     @Student_ID = 1;
```

---

## View Student Records

```sql
SELECT * FROM Student;
```

---

## View Lookup Tables

```sql
SELECT * FROM Gender;
SELECT * FROM Course;
SELECT * FROM Address_City;
SELECT * FROM Address_State;
SELECT * FROM Address_Country;
```

---

# ⚙️ Stored Procedure Architecture

### Stored Procedure

```sql
sp_Student_Management_System_DB
```

### Operations

| UserChoice | Operation |
|------------|-----------|
| 1 | Add Student |
| 2 | Update Student |
| 3 | Display All Students |
| 4 | Search Student By ID |
| 5 | Delete Student |

---

# 🖥️ Application Flow

## Main Menu

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

# 🚀 How To Build & Run

## Clone Repository

```bash
git clone https://github.com/HeeyDeveloper/Student_Management_System.git
```

---

## Configure SQL Server

Update connection string:

```csharp
using (SqlConnection connect =
new SqlConnection(
"DATA SOURCE = YOUR_SERVER_NAME;
INITIAL CATALOG = Student_Management_System_DB;
INTEGRATED SECURITY = SSPI"))
```

---

## Execute SQL Scripts

Run:

```text
1. Student_Management_System_DB_Normalise_Table.sql
2. Student_Management_System_DB_Main_Table.sql
3. Student_Management_System_DB_STORED_PROCEDURE_ADD_STUDENT.sql
4. Student_Management_System_DB_All other Operations Miscellaneous.sql
5. use Student_Management_System_DB_SELECT_JOINS.sql
```

---

## Build Project

```text
Ctrl + Shift + B
```

---

## Run Project

```text
F5
```

---

# 🎯 Learning Outcomes

This project demonstrates:

✅ CRUD Operations

✅ SQL Server Integration

✅ Stored Procedures

✅ SQL Joins

✅ ADO.NET

✅ SqlDataReader

✅ Generic Collections

✅ Object-Oriented Programming

✅ Database Normalization

✅ Foreign Keys

✅ Resource Management

✅ Console Application Development

---

# ⭐ Support

If you found this project useful:

⭐ Star this Repository

🍴 Fork this Repository

📢 Share with Others

---

# 👨‍💻 Author

### Ayush Singh

💻 Software Developer

📚 C# | .NET | SQL Server

🚀 Learning Enterprise Application Development Through Real-World Projects

---

# 📜 License

This project is developed for educational and learning purposes.
