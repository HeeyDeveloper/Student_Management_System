using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Student_Management_System
{
    internal class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("===================================================================");
                Console.WriteLine("               STUDENT MANAGEMENT SYSTEM                           ");
                Console.WriteLine("===================================================================");
                Console.WriteLine("Please select an appropriate option from 1 to 6 as listed below:\n");
                Console.WriteLine("1. ---> Add Student");
                Console.WriteLine("2. ---> Update Student");
                Console.WriteLine("3. ---> Display All Student");
                Console.WriteLine("4. ---> Search Student By ID");
                Console.WriteLine("5. ---> Delete Student");
                Console.WriteLine("6. ---> Exit Application\n");

                using (SqlConnection connect = new SqlConnection("DATA SOURCE = YASH\\SQLEXPRESS; INITIAL CATALOG = Student_Management_System_DB; " +
                    "INTEGRATED SECURITY = SSPI"))
                {
                    connect.Open();

                    Console.Write("Kindly select an option from the menu and proceed : ");
                    int UserChoice = Convert.ToInt32(Console.ReadLine());

                    using (SqlCommand command = new SqlCommand("sp_Student_Management_System_DB", connect))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        List<AddStudent> StudentAdd = new List<AddStudent>();

                        switch (UserChoice)
                        {
                            //----------------------Student Registration Section----------------------
                            case 1:
                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                    ADD NEW STUDENT                                ");
                                Console.WriteLine("===================================================================\n");
                                Console.Write("Enter Student Name    : ");
                                string StdName = Console.ReadLine();
                                Console.Write("Gender                : ");
                                string StdGender = Console.ReadLine();
                                Console.Write("Student Age           : ");
                                int StdAge = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Phone Number          : ");
                                string StdPhoneNumber = Console.ReadLine();
                                Console.Write("Student Mail ID       : ");
                                string StdEmail = Console.ReadLine();
                                Console.Write("Class                 : ");
                                int StdClass = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Section               : ");
                                string StdSection = Console.ReadLine();
                                Console.Write("Roll Number           : ");
                                int StdRollNo = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Course Name           : ");
                                string StdCourse = Console.ReadLine();
                                Console.Write("Enter Student City    : ");
                                string StdStudentCity = Console.ReadLine();
                                Console.Write("Enter Student State   : ");
                                string StdStudentState = Console.ReadLine();
                                Console.Write("Enter Student Country : ");
                                string StdStudentCountry = Console.ReadLine();
                                Console.WriteLine();

                                SqlParameter[] AddStudentParameters =
                                {
                                    new SqlParameter("@UserChoice", SqlDbType.Int)
                                    { Value = UserChoice },

                                    new SqlParameter("@Student_Name", SqlDbType.VarChar,50)
                                    { Value = StdName },

                                    new SqlParameter("@Gender", SqlDbType.VarChar, 10)
                                    { Value = StdGender },

                                    new SqlParameter("@Age", SqlDbType.Int)
                                    { Value = StdAge },

                                    new SqlParameter("@Phone_Number", SqlDbType.VarChar,15)
                                    { Value = StdPhoneNumber },

                                    new SqlParameter("@Email", SqlDbType.VarChar,100)
                                    { Value = StdEmail },

                                    new SqlParameter("@Student_Class", SqlDbType.Int)
                                    { Value = StdClass },

                                    new SqlParameter("@Section", SqlDbType.VarChar,10)
                                    { Value = StdSection },

                                    new SqlParameter("@Roll_No", SqlDbType.Int)
                                    { Value = StdRollNo },

                                    new SqlParameter("@Course_Name", SqlDbType.VarChar, 40)
                                    { Value = StdCourse },

                                    new SqlParameter("@City", SqlDbType.VarChar, 40)
                                    { Value = StdStudentCity },

                                    new SqlParameter("@State", SqlDbType.VarChar, 40)
                                    { Value = StdStudentState },

                                    new SqlParameter("@Country", SqlDbType.VarChar, 40)
                                    { Value = StdStudentCountry }
                                };

                                command.Parameters.AddRange(AddStudentParameters);

                                command.ExecuteNonQuery();

                                Console.WriteLine();
                                Console.WriteLine("Student Details Captured");
                                Console.WriteLine("Record Saved . . . . . . .");
                                Console.ReadLine();
                                continue;

                            //----------------------Student Record Update Section----------------------
                            case 2:
                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                         UPDATE NEW STUDENT                        ");
                                Console.WriteLine("===================================================================\n");
                                Console.Write("Enter Student ID to modify : ");
                                int StudentId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Student Name    : ");
                                string Std_Name = Console.ReadLine();
                                Console.Write("Gender                : ");
                                string Std_Gender = Console.ReadLine();
                                Console.Write("Student Age           : ");
                                int Std_Age = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Phone Number          : ");
                                string Std_PhoneNumber = Console.ReadLine();
                                Console.Write("Student Mail ID       : ");
                                string Std_Email = Console.ReadLine();
                                Console.Write("Class                 : ");
                                int Std_Class = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Section               : ");
                                string Std_Section = Console.ReadLine();
                                Console.Write("Roll Number           : ");
                                int Std_RollNo = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Course Name           : ");
                                string Std_Course = Console.ReadLine();
                                Console.Write("Enter Student City    : ");
                                string Std_StudentCity = Console.ReadLine();
                                Console.Write("Enter Student State   : ");
                                string Std_StudentState = Console.ReadLine();
                                Console.Write("Enter Student Country : ");
                                string Std_StudentCountry = Console.ReadLine();
                                Console.WriteLine();

                                SqlParameter[] UpdateStudentParameters =
                                {
                                    new SqlParameter("@UserChoice", SqlDbType.Int)
                                    { Value = UserChoice },

                                    new SqlParameter("Student_ID", SqlDbType.Int)
                                    { Value = StudentId },

                                    new SqlParameter("@Student_Name", SqlDbType.VarChar,50)
                                    { Value = Std_Name },

                                    new SqlParameter("@Gender", SqlDbType.VarChar, 10)
                                    { Value = Std_Gender },

                                    new SqlParameter("@Age", SqlDbType.Int)
                                    { Value = Std_Age },

                                    new SqlParameter("@Phone_Number", SqlDbType.VarChar,15)
                                    { Value = Std_PhoneNumber },

                                    new SqlParameter("@Email", SqlDbType.VarChar,100)
                                    { Value = Std_Email },

                                    new SqlParameter("@Student_Class", SqlDbType.Int)
                                    { Value = Std_Class },

                                    new SqlParameter("@Section", SqlDbType.VarChar,10)
                                    { Value = Std_Section },

                                    new SqlParameter("@Roll_No", SqlDbType.Int)
                                    { Value = Std_RollNo },

                                    new SqlParameter("@Course_Name", SqlDbType.VarChar, 50)
                                    { Value = Std_Course },

                                    new SqlParameter("@City", SqlDbType.VarChar, 50)
                                    { Value = Std_StudentCity },

                                    new SqlParameter("@State", SqlDbType.VarChar, 50)
                                    { Value = Std_StudentState },

                                    new SqlParameter("@Country", SqlDbType.VarChar,50)
                                    { Value = Std_StudentCountry }
                                };

                                command.Parameters.AddRange(UpdateStudentParameters);
                                command.ExecuteNonQuery();

                                Console.WriteLine();
                                Console.WriteLine("Student Details Captured");
                                Console.WriteLine("Record Updated . . . . . . .");
                                Console.ReadLine();
                                continue;

                            //----------------------Student Search Section----------------------
                            case 3:
                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                         SEARCH ALL STUDENT                        ");
                                Console.WriteLine("===================================================================\n");

                                SqlParameter[] ReadStudentParameters =
                                {
                                        new SqlParameter("@UserChoice", SqlDbType.Int)
                                        { Value =  UserChoice}
                                };

                                command.Parameters.AddRange(ReadStudentParameters);

                                using (SqlDataReader dr = command.ExecuteReader())
                                {
                                    List<ReadStudent> readStudents = new List<ReadStudent>();

                                    while (dr.Read())
                                    {
                                        int StudentID = Convert.ToInt32(dr["Student_ID"]);
                                        string StudentName = Convert.ToString(dr["Student_Name"]);
                                        string StudentGender = Convert.ToString(dr["Gender"]);
                                        int StudentAge = Convert.ToInt32(dr["Age"]);
                                        string StudentPhoneNumber = Convert.ToString(dr["Phone_Number"]);
                                        string StudentEmail = Convert.ToString(dr["Email"]);
                                        int StudentClass = Convert.ToInt32(dr["Student_Class"]);
                                        string StudentSection = Convert.ToString(dr["Section"]);
                                        int StudentRollNo = Convert.ToInt32(dr["Roll_No"]);
                                        string StudentCourse = Convert.ToString(dr["Course_Name"]);
                                        string StudentCity = Convert.ToString(dr["City"]);
                                        string StudentState = Convert.ToString(dr["State"]);
                                        string StudentCountry = Convert.ToString(dr["Country"]);

                                        ReadStudent SearchStudent = new ReadStudent(StudentID, StudentName, StudentGender, StudentAge, StudentPhoneNumber, StudentEmail,
                                            StudentClass, StudentSection, StudentRollNo, StudentCourse, StudentCity, StudentState, StudentCountry);

                                        readStudents.Add(SearchStudent);
                                    }

                                    foreach (ReadStudent SearchStudent in readStudents)
                                    {
                                        Console.WriteLine($"Student ID      : {SearchStudent.Student_ID}");
                                        Console.WriteLine($"Student Name    : {SearchStudent.Student_Name}");
                                        Console.WriteLine($"Gender          : {SearchStudent.Gender}");
                                        Console.WriteLine($"Age             : {SearchStudent.Age}");
                                        Console.WriteLine($"Phone Number    : {SearchStudent.Phone_Number}");
                                        Console.WriteLine($"Email ID        : {SearchStudent.Email}");
                                        Console.WriteLine($"Stduent Class   : {SearchStudent.Student_Class}");
                                        Console.WriteLine($"Student Section : {SearchStudent.Section}");
                                        Console.WriteLine($"Student Roll No.: {SearchStudent.Roll_No}");
                                        Console.WriteLine($"Course Opted    : {SearchStudent.Course}");
                                        Console.WriteLine($"City            : {SearchStudent.City}");
                                        Console.WriteLine($"State           : {SearchStudent.State}");
                                        Console.WriteLine($"Country         : {SearchStudent.Country}");
                                        Console.WriteLine();
                                    }
                                    Console.ReadLine();

                                }

                            continue;

                            //----------------------Search Student Record By ID----------------------
                            case 4:

                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                     SEARCH STUDENT BY ID                          ");
                                Console.WriteLine("===================================================================\n");

                                Console.Write("Enter Student ID to search record: ");
                                int StudID = Convert.ToInt32(Console.ReadLine());

                                command.Parameters.Clear();

                                SqlParameter[] ReadStudentByID =
                                {
                                    new SqlParameter("@Student_ID", SqlDbType.Int)
                                    {
                                        Value = StudID
                                    },
                                    new SqlParameter("@UserChoice", SqlDbType.Int)
                                    {
                                        Value = 4
                                    }

                                };

                                command.Parameters.AddRange(ReadStudentByID);

                                using (SqlDataReader dr = command.ExecuteReader())
                                {
                                    List<ReadStudent> readStudentById = new List<ReadStudent>();

                                    while (dr.Read())
                                    {
                                        int StudentiD = Convert.ToInt32(dr["Student_ID"]);
                                        string StudentName = Convert.ToString(dr["Student_Name"]);
                                        string StudentGender = Convert.ToString(dr["Gender"]);
                                        int StudentAge = Convert.ToInt32(dr["Age"]);
                                        string StudentPhoneNumber = Convert.ToString(dr["Phone_Number"]);
                                        string StudentEmail = Convert.ToString(dr["Email"]);
                                        int StudentClass = Convert.ToInt32(dr["Student_Class"]);
                                        string StudentSection = Convert.ToString(dr["Section"]);
                                        int StudentRollNo = Convert.ToInt32(dr["Roll_No"]);
                                        string StudentCourse = Convert.ToString(dr["Course_Name"]);
                                        string StudentCity = Convert.ToString(dr["City"]);
                                        string StudentState = Convert.ToString(dr["State"]);
                                        string StudentCountry = Convert.ToString(dr["Country"]);

                                        ReadStudent SearchStudentByID = new ReadStudent(StudentiD, StudentName, StudentGender, StudentAge, StudentPhoneNumber, StudentEmail,
                                            StudentClass, StudentSection, StudentRollNo, StudentCourse, StudentCity, StudentState, StudentCountry);

                                        readStudentById.Add(SearchStudentByID);
                                    }
                                    if (readStudentById.Count > 0)
                                    {
                                        Console.WriteLine("Displaying Student Data Found....\n");

                                        foreach (ReadStudent SearchStudentByID in readStudentById)
                                        {
                                            Console.WriteLine($"Student ID      : {SearchStudentByID.Student_ID}");
                                            Console.WriteLine($"Student Name    : {SearchStudentByID.Student_Name}");
                                            Console.WriteLine($"Gender          : {SearchStudentByID.Gender}");
                                            Console.WriteLine($"Age             : {SearchStudentByID.Age}");
                                            Console.WriteLine($"Phone Number    : {SearchStudentByID.Phone_Number}");
                                            Console.WriteLine($"Email ID        : {SearchStudentByID.Email}");
                                            Console.WriteLine($"Stduent Class   : {SearchStudentByID.Student_Class}");
                                            Console.WriteLine($"Student Section : {SearchStudentByID.Section}");
                                            Console.WriteLine($"Student Roll No.: {SearchStudentByID.Roll_No}");
                                            Console.WriteLine($"Course Opted    : {SearchStudentByID.Course}");
                                            Console.WriteLine($"City            : {SearchStudentByID.City}");
                                            Console.WriteLine($"State           : {SearchStudentByID.State}");
                                            Console.WriteLine($"Country         : {SearchStudentByID.Country}\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No Student record found.\n");
                                    }

                                    Console.WriteLine("Please press Enter to continue...");
                                    Console.ReadLine();
                                }

                            continue;

                            // ===================== DELETE STUDENT RECORD BY ID =====================
                            case 5:

                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                     DELETE STUDENT BY ID                          ");
                                Console.WriteLine("===================================================================\n");

                                Console.Write("Provide Student ID to remove record: ");
                                int DeleteStudent = Convert.ToInt32(Console.ReadLine());

                                command.Parameters.Clear();

                                SqlParameter[] DeleteStudentByID =
                                {
                                    new SqlParameter("@Student_ID", SqlDbType.Int)
                                    {
                                        Value = DeleteStudent
                                    },
                                    new SqlParameter("@UserChoice", SqlDbType.Int)
                                    {
                                        Value = 4
                                    }
                                };

                                command.Parameters.AddRange(DeleteStudentByID);

                                using(SqlDataReader dr = command.ExecuteReader())
                                {
                                    List<DeleteStudent> DeleteStudentBy_ID = new List<DeleteStudent>();

                                    while (dr.Read())
                                    {
                                        int StudentID = Convert.ToInt32(dr["Student_ID"]);
                                        string StudentName = Convert.ToString(dr["Student_Name"]);
                                        string StudentGender = Convert.ToString(dr["Gender"]);
                                        int StudentAge = Convert.ToInt32(dr["Age"]);
                                        string StudentPhoneNumber = Convert.ToString(dr["Phone_Number"]);
                                        string StudentEmail = Convert.ToString(dr["Email"]);
                                        int StudentClass = Convert.ToInt32(dr["Student_Class"]);
                                        string StudentSection = Convert.ToString(dr["Section"]);
                                        int StudentRollNo = Convert.ToInt32(dr["Roll_No"]);
                                        string CourseName = Convert.ToString(dr["Course_Name"]);
                                        string CityName = Convert.ToString(dr["City"]);
                                        string StateName = Convert.ToString(dr["State"]);
                                        string CountryName = Convert.ToString(dr["Country"]);

                                        DeleteStudent DeleteStudentById = new DeleteStudent(StudentID, StudentName, StudentGender, StudentAge, StudentPhoneNumber,
                                            StudentEmail, StudentClass, StudentSection, StudentRollNo, CourseName, CityName, StateName, CountryName);

                                        DeleteStudentBy_ID.Add(DeleteStudentById);
                                    }

                                    if(DeleteStudentBy_ID.Count > 0)
                                    {
                                        foreach (DeleteStudent DeleteStudentById in DeleteStudentBy_ID)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine($"Student ID      : {DeleteStudentById.Student_ID}");
                                            Console.WriteLine($"Student Name    : {DeleteStudentById.Student_Name}");
                                            Console.WriteLine($"Gender          : {DeleteStudentById.Gender}");
                                            Console.WriteLine($"Age             : {DeleteStudentById.Age}");
                                            Console.WriteLine($"Phone Number    : {DeleteStudentById.Phone_Number}");
                                            Console.WriteLine($"Email ID        : {DeleteStudentById.Email}");
                                            Console.WriteLine($"Stduent Class   : {DeleteStudentById.Student_Class}");
                                            Console.WriteLine($"Student Section : {DeleteStudentById.Section}");
                                            Console.WriteLine($"Student Roll No.: {DeleteStudentById.Roll_No}");
                                            Console.WriteLine($"Course Opted    : {DeleteStudentById.Course}");
                                            Console.WriteLine($"City            : {DeleteStudentById.City}");
                                            Console.WriteLine($"State           : {DeleteStudentById.State}");
                                            Console.WriteLine($"Country         : {DeleteStudentById.Country}\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nNo Student Record Found With The Provided Student ID");
                                    }
                                }
                                Console.Write("Are you sure you want to delete this Student? (Y/N): ");
                                string Decision = Console.ReadLine();

                                if (Decision == "Y")
                                {
                                    command.Parameters.Clear();

                                    SqlParameter[] DecisionDelete =
                                    {
                                            new SqlParameter("@UserChoice", SqlDbType.Int)
                                            {
                                                Value = 5
                                            },
                                            new SqlParameter("@Student_ID", SqlDbType.Int)
                                            {
                                                Value = DeleteStudent
                                            }
                                    };

                                    command.Parameters.AddRange(DecisionDelete);
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("\nDeleting Student Record...");
                                    Console.WriteLine("\nRecord Deleted.....!!");
                                }
                                else
                                {
                                    Console.WriteLine("\nDeletion Process Cancelled");
                                }

                                Console.WriteLine("Please press ENTER to continue");
                                Console.ReadLine();

                            continue;

                            // ===================== EXIT OPTION =====================
                            case 6:
                                
                                Console.WriteLine("===================================================================");
                                Console.WriteLine("                         EXIT APPLICATION                          ");
                                Console.WriteLine("===================================================================\n");

                                Console.Write("Are you sure you want to exit from application? (Y/N): ");
                                string ExitDecision = Console.ReadLine();

                                if (ExitDecision == "Y" || ExitDecision == "y")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Closing Application....");
                                    Console.WriteLine("Thank You !!!");
                                    break;
                                }
                                else if(ExitDecision == "N" || ExitDecision == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Returning to Main Menu....");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Selection!!!!!!\n");
                                }

                                Console.Write("Please press ENTER to continue");
                                Console.ReadLine();
                            continue;
                        }
                    }
                    connect.Close();
                }
            }
        }
    }
}
public class AddStudent
{
    public int Student_ID, Age, Roll_No, Student_Class;
    public string Student_Name, Section, Gender, Phone_Number, Email, Course, City, State, Country;
    public AddStudent(int Student_ID, int Age, int Roll_No, int Student_Class, string Phone_Number,
        string Student_Name, string Section, string Gender, string Email,string Course, string City,string State,string Country )
    {
        this.Student_ID = Student_ID;
        this.Student_Name = Student_Name;
        this.Gender = Gender;
        this.Age = Age;
        this.Phone_Number = Phone_Number;
        this.Email = Email;
        this.Student_Class = Student_Class;
        this.Section = Section;
        this.Roll_No = Roll_No;
        this.Course = Course;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}

public class ReadStudent
{
    public int Student_ID, Age, Roll_No, Student_Class;
    public string Student_Name, Section, Gender, Phone_Number, Email, Course, City, State, Country;
    public ReadStudent(int Student_ID, string Student_Name, string Gender, int Age, string Phone_Number, string Email, int Student_Class, string Section, 
        int Roll_No, string Course, string City, string State, string Country)
    {
        this.Student_ID = Student_ID;
        this.Student_Name = Student_Name;
        this.Gender = Gender;
        this.Age = Age;
        this.Phone_Number = Phone_Number;
        this.Email = Email;
        this.Student_Class = Student_Class;
        this.Section = Section;
        this.Roll_No = Roll_No;
        this.Course = Course;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}

public class DeleteStudent
{
    public int Student_ID, Age, Roll_No, Student_Class;
    public string Student_Name, Section, Gender, Phone_Number, Email, Course, City, State, Country;

    public DeleteStudent(int Student_ID, string Student_Name, string Gender, int Age, string Phone_Number, string Email, int Student_Class, string Section,
        int Roll_No, string Course, string City, string State, string Country)
    {
        this.Student_ID = Student_ID;
        this.Student_Name = Student_Name;
        this.Gender = Gender;
        this.Age = Age;
        this.Phone_Number = Phone_Number;
        this.Email = Email;
        this.Student_Class = Student_Class;
        this.Section = Section;
        this.Roll_No = Roll_No;
        this.Course = Course;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}