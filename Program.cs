using System;
using System.Collections.Generic;
namespace q2
{
    class Program
    {
        enum sex
        {
            male=0,female=1,others
        }
        class Person
        {
            public string Name;
            public string SSN;
            public string Field;
            public sex Sex;
            public Person(string name, string ssn, string f, sex s)
            {
                Name = name;
                SSN = ssn;
                Field = f;
                Sex = s;
            }
        }
        class Professor : Person
        {
            public int RoomNo;
            public int MinTRA;
            public List<Student> ResearchAssistants = new List<Student>();
            static List<int> randoms = new List<int>();
            public Professor(string name, string ssn, string f, sex s) :base(name, ssn, f, s) {
                Random rnd = new Random();
                int num = rnd.Next(1,1000);
                while (randoms.Contains(num))
                {
                    num = rnd.Next(1, 1000);
                }
                RoomNo = num;
                randoms.Add(num);
            }
        }
        
        class Student : Person
        {
            public int EnteringYear;
            public Student(string name, string ssn, string f, sex s, int y):base(name,ssn,f,s)
            {
                EnteringYear = y;
            }
        }
        class TeacherAssistant : Student
        {
            public int UnitId;
            TeacherAssistant(string name, string ssn, string f, sex s, int y) : base(name, ssn, f, s, y) { }

        }
        class ResearchAssistant : Student
        {
            public string ProjectName;
            public int FreeTime;
            public string ProfessorSSN;
            ResearchAssistant(string name, string ssn, string f, sex s, int y) : base(name, ssn, f, s, y) { }
        }
        static bool checklength3to20(string s)
        {
            if (s.Length < 3 || s.Length > 20)
            {
                return false;
            }
            return true;
        }
        class Unit
        {
            static int UnitId = 1;
            string Name;
            string Field;
            int MaxSize;
            List<Student> students = new List<Student>();
            string ProfessorSSN;
            List<TeacherAssistant> teacherAssistants = new List<TeacherAssistant>();
        }
        static void register_student(List<Student> students, List<Professor> professors)
        {
            string[] ans = Console.ReadLine().Split(" ");

            try
            {
                if (!checklength3to20(ans[1]) || !checklength3to20(ans[4]))
                {
                    throw new Exception("input has wrong size");
                }
                if (int.Parse(ans[3]) < 1350 || int.Parse(ans[3]) > DateTime.Now.Year)
                {
                    throw new Exception("year is wrong");
                }
                foreach (Professor p in professors)
                {
                    if (ans[2] == p.SSN)
                    {
                        throw new Exception("this ssn already exist!");
                    }
                }
                foreach (Student p in students)
                {
                    if (ans[2] == p.SSN)
                    {
                        throw new Exception("this ssn already exist!");
                    }
                }
                students.Add(new Student(ans[1], ans[2], ans[4], (sex)Enum.Parse(typeof(sex), ans[5]), int.Parse(ans[3])));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void register_professor(List<Student> students, List<Professor> professors)
        {
            string[] ans = Console.ReadLine().Split(" ");

            try
            {
                if (!checklength3to20(ans[1]) || !checklength3to20(ans[3]))
                {
                    throw new Exception("input has wrong size");
                }
                if (ans[2].Length!=10)
                {
                    throw new Exception("ssn number is wrong");
                }
                foreach (Professor p in professors)
                {
                    if (ans[2] == p.SSN)
                    {
                        throw new Exception("this ssn already exist!");
                    }
                }
                foreach (Student p in students)
                {
                    if (ans[2] == p.SSN)
                    {
                        throw new Exception("this ssn already exist!");
                    }
                }
                professors.Add(new Professor(ans[1],ans[2],ans[3], (sex)Enum.Parse(typeof(sex), ans[4])));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            List<Student> students = new List<Student>();
            List<Professor> professors = new List<Professor>();
            ///register_student <Name> <SSN> <EnteringYear > <Field> <Sex>
            
            ///register_professor<Name> < SSN > < Field > < Sex >
            
        }
    }
}

