using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow_Schools;

public class Person
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

public class Student : Person { }

public class Teacher : Person { }

public class Subject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher Teacher { get; set; }
}
// SchoolData class to manage lists of students, teachers, and subjects
public class SchoolData
{
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();
}
public class SchoolManager
{
    private SchoolData schoolData = new SchoolData();
    
    public void FillData()
    {
        schoolData.Students.Add(new Student { Name = "Rhema", ClassAndSection = "Class 1" });
        schoolData.Students.Add(new Student {Name = "Vishal", ClassAndSection = "Class 1" });
        schoolData.Students.Add(new Student { Name = "Sawani", ClassAndSection = "Class 1" });
        schoolData.Students.Add(new Student { Name = "Preethi", ClassAndSection = "Class 2" });
        schoolData.Students.Add(new Student { Name = "Praisy", ClassAndSection = "Class 2" });
        schoolData.Students.Add(new Student { Name = "Charu", ClassAndSection = "Class 2" });
        schoolData.Students.Add(new Student { Name = "Naveen", ClassAndSection = "Class 3" });
        schoolData.Students.Add(new Student { Name = "Abishek", ClassAndSection = "Class 3" });
        schoolData.Students.Add(new Student { Name = "David", ClassAndSection = "Class 3" });

        schoolData.Teachers.Add(new Teacher
        {
            Name = "Teacher 1",
            ClassAndSection = "Class 1"});

        schoolData.Teachers.Add(new Teacher
        {
            Name = "Teacher 2",
            ClassAndSection = "Class 2"
        });
        schoolData.Teachers.Add(new Teacher
        {
            Name = "Teacher 3",
            ClassAndSection = "Class 3"
        });
        
        schoolData.Subjects.Add(new Subject
        {
            Name = "English",
            SubjectCode = "E101",
            Teacher
        = schoolData.Teachers[0]
        });
        schoolData.Subjects.Add(new Subject
        {
            Name = "Physics",
            SubjectCode = "PH101",
            Teacher
        = schoolData.Teachers[1]
        });
        schoolData.Subjects.Add(new Subject
        {
            Name = "Hindi",
            SubjectCode = "H101",
            Teacher
        = schoolData.Teachers[2]
        });
       
    }
   
    public void DisplayStudentsInClass(string className)
    {
        var studentsInClass = schoolData.Students.Where(s => s.ClassAndSection ==
        className).ToList();
        Console.WriteLine($"Students in {className}:");
        foreach (var student in studentsInClass)
        {
            Console.WriteLine($"{student.Name}");
        }
    }
    
    public void DisplaySubjectsByTeacher(string teacherName)
    {
        var teacher = schoolData.Teachers.FirstOrDefault(t => t.Name == teacherName);
        if (teacher != null)
        {
            var subjectsByTeacher = schoolData.Subjects.Where(s => s.Teacher == teacher).ToList();
            Console.WriteLine($"Subjects taught by {teacherName}:");
            foreach (var subject in subjectsByTeacher)
            {
                Console.WriteLine($"{subject.Name} ({subject.SubjectCode})");
            }
        }
        else
        {
            Console.WriteLine($"Teacher {teacherName} not found.");
        }
    }
}
namespace Rainbow_Schools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = new SchoolManager();
            
            schoolManager.FillData();
            
            schoolManager.DisplayStudentsInClass("Class 3");
            
            schoolManager.DisplaySubjectsByTeacher("Teacher 2");
        }
    }
}

    