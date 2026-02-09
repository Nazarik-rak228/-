// короче, от модификаторов доступа зависит, можно будет обращаться к обьекту класса только в нем, или везде, или в нем и его подклассах
///
//
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        class Student
        {
            public int Number;
            // public — это или всё разрешено, или ничего
        }
        class Student2
        {
            private int number;

            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    if (value < 0)
                        return;

                    number = value;
                }
            }
        }

        static void Main(string[] args)
        {
            {
                Student s = new Student();
                s.Number = 10;    // записали в поле / set(10);
                int x = s.Number; // прочитали поле  / x = get();

                Console.WriteLine(x);
            }

            {
                Student2 s = new Student2();

                Console.WriteLine("После создания объекта:");
                Console.WriteLine(s.Number); // get → 0

                s.Number = 10;               // set(10)
                Console.WriteLine("После s.Number = 10:");
                Console.WriteLine(s.Number); // get → 10

                s.Number = -100;             // set(-100) → return
                Console.WriteLine("После s.Number = -100:");
                Console.WriteLine(s.Number); // get → 10 (НЕ ИЗМЕНИЛОСЬ)
            }
        }
    }
}


/ ----------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        class StudentPublic
        {
            public int Number;
            public string Group;
            public string FullName;
            public int[] Grades; // В public = можно лезть куда угодно!  

            public StudentPublic(int number, string group, string fullName, int[] grades)
            {
                Number = number;
                Group = group;
                FullName = fullName;
                Grades = grades;
            }

            public double GetAverage()
            {
                int sum = 0;
                for (int i = 0; i < Grades.Length; i++)
                {
                    sum += Grades[i];
                }
                return sum / (double)Grades.Length;
            }

            public void Print()
            {
                Console.WriteLine(
                    $"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}"
                );
            }
        }


        static void Test1_PublicIsDangerous()
        {
            StudentPublic student = new StudentPublic(
                1,
                "П-1-24",
                "Андрей Шимбирёв",
                new int[] { 5, 4, 5 }
            );

            // Так как Grades — public, МЫ МОЖЕМ ИЗМЕНИТЬ ИХ СНАРУЖИ.

            student.Grades[0] = 999; // тупая оценка
            student.FullName = "";   // пустое имя
            student.Print();
        }


        class StudentPrivate
        {

            // private означает:
            // - доступ ТОЛЬКО внутри этого класса
            // - снаружи ЛЕЗТЬ ЗАПРЕЩЕНО

            public int Number;
            public string Group;
            public string FullName;
            private int[] Grades;

            public StudentPrivate(int number, string group, string fullName, int[] grades)
            {
                Number = number;
                Group = group;
                FullName = fullName;
                Grades = grades;
            }

            public double GetAverage()
            {
                int sum = 0;
                for (int i = 0; i < Grades.Length; i++)
                {
                    sum += Grades[i];
                }
                return sum / (double)Grades.Length;
            }

            public void Print()
            {
                Console.WriteLine(
                    $"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}"
                );
            }
        }

        static void Test2_PrivateAccess()
        {
            StudentPrivate student = new StudentPrivate(
                1,
                "П-1-24",
                "Андрей Шимбирёв",
                new int[] { 5, 4, 5 }
            );

            // student.Grades[0] = 999;
            student.Print();
        }


        class StudentRightPrublic
        {
            public int Number;
            public string Group;
            public string FullName;

            private int[] Grades;

            public StudentRightPrublic(int number, string group, string fullName)
            {
                Number = number;
                Group = group;
                FullName = fullName;
                Grades = new int[0];
            }

            public void AddGrade(int grade)
            {
                if (grade < 2 || grade > 5)
                    return;

                int[] newGrades = new int[Grades.Length + 1];

                for (int i = 0; i < Grades.Length; i++)
                    newGrades[i] = Grades[i];

                newGrades[newGrades.Length - 1] = grade;
                Grades = newGrades;
            }

            public double GetAverage()
            {
                if (Grades.Length == 0)
                    return 0;

                int sum = 0;
                for (int i = 0; i < Grades.Length; i++)
                    sum += Grades[i];

                return sum / (double)Grades.Length;
            }

            public void Print()
            {
                Console.WriteLine(
                    $"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}"
                );
            }
        }

        static void Test3_GoodDecision()
        {
            StudentRightPrublic student =
                new StudentRightPrublic(1, "П-1-24", "Андрей Шимбирёв");

            student.AddGrade(5);
            student.AddGrade(4);
            student.AddGrade(999); // проигнорируется

            student.Print();
        }

        static void Test4_PublicStillDangerous()
        {
            StudentRightPrublic student =
                new StudentRightPrublic(1, "П-1-24", "Андрей Шимбирёв");

            // ЭТО ВСЁ РАЗРЕШЕНО КОМПИЛЯТОРОМ
            student.FullName = "";
            student.Group = null;
            student.Number = -100;

            student.AddGrade(5);
            student.AddGrade(4);

            student.Print();
        }

        class StudentWithProperties
        {
            // ПОЛЯ ТЕПЕРЬ private
            private int number;
            private string group;
            private string fullName;

            private int[] Grades;

            public StudentWithProperties(int number, string group, string fullName)
            {
                this.number = number;
                this.group = group;
                this.fullName = fullName;
                Grades = new int[0];
            }

            public int Number
            {
                get { return number; }
            }

            public string Group
            {
                get { return group; }
            }

            public string FullName
            {
                get { return fullName; }
            }

            public void Rename(string newName)
            {
                if (string.IsNullOrWhiteSpace(newName))
                    return;

                fullName = newName;
            }

            public void ChangeGroup(string newGroup)
            {
                if (string.IsNullOrWhiteSpace(newGroup))
                    return;

                group = newGroup;
            }

            public void AddGrade(int grade)
            {
                if (grade < 2 || grade > 5)
                    return;

                int[] newGrades = new int[Grades.Length + 1];

                for (int i = 0; i < Grades.Length; i++)
                    newGrades[i] = Grades[i];

                newGrades[newGrades.Length - 1] = grade;
                Grades = newGrades;
            }

            public double GetAverage()
            {
                if (Grades.Length == 0)
                    return 0;

                int sum = 0;
                for (int i = 0; i < Grades.Length; i++)
                    sum += Grades[i];

                return sum / (double)Grades.Length;
            }

            public void Print()
            {
                Console.WriteLine(
                    $"№{Number} | {Group} | {FullName} | Среднее: {GetAverage():F2}"
                );
            }
        }

        static void Test5_PropertiesWork()
        {
            StudentWithProperties student =
                new StudentWithProperties(1, "П-1-24", "Андрей Шимбирёв");

            // ЭТО НЕ СКОМПИЛИРУЕТСЯ
            // student.FullName = "";
            // student.Group = null;
            // student.Number = -100;

            // ВОТ ТАК МОЖНО
            student.Rename("Иванов Иван");
            student.ChangeGroup("Т-1-24");

            student.AddGrade(5);
            student.AddGrade(4);
            student.AddGrade(999);

            student.Print();
        }

        static void Main(string[] args)
        {
            Test1_PublicIsDangerous();
            Test2_PrivateAccess();
            Test3_GoodDecision();

            Test4_PublicStillDangerous();
            Test5_PropertiesWork();
        }
    }
}