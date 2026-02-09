using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {

        struct StudentRecord
        {
            public int Number;        // порядковый номер
            public string Group;      // группа
            public string FullName;   // ФИО
            public int[] Grades;      // оценки
        }
        /*
        struct StudentRecord
        {
            public int Number;
            public string Group;
            public string FullName;
            public int[] Grades;

            // Метод 1 - подсчёт среднего балла
            public double GetAverage()
            {
                int sum = 0;

                for (int i = 0; i < Grades.Length; i++)
                {
                    sum += Grades[i];
                }

                return sum / (double)Grades.Length;
            }

            // Метод 2 - вывод информации о студенте
            public void Print()
            {
                Console.WriteLine($"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}");
            }
        }
        /*
        static void RenameStudent(StudentRecord student)
        {
            student.FullName = "Андрей ШИМБИРЁВ";
        }
        */
        static void Main(string[] args)
        {
            {

                // 1) Данные студента
                int number = 1;
                string group = "П-1-24";
                string fio = "Андрей Шибирёв";

                // 2) Оценки
                int grade1 = 5;
                int grade2 = 4;
                int grade3 = 5;

                // 3) Среднее арифметическое
                double average = (grade1 + grade2 + grade3) / 3.0;

                // 4) Вывод
                Console.WriteLine($"№{number} | {group} | {fio} | Оценки: {grade1}, {grade2}, {grade3} | Среднее: {average:F2}");
            }
            //---------------------------------------------
            {
                /*
                int number = 1;
                string group = "П-1-24";
                string fio = "Андрей Шибирёв";

                int[] grades = { 5, 4, 5 };

                int sum = 0;
                for (int i = 0; i < grades.Length; i++)
                {
                    sum += grades[i];
                }

                double average = sum / (double)grades.Length;

                Console.WriteLine($"№{number} | {group} | {fio} | Оценки: {grades[0]}, {grades[1]}, {grades[2]} | Среднее: {average:F2}");
            }
            //---------------------------------------------
            {
                /*
                StudentRecord student;

                student.Number = 1;
                student.Group = "П-1-24";
                student.FullName = "Андрей Шибирёв";
                student.Grades = new int[] { 5, 4, 5 };

                int sum = 0;
                for (int i = 0; i < student.Grades.Length; i++)
                {
                    sum += student.Grades[i];
                }

                double average = sum / (double)student.Grades.Length;

                Console.WriteLine($"№{student.Number} | {student.Group} | {student.FullName} | Среднее: {average:F2}");
            }
            //---------------------------------------------
            {
                /*
                StudentRecord[] students = new StudentRecord[3];

                students[0].Number = 1;
                students[0].Group = "П-1-24";
                students[0].FullName = "Андрей Шибирёв";
                students[0].Grades = new int[] { 5, 4, 5 };

                students[1].Number = 2;
                students[1].Group = "П-1-24";
                students[1].FullName = "Екатерина Мешкова";
                students[1].Grades = new int[] { 4, 4, 5 };
                

                students[2].Number = 3;
                students[2].Group = "Т-1-24";
                students[2].FullName = "Елизавета Парамонова";
                students[2].Grades = new int[] { 5, 5, 5 };

                for (int i = 0; i < students.Length; i++)
                {
                    int sum = 0;

                    for (int j = 0; j < students[i].Grades.Length; j++)
                    {
                        sum += students[i].Grades[j];
                    }

                    double average = sum / (double)students[i].Grades.Length;

                    Console.WriteLine($"№{students[i].Number} | {students[i].Group} | {students[i].FullName} | Среднее: {average:F2}");
                }
            }
            //---------------------------------------------
            {
                /*
                StudentRecord student;

                student.Number = 1;
                student.Group = "П-1-24";
                student.FullName = "Андрей Шибирёв";
                student.Grades = new int[] { 5, 4, 5 };
                double avg = student.GetAverage();

                //Console.WriteLine(avg);
                student.Print();
            }
            //---------------------------------------------
            {
                /*
                StudentRecord[] students = new StudentRecord[4];

                students[0] = new StudentRecord
                {
                    Number = 1,
                    Group = "П-1-24",
                    FullName = "Андрей Шибирёв",
                    Grades = new int[] { 5, 4, 5 }
                };

                students[1] = new StudentRecord
                {
                    Number = 2,
                    Group = "П-1-24",
                    FullName = "Екатерина Мешкова",
                    Grades = new int[] { 4, 4, 5 }
                };

                students[2] = new StudentRecord
                {
                    Number = 3,
                    Group = "Т-1-24",
                    FullName = "Елизавета Парамонова",
                    Grades = new int[] { 5, 5, 5 }
                };

                students[3] = new StudentRecord
                {
                    Number = 4,
                    Group = "Т-1-24",
                    FullName = "Анастасия Никонова",
                    Grades = new int[] { 4, 5, 4 }
                };

                for (int i = 0; i < students.Length; i++)
                {
                    students[i].Print();
                }
            }
            //---------------------------------------------
            {
                /*
                StudentRecord[] students = new StudentRecord[2];

                students[0] = new StudentRecord
                {
                    Number = 1,
                    Group = "П-1-24",
                    FullName = "Андрей Шибирёв",
                    Grades = new int[] { 5, 4, 5 }
                };

                students[1] = new StudentRecord
                {
                    Number = 2,
                    Group = "П-1-24",
                    FullName = "Екатерина Мешкова",
                    Grades = new int[] { 4, 4, 5 }
                };

                RenameStudent(students[0]);
               
                students[0].Print();
                */
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        class Student
        {
            public int Number;
            public string Group;
            public string FullName;
            private int[] grades;

            // Конструктор
            public Student(int number, string group, string fullName, int[] grades)
            {
                Number = number;
                Group = group;
                FullName = fullName;
                this.grades = grades; // this — это ссылка на текущий создаваемый объект.
            }


            // Метод подсчёта среднего
            public double GetAverage()
            {
                int sum = 0;
                for (int i = 0; i < grades.Length; i++)
                {
                    sum += grades[i];
                }

                return sum / (double)grades.Length;
            }

            // Метод вывода
            public void Print()
            {
                Console.WriteLine(
                    $"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}"//f2 нужен чтобы указать, сколько в дроби будет писаться символов после запятой
                );
            }
        }

        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student(1, "П-1-24", "Андрей Шимбирёв", new int[] { 5, 4, 5 }),
                new Student(2, "П-1-24", "Екатерина Мешкова", new int[] { 4, 4, 5 }),
                new Student(3, "Т-1-24", "Елизавета Парамонова", new int[] { 5, 5, 5 }),
                new Student(4, "Т-1-24", "Анастасия Никонова", new int[] { 4, 5, 4 })
            };

            Console.WriteLine("УЧЕБНЫЙ ЖУРНАЛ\n");

            foreach (Student s in students)
            {
                s.Print();
            }
        }
    }
}
