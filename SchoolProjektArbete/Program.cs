using SchoolProjektArbete.Models;
using Microsoft.Data.SqlClient;
using System.Data;

SqlConnection sqlCon1 = new SqlConnection(@"Data Source = EJPATOLITEJ; Initial Catalog = School; Integrated Security = True");
using SchoolContext Context = new SchoolContext();

bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("Welcome to the school database");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1: Fetch Employee info");
    Console.WriteLine("2: Fetch Student info");
    Console.WriteLine("3: Fetch Class info");
    Console.WriteLine("4: Fetch Student Grade info");
    Console.WriteLine("5: Fetch Class Grade info");
    Console.WriteLine("6: Add new Student");
    Console.WriteLine("7: Add new Employee");

    string caseChoice = Console.ReadLine();
    switch (caseChoice)
    {
        #region Case1
        case "1":
            bool runCase = true;
            while (runCase)
            {
                DataTable EmpdTbl = new DataTable();

                Console.Clear();
                Console.WriteLine("Which Employees would you like to fetch?");
                Console.WriteLine("1. Principle");
                Console.WriteLine("2. Teachers");
                Console.WriteLine("3. Admin");
                Console.WriteLine("4. Janitors");
                Console.WriteLine("5. All Employees");
                Console.WriteLine("6. See how many Employees per position");
                Console.WriteLine("7. Go back to main menu");
                string case1Choice = Console.ReadLine();
                switch (case1Choice)
                {
                    case "1":
                        Console.Clear();
                        SqlDataAdapter EmpDA1 = new SqlDataAdapter(@"Select * from Employee where EmpPosition = 'Principle'", sqlCon1);
                        EmpDA1.Fill(EmpdTbl);
                        foreach (DataRow item in EmpdTbl.Rows)
                        {
                            Console.WriteLine("ID: " + item["EmployeeID"]);
                            Console.WriteLine("Name: " + item["EmpFirstName"] + " " + item["EmpLastName"]);
                            Console.WriteLine("Position: " + item["EmpPosition"]);
                            Console.WriteLine("Phone: " + "+46 " + item["EmpPhone"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        SqlDataAdapter EmpDA2 = new SqlDataAdapter(@"Select * from Employee where EmpPosition = 'Teacher'", sqlCon1);
                        EmpDA2.Fill(EmpdTbl);
                        foreach (DataRow item in EmpdTbl.Rows)
                        {
                            Console.WriteLine("ID: " + item["EmployeeID"]);
                            Console.WriteLine("Name: " + item["EmpFirstName"] + " " + item["EmpLastName"]);
                            Console.WriteLine("Position: " + item["EmpPosition"]);
                            Console.WriteLine("Phone: " + "+46 " + item["EmpPhone"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        SqlDataAdapter EmpDA3 = new SqlDataAdapter(@"Select * from Employee where EmpPosition = 'Admin'", sqlCon1);
                        EmpDA3.Fill(EmpdTbl);
                        foreach (DataRow item in EmpdTbl.Rows)
                        {
                            Console.WriteLine("ID: " + item["EmployeeID"]);
                            Console.WriteLine("Name: " + item["EmpFirstName"] + " " + item["EmpLastName"]);
                            Console.WriteLine("Position: " + item["EmpPosition"]);
                            Console.WriteLine("Phone: " + "+46 " + item["EmpPhone"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        SqlDataAdapter EmpDA4 = new SqlDataAdapter(@"Select * from Employee where EmpPosition = 'Janitor'", sqlCon1);
                        EmpDA4.Fill(EmpdTbl);
                        foreach (DataRow item in EmpdTbl.Rows)
                        {
                            Console.WriteLine("ID: " + item["EmployeeID"]);
                            Console.WriteLine("Name: " + item["EmpFirstName"] + " " + item["EmpLastName"]);
                            Console.WriteLine("Position: " + item["EmpPosition"]);
                            Console.WriteLine("Phone: " + "+46 " + item["EmpPhone"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        SqlDataAdapter EmpDA5 = new SqlDataAdapter(@"Select * from Employee", sqlCon1);
                        EmpDA5.Fill(EmpdTbl);
                        foreach (DataRow item in EmpdTbl.Rows)
                        {
                            Console.WriteLine(item["EmployeeID"]);
                            Console.WriteLine(item["EmpFirstName"] + " " + item["EmpLastName"]);
                            Console.WriteLine(item["EmpPosition"]);
                            Console.WriteLine("+46 " + item["EmpPhone"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        int nrOfTeachers = 0;
                        int nrOfPrinc = 0;
                        int nrOfJanitor = 0;
                        int nrOfAdmin = 0;
                        foreach (Employee item in Context.Employees)
                        {
                            if (item.EmpPosition == "Teacher") nrOfTeachers++;
                            else if (item.EmpPosition == "Principle") nrOfPrinc++;
                            else if (item.EmpPosition == "Janitor") nrOfJanitor++;
                            else if (item.EmpPosition == "Admin") nrOfAdmin++;
                        }
                        Console.WriteLine("Nr of Teachers: {0}", nrOfTeachers);
                        Console.WriteLine("\nNr of Principles: {0}", nrOfPrinc);
                        Console.WriteLine("\nNr of Janitors: {0}", nrOfJanitor);
                        Console.WriteLine("\nNr of Admins: {0}", nrOfAdmin);
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Going back to main menu");
                        runCase = false;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, try again!");
                        Console.ReadKey();
                        break;
                }
            }
            break;

        #endregion        #region Case2

        #region Case2
        case "2":
            Console.Clear();
            Console.WriteLine("Sort Students by: ");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");

            int nameSort = Int32.Parse(Console.ReadLine());
            if (nameSort == 1)
            {
                Console.Clear();
                Console.WriteLine("1. Ascending");
                Console.WriteLine("2. Descending");
                Console.WriteLine();
                int ascDesc = Int32.Parse(Console.ReadLine());
                if (ascDesc == 1)
                {
                    Console.Clear();
                    var student = Context.Students.OrderBy(s => s.StudFirstName);
                    foreach (var item in student)
                    {
                        Console.WriteLine("ID: {0}", item.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.StudFirstName, item.StudLastName);
                        Console.WriteLine("SSN: {0}", item.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.StudPhone);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Clear();
                    var student = Context.Students.OrderByDescending(s => s.StudFirstName);
                    foreach (var item in student)
                    {
                        Console.WriteLine("ID: {0}", item.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.StudFirstName, item.StudLastName);
                        Console.WriteLine("SSN: {0}", item.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.StudPhone);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("1. Ascending");
                Console.WriteLine("2. Descending");
                int ascDesc = Int32.Parse(Console.ReadLine());
                if (ascDesc == 1)
                {
                    Console.Clear();
                    var student = Context.Students.OrderBy(s => s.StudLastName);
                    foreach (var item in student)
                    {
                        Console.WriteLine("ID: {0}", item.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.StudFirstName, item.StudLastName);
                        Console.WriteLine("SSN: {0}", item.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.StudPhone);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Clear();
                    var student = Context.Students.OrderByDescending(s => s.StudLastName);
                    foreach (var item in student)
                    {
                        Console.WriteLine("ID: {0}", item.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.StudFirstName, item.StudLastName);
                        Console.WriteLine("SSN: {0}", item.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.StudPhone);
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
            break;

        #endregion

        #region Case3
        case "3":
            Console.Clear();
            Console.WriteLine("Choose a class to fetch info from: ");
            Console.WriteLine("1. Maths");
            Console.WriteLine("2. Science");
            Console.WriteLine("3. Computers");
            Console.WriteLine("4. English");
            Console.WriteLine("5. French");
            Console.WriteLine("6. Social Studies");
            Console.WriteLine("7. Show all active classes");
            string case3Choice = Console.ReadLine();

            switch (case3Choice)
            {
                case "1":
                    Console.Clear();
                    var studclass = Context.StudClasses;
                    var student = Context.Students.Join(studclass, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 1);
                    foreach (var item in student)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    var studclass2 = Context.StudClasses;
                    var student2 = Context.Students.Join(studclass2, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 2);
                    foreach (var item in student2)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    var studclass3 = Context.StudClasses;
                    var student3 = Context.Students.Join(studclass3, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 3);
                    foreach (var item in student3)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    var studclass4 = Context.StudClasses;
                    var student4 = Context.Students.Join(studclass4, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 4);
                    foreach (var item in student4)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    var studclass5 = Context.StudClasses;
                    var student5 = Context.Students.Join(studclass5, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 5);
                    foreach (var item in student5)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    var studclass6 = Context.StudClasses;
                    var student6 = Context.Students.Join(studclass6, s => s.StudentId, c => c.FkStudId, (s, c) => new { S = s, C = c }).Where(S => S.C.FkClassId == 6);
                    foreach (var item in student6)
                    {
                        Console.WriteLine("ID: {0}", item.S.StudentId);
                        Console.WriteLine("Student Name: {0} {1}", item.S.StudFirstName, item.S.StudLastName);
                        Console.WriteLine("SSN: {0}", item.S.Ssn);
                        Console.WriteLine("Phone: +46 {0}", item.S.StudPhone);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    foreach (Class item in Context.Classes)
                    {
                        if (item.ClassActive == "true")
                        {
                            Console.WriteLine(item.ClassName);
                            Console.WriteLine();
                        }
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, try again!");
                    Console.ReadKey();
                    break;
            }
            break;

        #endregion

        #region Case4
        case "4":
            Console.Clear();
            Console.WriteLine("Grades from the last 30 days: ");
            Console.WriteLine();

            DataTable GradeTbl = new DataTable();

            SqlDataAdapter GradeDA = new SqlDataAdapter(@"select StudentID, StudFirstName, StudLastName, Grade, Date from Student
            join Grades on Student.StudentID = Grades.GStudID
            where DATEDIFF(day, Grades.Date, GETDATE()) between 0 and 30", sqlCon1);
            GradeDA.Fill(GradeTbl);
            foreach (DataRow item in GradeTbl.Rows)
            {
                Console.WriteLine("ID: " + item["StudentID"]);
                Console.WriteLine("Name: " + item["StudFirstName"] + " " + item["StudLastName"]);
                Console.WriteLine("Grade: " + item["Grade"]);
                Console.WriteLine("Date: " + item["Date"]);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
            break;

        #endregion

        #region Case5
        case "5":
            Console.Clear();
            DataTable GradeMonthTbl = new DataTable();

            SqlDataAdapter GradeMonthDA = new SqlDataAdapter(@"select ClassName, avg(Grade) as avgGrade, max(Grade) as maxGrade, min(Grade) as minGrade from Grades 
            join Class on Grades.GClassID = Class.ClassID
            group by ClassName", sqlCon1);
            GradeMonthDA.Fill(GradeMonthTbl);
            foreach (DataRow item in GradeMonthTbl.Rows)
            {
                Console.WriteLine("Class: " + item["ClassName"]);
                Console.WriteLine("Average Grade: " + item["avgGrade"]);
                Console.WriteLine("Highest Grade: " + item["maxGrade"]);
                Console.WriteLine("Lowest Grade: " + item["minGrade"]);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();

            break;

        #endregion

        #region Case6
        case "6":
            Console.Clear();
            Console.WriteLine("Add new student: ");
            Console.WriteLine();
            Console.Write("First Name: ");
            string _studFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string _studLastName = Console.ReadLine();
            Console.Write("SSN: ");
            string _studSSN = Console.ReadLine();
            Console.Write("Phone Number: ");
            int _studPhone = Int32.Parse(Console.ReadLine());

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sqlQuery = $"insert into Student (StudFirstName, StudLastName, SSN, StudPhone) values ('{_studFirstName}', '{_studLastName}', '{_studSSN}', {_studPhone})";
            sqlCon1.Open();
            dataAdapter.InsertCommand = new SqlCommand(sqlQuery, sqlCon1);
            dataAdapter.InsertCommand.ExecuteNonQuery();

            Console.Clear();
            Console.WriteLine("New Student added!");
            Console.ReadKey();
            Console.Clear();
            break;

        #endregion

        #region Case7
        case "7":
            Console.Clear();
            Console.WriteLine("Add new Employee: ");
            Console.WriteLine();

            Employee employee = new Employee();
            Console.Write("Employee First Name: ");
            employee.EmpFirstName = Console.ReadLine();
            Console.Write("Employee Last Name: ");
            employee.EmpLastName = Console.ReadLine();
            Console.Write("Employee Position: ");
            employee.EmpPosition = Console.ReadLine();
            Console.Write("Employee Phone Number: ");
            employee.EmpPhone = Int32.Parse(Console.ReadLine());

            Context.Employees.Add(employee);
            Context.SaveChanges();

            Console.Clear();
            Console.WriteLine("New Employee added!");
            Console.ReadKey();
            break;

        #endregion

        default:
            Console.Clear();
            Console.WriteLine("Invalid choice, try again!");
            Console.ReadKey();
            break;
    }
}
