# Student Management System

A C# Console Application for managing student records. This project uses the .NET Framework 4.7.2 and SQL Server for data persistence, interacting with the database via stored procedures.

## Features

- **Add Student**: Capture and save details such as Name, Gender, Age, Phone Number, Email, Class, Section, Roll Number, Course, City, State, and Country.
- **Update Student**: Modify details of any student record by specifying their Student ID.
- **Display All Students**: List all student records stored in the database.
- **Search Student by ID**: Quickly retrieve individual student details by their ID.
- **Delete Student**: Remove a student record from the system with a confirmation prompt.

---

## Technical Stack

- **Language**: C#
- **Framework**: .NET Framework 4.7.2
- **Database**: SQL Server
- **Data Access**: ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)
- **Architecture**: Stored Procedure-driven CRUD operations

---

## Database Setup Instructions

To run this application, you need to set up the database and stored procedures on your local SQL Server instance.

### 1. Update Connection String
In [Program.cs](file:///c:/Users/ayush/source/repos/My_First_Project_Student_Management_System/Student_Management_System/Program.cs#L31-L32), update the SQL Server connection string to match your SQL Server instance settings:
```csharp
using (SqlConnection connect = new SqlConnection("DATA SOURCE = YOUR_SERVER_NAME; INITIAL CATALOG = Student_Management_System_DB; INTEGRATED SECURITY = SSPI"))
```

### 2. SQL Schema & Stored Procedure script
Execute the following SQL script in SQL Server Management Studio (SSMS) or your preferred SQL client to create the database, table, and stored procedure:

```sql
-- 1. Create Database
CREATE DATABASE Student_Management_System_DB;
GO

USE Student_Management_System_DB;
GO

-- 2. Create Table
CREATE TABLE Students (
    Student_ID INT IDENTITY(1,1) PRIMARY KEY,
    Student_Name VARCHAR(50),
    Gender VARCHAR(10),
    Age INT,
    Phone_Number VARCHAR(15),
    Email VARCHAR(100),
    Student_Class INT,
    Section VARCHAR(10),
    Roll_No INT,
    Course_Name VARCHAR(50),
    City VARCHAR(50),
    State VARCHAR(50),
    Country VARCHAR(50)
);
GO

-- 3. Create Stored Procedure
CREATE PROCEDURE sp_Student_Management_System_DB
    @UserChoice INT,
    @Student_ID INT = NULL,
    @Student_Name VARCHAR(50) = NULL,
    @Gender VARCHAR(10) = NULL,
    @Age INT = NULL,
    @Phone_Number VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @Student_Class INT = NULL,
    @Section VARCHAR(10) = NULL,
    @Roll_No INT = NULL,
    @Course_Name VARCHAR(50) = NULL,
    @City VARCHAR(50) = NULL,
    @State VARCHAR(50) = NULL,
    @Country VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Add Student
    IF @UserChoice = 1
    BEGIN
        INSERT INTO Students (Student_Name, Gender, Age, Phone_Number, Email, Student_Class, Section, Roll_No, Course_Name, City, State, Country)
        VALUES (@Student_Name, @Gender, @Age, @Phone_Number, @Email, @Student_Class, @Section, @Roll_No, @Course_Name, @City, @State, @Country);
    END
    
    -- Update Student
    ELSE IF @UserChoice = 2
    BEGIN
        UPDATE Students
        SET Student_Name = @Student_Name,
            Gender = @Gender,
            Age = @Age,
            Phone_Number = @Phone_Number,
            Email = @Email,
            Student_Class = @Student_Class,
            Section = @Section,
            Roll_No = @Roll_No,
            Course_Name = @Course_Name,
            City = @City,
            State = @State,
            Country = @Country
        WHERE Student_ID = @Student_ID;
    END
    
    -- Display All Students
    ELSE IF @UserChoice = 3
    BEGIN
        SELECT Student_ID, Student_Name, Gender, Age, Phone_Number, Email, Student_Class, Section, Roll_No, Course_Name, City, State, Country
        FROM Students;
    END
    
    -- Search Student By ID (also used in option 5 for display before deletion)
    ELSE IF @UserChoice = 4
    BEGIN
        SELECT Student_ID, Student_Name, Gender, Age, Phone_Number, Email, Student_Class, Section, Roll_No, Course_Name, City, State, Country
        FROM Students
        WHERE Student_ID = @Student_ID;
    END
    
    -- Delete Student By ID
    ELSE IF @UserChoice = 5
    BEGIN
        DELETE FROM Students
        WHERE Student_ID = @Student_ID;
    END
END
GO
```

---

## How to Build and Run

1. Open the [Student_Management_System.sln](file:///c:/Users/ayush/source/repos/My_First_Project_Student_Management_System/Student_Management_System.sln) file in Visual Studio.
2. Build the project using `Ctrl + Shift + B`.
3. Press `F5` to run the console application.
4. Interact with the application menu using the console prompts.
