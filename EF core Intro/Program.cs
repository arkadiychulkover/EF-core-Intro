﻿using EF_core_Intro.Entitys;
using Microsoft.EntityFrameworkCore;

namespace EF_core_Intro
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppDBContext())
            {
                dbContext.Database.EnsureCreated();
                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Create Student");
                    Console.WriteLine("2. Read All Students");
                    Console.WriteLine("3. Update Student by ID");
                    Console.WriteLine("4. Delete Student");
                    Console.WriteLine("5. Create Pasport");
                    Console.WriteLine("6. Create Teacher");
                    Console.WriteLine("7. Create Cafedra");
                    Console.WriteLine("8. Create Subject");
                    Console.WriteLine("9. Read All Data");
                    Console.WriteLine("10. Update Pasport");
                    Console.WriteLine("11. Update Teacher");
                    Console.WriteLine("12. Update Cafedra");
                    Console.WriteLine("13. Update Subject");
                    Console.WriteLine("14. Read All Groups");
                    Console.WriteLine("15. Add Group");
                    Console.WriteLine("16. Update Group");
                    Console.WriteLine("17. Exit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            CreateSRUDENT(dbContext);
                            break;
                        case "2":
                            ReadAll(dbContext);
                            break;
                        case "3":
                            UpdateStudentById(dbContext);
                            break;
                        case "4":
                            DeleteStudent(dbContext);
                            break;
                        case "5":
                            CreatePasport(dbContext);
                            break;
                        case "6":
                            CreateTeacher(dbContext);
                            break;
                        case "7":
                            CreateCafedra(dbContext);
                            break;
                        case "8":
                            CreateSubject(dbContext);
                            break;
                        case "9":
                            ReadAllData(dbContext);
                            break;
                        case "10":
                            UpdatePasport(dbContext);
                            break;
                        case "11":
                            UpdateTeacher(dbContext);
                            break;
                        case "12":
                            UpdateCafedra(dbContext);
                            break;
                        case "13":
                            UpdateSubject(dbContext);
                            break;
                        case "14":
                            ReadAllGroups(dbContext);
                            break;
                        case "15":
                            AddGroup(dbContext);
                            break;
                        case "16":
                            UpdateGroup(dbContext);
                            break;
                        case "17":
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
        }

        public static void ReadAllGroups(AppDBContext dbContext)
        {
            var groups = dbContext.Groups.Include(g => g.Students).ToList();
            foreach (var group in groups)
            {
                Console.WriteLine(group.ToString());
            }
        }

        public static void AddGroup(AppDBContext dbContext)
        {

            Group group = new Group();
            Console.WriteLine("Enter group name:");
            group.Name = Console.ReadLine();
            dbContext.Groups.Add(group);
            dbContext.SaveChanges();
        }

        public static void DeleteStudent(AppDBContext dbContext)
        {
            Console.WriteLine("Enter student ID to delete:");
            int id = int.Parse(Console.ReadLine());
            Student? studentToDelete = dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                dbContext.Students.Remove(studentToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public static void ReadAll(AppDBContext dbContext)
        {
            var students = dbContext.Students.Include(s => s.Group).ToList();
            foreach (var stud in students)
            {
                Console.WriteLine(stud.ToString());
            }
        }

        public static void UpdateStudentById(AppDBContext dbContext)
        {
            Console.WriteLine("Enter ID");
            int id = int.Parse(Console.ReadLine());
            Student? student = dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("Enter student name:");
                student.Name = Console.ReadLine();

                Console.WriteLine("Enter student age:");
                student.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter student email:");
                student.Email = Console.ReadLine();

                Console.WriteLine("Enter student study format (Online, FullTime, PartTime, Gibrid):");
                string formatInput = Console.ReadLine();

                Console.WriteLine("Enter student scholarship (or leave empty):");
                student.Scolarship = float.TryParse(Console.ReadLine(), out float scholarship) ? scholarship : (float?)null;

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public static void CreateSRUDENT(AppDBContext dbContext)
        {
            Student student = new Student();

            Console.WriteLine("Enter student name:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Enter student age:");
            student.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter student email:");
            student.Email = Console.ReadLine();

            Console.WriteLine("Enter student study format (Online, FullTime, PartTime, Gibrid):");
            string formatInput = Console.ReadLine();
            if (Enum.TryParse(formatInput, out StudyFormat format))
            {
                student.StudyFormat = format;
            }
            else
            {
                Console.WriteLine("Invalid format. Using FullTime.");
                student.StudyFormat = StudyFormat.FullTime;
            }

            Console.WriteLine("Enter group ID:");
            if (!int.TryParse(Console.ReadLine(), out int groupId))
            {
                Console.WriteLine("Invalid group ID.");
                return;
            }

            var group = dbContext.Groups.FirstOrDefault(g => g.Id == groupId);
            if (group == null)
            {
                Console.WriteLine("Group not found. Creating new one.");
                Console.WriteLine("Enter new group name:");
                group = new Group { Name = Console.ReadLine() };
                dbContext.Groups.Add(group);
                dbContext.SaveChanges();
            }

            student.Group = group;

            Console.WriteLine("Enter student scholarship (or leave empty):");
            student.Scolarship = float.TryParse(Console.ReadLine(), out float scholarship) ? scholarship : (float?)null;

            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            Console.WriteLine("Student created successfully.");
        }

        public static void CreatePasport(AppDBContext dbContext)
        {
            Pasport pasport = new Pasport();
            Console.WriteLine("Enter pasport number:");
            pasport.Number = Console.ReadLine();
            Console.WriteLine("Enter student ID:");
            int studentId = int.Parse(Console.ReadLine());
            pasport.StudentId = studentId;
            dbContext.Pasports.Add(pasport);
            dbContext.SaveChanges();
        }

        public static void CreateTeacher(AppDBContext dbContext)
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("Enter teacher name:");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Enter teacher salary:");
            teacher.Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter teacher age:");
            teacher.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cafedra ID (or leave empty to create a new one):");
            string cafedraIdInput = Console.ReadLine();
            if (cafedraIdInput != null)
            {
                if (int.TryParse(cafedraIdInput, out int cafedraId))
                {
                    Cafedra? cafedra = dbContext.Cafedras.FirstOrDefault(c => c.Id == cafedraId);
                    if (cafedra != null)
                    {
                        teacher.CafedraId = cafedraId;
                    }
                    else
                    {
                        Console.WriteLine("Cafedra not found. Creating new one.");
                        CreateCafedra(dbContext);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Cafedra ID. Creating new one.");
                    CreateCafedra(dbContext);
                }
            }
            else
            {
                CreateCafedra(dbContext);
            }
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        public static void CreateCafedra(AppDBContext dbContext)
        {
            Cafedra cafedra = new Cafedra();
            Console.WriteLine("Enter cafedra name:");
            cafedra.Name = Console.ReadLine();
            Console.WriteLine("Enter cafedra description:");
            cafedra.Description = Console.ReadLine();
            Console.WriteLine("Enter cafedra financing:");
            cafedra.Financing = int.Parse(Console.ReadLine());
            dbContext.Cafedras.Add(cafedra);
            dbContext.SaveChanges();
        }

        public static void CreateSubject(AppDBContext dbContext)
        {
            Subject subject = new Subject();
            Console.WriteLine("Enter subject name:");
            subject.Name = Console.ReadLine();
            Console.WriteLine("Enter teacher ID:");
            int teacherId = int.Parse(Console.ReadLine());
            Teacher? teacher = dbContext.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found. Creating new one.");
                teacher = new Teacher { Name = "Default Teacher", Salary = 25000 };
                dbContext.Teachers.Add(teacher);
                dbContext.SaveChanges();
            }
            subject.CafedraId = teacher.CafedraId;
            Console.WriteLine("Enter subject description:");
            subject.Description = Console.ReadLine();
            subject.TeacherId = teacherId;
            Console.WriteLine("Enter subject time (in hours):");
            subject.Time = int.Parse(Console.ReadLine());
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
        }

        public static void ReadAllData(AppDBContext dbContext)
        {
            var students = dbContext.Students.Include(s => s.Group).Include(s => s.Pasport).ToList();
            var teachers = dbContext.Teachers.Include(t => t.Subjects).Include(t => t.Cafedra).ToList();
            var subjects = dbContext.Subjects.Include(s => s.Teachers).Include(s => s.Cafedra).ToList();
            var cafedras = dbContext.Cafedras.Include(c => c.Teachers).ToList();
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("\nTeachers:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher.ToString());
            }
            Console.WriteLine("\nSubjects:");
            foreach (var subject in subjects)
            {
                Console.WriteLine(subject.ToString());
            }
            Console.WriteLine("\nCafedras:");
            foreach (var cafedra in cafedras)
            {
                Console.WriteLine(cafedra.ToString());
            }
        }

        public static void UpdatePasport(AppDBContext dbContext)
        {
            Console.WriteLine("Enter pasport ID to update:");
            int id = int.Parse(Console.ReadLine());
            Pasport? pasport = dbContext.Pasports.FirstOrDefault(p => p.Id == id);
            if (pasport != null)
            {
                Console.WriteLine("Enter new pasport number:");
                pasport.Number = Console.ReadLine();
                dbContext.SaveChanges();
                Console.WriteLine("Pasport updated successfully.");
            }
            else
            {
                Console.WriteLine("Pasport not found.");
            }
        }

        public static void UpdateTeacher(AppDBContext dbContext)
        {
            Console.WriteLine("Enter teacher ID to update:");
            int id = int.Parse(Console.ReadLine());
            Teacher? teacher = dbContext.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                Console.WriteLine("Enter new teacher name:");
                teacher.Name = Console.ReadLine();
                Console.WriteLine("Enter new teacher salary:");
                teacher.Salary = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter new teacher age:");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new cafedra ID:");
                string cafedraIdInput = Console.ReadLine();
                dbContext.SaveChanges();
                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        public static void UpdateCafedra(AppDBContext dbContext)
        {
            Console.WriteLine("Enter cafedra ID to update:");
            int id = int.Parse(Console.ReadLine());
            Cafedra? cafedra = dbContext.Cafedras.FirstOrDefault(c => c.Id == id);
            if (cafedra != null)
            {
                Console.WriteLine("Enter new cafedra name:");
                cafedra.Name = Console.ReadLine();
                Console.WriteLine("Enter new cafedra description:");
                cafedra.Description = Console.ReadLine();
                Console.WriteLine("Enter new cafedra financing:");
                cafedra.Financing = int.Parse(Console.ReadLine());
                dbContext.SaveChanges();
                Console.WriteLine("Cafedra updated successfully.");
            }
            else
            {
                Console.WriteLine("Cafedra not found.");
            }
        }

        public static void UpdateSubject(AppDBContext dbContext)
        {
            Console.WriteLine("Enter subject ID to update:");
            int id = int.Parse(Console.ReadLine());
            Subject? subject = dbContext.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null)
            {
                Console.WriteLine("Enter new subject name:");
                subject.Name = Console.ReadLine();
                Console.WriteLine("Enter new subject description:");
                subject.Description = Console.ReadLine();
                Console.WriteLine("Enter new subject time:");
                subject.Time = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new teacher ID:");
                int teacherId = int.Parse(Console.ReadLine());
                dbContext.SaveChanges();
                Console.WriteLine("Subject updated successfully.");
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }

        public static void UpdateGroup(AppDBContext dbContext)
        {
            Console.WriteLine("Enter group ID to update:");
            int id = int.Parse(Console.ReadLine());
            Group? group = dbContext.Groups.FirstOrDefault(g => g.Id == id);
            if (group != null)
            {
                Console.WriteLine("Enter new group name:");
                group.Name = Console.ReadLine();
                dbContext.SaveChanges();
                Console.WriteLine("Group updated successfully.");
            }
            else
            {
                Console.WriteLine("Group not found.");
            }
        }
    }
}
