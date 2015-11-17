using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groupon
{
    public class Student
    {
        public Student() { }
        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ClassRoom
    {
        public ClassRoom() { }
        public ClassRoom(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }

    public class DataSource
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student("A",18),
                        new Student("B",19),
                        new Student("C",11),
                        new Student("D",12),
                        new Student("E",20),
                        new Student("F",22),
                        new Student("C",11),
                        new Student("D",12),
                        new Student("E",20),
                        new Student("F",22)
            };

        }

        public static List<ClassRoom> GetData()
        {
            return new List<ClassRoom>()
            {
                new ClassRoom("1001")
                {
                    Students = new List<Student>()
                    {
                        new Student("A",18),
                        new Student("B",19),
                        new Student("C",11),
                        new Student("D",12),
                        new Student("E",20),
                        new Student("F",22),

                    }

                },
                new ClassRoom("1002")
                {
                    Students = new List<Student>()
                    {
                        new Student("A",18),
                        new Student("B",19),
                        new Student("C",11),
                        new Student("D",12),
                        new Student("E",20),
                        new Student("F",22),

                    }
                }
            };
        }
    }
}
