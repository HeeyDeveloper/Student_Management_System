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

-- 2. Create Reference Lookup Tables
CREATE TABLE Gender (
    Gender_Id INT PRIMARY KEY, 
    Gender VARCHAR(10) UNIQUE
);

CREATE TABLE Course (
    Course_Id INT PRIMARY KEY, 
    Course_Name VARCHAR(50) UNIQUE
);

CREATE TABLE Address_City (
    City_Id INT PRIMARY KEY, 
    City VARCHAR(50) UNIQUE
);

CREATE TABLE Address_State (
    State_Id INT PRIMARY KEY, 
    State VARCHAR(50) UNIQUE
);

CREATE TABLE Address_Country (
    Country_Id INT PRIMARY KEY, 
    Country VARCHAR(50) UNIQUE
);
GO

-- 3. Populate Reference Data
INSERT INTO Gender (Gender_Id, Gender) VALUES 
(1, 'Male'),
(2, 'Female'),
(3, 'Other');

INSERT INTO Course (Course_Id, Course_Name) VALUES 
(1, '.NET'),
(2, 'Java'),
(3, 'Python');

INSERT INTO Address_City (City_Id, City) VALUES 
(1, 'Bengaluru'),
(2, 'Hyderabad'),
(3, 'Delhi'),
(4, 'Mumbai');

INSERT INTO Address_State (State_Id, State) VALUES 
(1, 'Karnataka'),
(2, 'Telengana'),
(3, 'New Delhi'),
(4, 'Maharashtra');

INSERT INTO Address_Country (Country_Id, Country) VALUES 
(1, 'India'),
(2, 'United States'),
(3, 'United Kingdom'),
(4, 'Russia');
GO

-- 4. Create Main Student Table (Normalized with Foreign Keys)
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
GO

-- 5. Create Stored Procedure with Joins
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
    @Course_Name VARCHAR(40) = NULL,
    @City VARCHAR(40) = NULL,
    @State VARCHAR(40) = NULL,
    @Country VARCHAR(40) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Add Student
    IF @UserChoice = 1
    BEGIN
        INSERT INTO Student (
            Student_Name, Gender_ID, Age, Phone_Number, Email, 
            Student_Class, Section, Roll_No, Course_ID, City_ID, State_ID, Country_ID
        )
        VALUES (
            @Student_Name, 
            (SELECT Gender_Id FROM Gender WHERE Gender = @Gender), 
            @Age, 
            @Phone_Number, 
            @Email, 
            @Student_Class, 
            @Section, 
            @Roll_No, 
            (SELECT Course_Id FROM Course WHERE Course_Name = @Course_Name), 
            (SELECT City_Id FROM Address_City WHERE City = @City),
            (SELECT State_Id FROM Address_State WHERE State = @State), 
            (SELECT Country_Id FROM Address_Country WHERE Country = @Country)
        );
    END

    -- Update Student
    ELSE IF @UserChoice = 2
    BEGIN
        UPDATE Student 
        SET Student_Name = @Student_Name, 
            Gender_ID = (SELECT Gender_Id FROM Gender WHERE Gender = @Gender),
            Age = @Age, 
            Phone_Number = @Phone_Number, 
            Email = @Email, 
            Student_Class = @Student_Class, 
            Section = @Section, 
            Roll_No = @Roll_No,
            Course_ID = (SELECT Course_Id FROM Course WHERE Course_Name = @Course_Name),
            City_ID = (SELECT City_Id FROM Address_City WHERE City = @City),
            State_ID = (SELECT State_Id FROM Address_State WHERE State = @State),
            Country_ID = (SELECT Country_Id FROM Address_Country WHERE Country = @Country) 
        WHERE Student_ID = @Student_ID;
    END

    -- Display All Students (using Joins)
    ELSE IF @UserChoice = 3
    BEGIN
        SELECT 
            s.Student_Id,
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
    END

    -- Search Student By ID (using Joins)
    ELSE IF @UserChoice = 4
    BEGIN
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
    END

    -- Delete Student By ID
    ELSE IF @UserChoice = 5
    BEGIN
        DELETE FROM Student WHERE Student_ID = @Student_ID;
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
