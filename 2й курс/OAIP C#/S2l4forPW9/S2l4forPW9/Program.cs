using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        // Исключение — это НЕ ошибка программы
        // throw — это команда: Стоп. Дальше работать нельзя
        // ArgumentException означает: Мне передали аргумент, но он неправильный
        // ArgumentNullException означает: Мне передали null, а null здесь запрещён
        // InvalidOperationException: Данные нормальные, но сейчас так делать нельзя
        // NotSupportedException означает: Эта операция запрещена по дизайну, мы просто так не делаем и делать не будем
        class User
        {
            public string Login { get; }
            public string Password { get; }

            public User(string login, string password)
            {
                // Используем, когда аргумент == null. То есть его вообще не передали
                if (login == null)
                    throw new ArgumentNullException(
                        nameof(login),
                        "Логин не может быть null"
                    );

                //  Аргумент есть, но его значение неправильное
                if (login == "")
                    throw new ArgumentException(
                        "Логин не может быть пустым"
                    );

                if (password == null)
                    throw new ArgumentNullException(
                        nameof(password),
                        "Пароль не может быть null"
                    );

                if (password.Length < 6)
                    throw new ArgumentException(
                        "Пароль должен быть минимум 6 символов"
                    );

                Login = login;
                Password = password;
            }

            public void ChangePassword(string newPassword)
            {
                // Используем, когда данные вроде нормальные,но действие сейчас выполнять нельзя
                if (newPassword == Password)
                    throw new InvalidOperationException(
                        "Новый пароль совпадает со старым"
                    );

                if (newPassword.Length < 6)
                    throw new ArgumentException(
                        "Пароль слишком короткий"
                    );

                // В реальном коде тут было бы присваивание
                Console.WriteLine("Пароль успешно изменён");
            }

            public void LoginViaOldSystem()
            {
                //  Используем, когда операция запрещена по дизайну (читайте выше)
                throw new NotSupportedException(
                    "Вход через старую систему больше не поддерживается"
                );
            }
        }

        static void Test_UserExceptions()
        {
            Console.WriteLine("РАБОТА С ПОЛЬЗОВАТЕЛЕМ");
            try
            {
                // Мы описали, что не менее 6 символов
                User user = new User("admin", "123");

                // Эта строка НЕ выполнится, т.к. выше будет throw
                Console.WriteLine("Пользователь создан");

                user.ChangePassword("123456");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ПРОБЛЕМА: передали null");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ПРОБЛЕМА: неверные данные");
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("ПРОБЛЕМА: операция запрещена сейчас");
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("ПРОБЛЕМА: функция не поддерживается");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // На всякий случай. Ловит всё остальное
                Console.WriteLine("Неизвестная ошибка");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Test_UserExceptions();
            Console.ReadKey();
        }
    }
}


///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        //  Инкапсуляция — это ситация, когда объект отвечает за корректность своих данных и не даёт внешнему коду их ломать.
        //  Внешний код не должен портить объект. Объект сам решает, что с ним можно делать
        //  Это класс без инкапсуляции
        class StudentWithoutEncapsulation
        {
            // Любой код может:
            // - писать что угодно
            // - в любом порядке
            // - в любое время

            public int Number;
            public string FullName;
            public int Age;
        }

        static void Test1_NoEncapsulation()
        {
            StudentWithoutEncapsulation student =
                new StudentWithoutEncapsulation();

            student.Number = -100;
            student.FullName = "";
            student.Age = -5;

            Console.WriteLine(
                $"Number={student.Number}, Name='{student.FullName}', Age={student.Age}"
            );

            Console.WriteLine();
        }

        // Это первый шаг к инкапсуляции — private
        class StudentWithPrivateFields
        {
            //  private означает:
            //  - доступ ТОЛЬКО внутри этого класса
            //  - снаружи НИКТО не может напрямую писать

            private int number;
            private string fullName;
            private int age;

            public void SetData(int number, string fullName, int age)
            {
                // Первый момент инкапсуляции:
                // Теперь все изменения идут
                // Только через метод класса.

                if (number <= 0)
                    return;

                if (string.IsNullOrWhiteSpace(fullName))
                    return;

                if (age <= 0)
                    return;

                // Только если всё корректно — объект принимает данные
                this.number = number;
                this.fullName = fullName;
                this.age = age;
            }

            public void Print()
            {
                Console.WriteLine(
                    $"Number={number}, Name='{fullName}', Age={age}"
                );
            }
        }

        static void Test2_PrivateFields()
        {
            StudentWithPrivateFields student =
                new StudentWithPrivateFields();

            // student.number = -100;   не скомпилируется, т.к. не возможно!!

            student.SetData(-100, "", -5); // получаем игнор!
            student.Print();

            student.SetData(1, "Андрей", 20);
            student.Print();

            Console.WriteLine();
        }



        // Свойства — это правильный способ инкапсуляции
        class StudentWithProperties
        {
            // Поля — private
            // Доступ — через свойства

            private int number;
            private string fullName;
            private int age;

            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    if (value <= 0)
                        return;

                    number = value;
                }
            }

            public string FullName
            {
                get
                {
                    return fullName;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        return;
                    fullName = value;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    if (value <= 0)
                        return;
                    age = value;
                }
            }
            public void Print()
            {
                Console.WriteLine(
                    $"Number={Number}, Name='{FullName}', Age={Age}"
                );
            }
        }

        static void Test3_Properties()
        {
            StudentWithProperties student =
                new StudentWithProperties();

            // Это выглядит как поле, но на самом деле это вызов set
            student.Number = -100;   // проигнорируется
            student.FullName = "";   // проигнорируется
            student.Age = -5;        // проигнорируется

            student.Print();         // всё ещё значения по умолчанию

            student.Number = 1;
            student.FullName = "Андрей";
            student.Age = 20;

            student.Print();

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Test1_NoEncapsulation();
            Test2_PrivateFields();
            Test3_Properties();

            Console.ReadKey();
        }
    }
}

/*get без set - это read-only, то есть толшько чтение

private set - это менять можно, но только внутри

read-only - данные один раз и навсегда

read-only — это усиление инкапсуляции*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        //  У нас есть разные типы людей:
        //  - студент
        //  - преподаватель
        //  У них разная роль, но есть общие поля:
        //  - имя
        //  - возраст

        // Пример 2 независимых классов
        class Student_NoInheritance
        {
            public string FullName;
            public int Age;
            public string Group;

            public void Print()
            {
                Console.WriteLine(
                  $"Студент: {FullName}, возраст {Age}, группа {Group}"
                );
            }
        }

        class Teacher_NoInheritance
        {
            public string FullName;
            public int Age;
            public string Subject;

            public void Print()
            {
                Console.WriteLine(
                  $"Преподаватель: {FullName}, возраст {Age}, предмет {Subject}"
                );
            }
        }
        //  1) Дублирование полей FullName, Age
        //  2) Если меняется логика имени — надо править везде
        //  3) Код разъезжается и ломается

        // Наследование - это хороший подход

        //    Person — это базовый класс
        //    Он описывает то, что общее для всех людей
        //    - Person сам по себе не "студент"
        //    - это общая модель

        class Person
        {
            //   protected мы используем впервые
            //   protected означает:
            //   - снаружи класса доступа нет
            //   - но у наследников доступ есть
            protected string fullName;
            protected int age;

            public Person(string fullName, int age)
            {
                if (string.IsNullOrWhiteSpace(fullName))
                    throw new ArgumentException("Имя не может быть пустым");

                if (age <= 0)
                    throw new ArgumentException("Возраст должен быть > 0");

                this.fullName = fullName;
                this.age = age;
            }

            // Общий метод
            public void PrintBase()
            {
                Console.WriteLine($"Имя: {fullName}, возраст {age}");
            }
        }


        // Student наследует Person.
        // Читается так: Student является Person

        class Student : Person
        {
            public string Group { get; }

            // : base(...) — вызов конструктора базового класса
            //  Сначала создаётся Person, потом Student.

            public Student(string fullName, int age, string group)
        : base(fullName, age)
            {
                if (string.IsNullOrWhiteSpace(group))
                    throw new ArgumentException("Группа не может быть пустой");

                Group = group;
            }

            public void Print()
            {
                Console.WriteLine(
                  $"Студент: {fullName}, возраст {age}, группа {Group}"
                );
            }
        }

        // Teacher тоже наследует Person.
        // Это другой тип, но с той же базой.

        class Teacher : Person
        {
            public string Subject { get; }

            public Teacher(string fullName, int age, string subject)
              : base(fullName, age)
            {
                if (string.IsNullOrWhiteSpace(subject))
                    throw new ArgumentException("Предмет не может быть пустым");

                Subject = subject;
            }

            public void Print()
            {
                Console.WriteLine(
                  $"Преподаватель: {fullName}, возраст {age}, предмет {Subject}"
                );
            }
        }

        // Проверка, что дает наследование
        static void Test_Inheritance()
        {
            Console.WriteLine("НАСЛЕДОВАНИЕ — ОДИН БАЗОВЫЙ КЛАСС");

            Student student =
              new Student("Андрей Шимбирёв", 20, "П-1-24");

            Teacher teacher =
              new Teacher("Иван Иванов", 45, "Математика");

            student.Print();
            teacher.Print();

            Console.WriteLine();
        }

        //  Student является Person
        //  Teacher тоже является Person
        static void Main(string[] args)
        {
            Test_Inheritance();
            Console.ReadKey();
        }
    }
} 