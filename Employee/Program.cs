using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{


    class Program
    {
        #region First
        /*ДЗ
        struct Employee
        {

            public int Wage { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string Job { get; set; }
            public DateTime GotTheJob { get; set; }
            public string Gender { get; set; }

            public override string ToString()
            {
                return string.Format("\nСотрудника зовут: {0} {1}\nЕго зарплата составляет: {2} тенге\nЕго должность: {3}\nПринят на работу: {4}\nПол: {5}" ,FirstName, SecondName, Wage, Job, GotTheJob, Gender);
            }

            public static void OneJobOnly(string Job, List<Employee> employees)
            {
                foreach (var item in employees)
                {
                    if(item.Job == Job)
                        Console.WriteLine(item);
                }
            }

            public static void ManagerSearch(string Job, List<Employee> employees)
            {
                int averageWage = 0;
                int cnt = 0;
                foreach (var item in employees)
                {
                    if (item.Job == "Клерк")
                    {
                        averageWage += item.Wage;
                        cnt++;
                    }
                }
                averageWage /= cnt;

                foreach (Employee item in employees)
                {
                    if(item.Job == Job && item.Wage > averageWage)
                        Console.WriteLine(item);
                }
            }

            public static void SortBySecondName(List<Employee> employees)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    for (int j = 1; j < employees.Count; j++)
                    {
                        if(employees[j].SecondName[0] < employees[j-1].SecondName[0])
                        {
                            Employee newEmployee = employees[j];
                            employees[j] = employees[j-1];
                            employees[j-1] = newEmployee;

                        }
                    }
                }
            }

            public static void SortByGender(List<Employee> employees, string Gender)
            {
                bool isFind = false;
                foreach (Employee item in employees)
                {
                    if (item.Gender == Gender)
                    {
                        Console.WriteLine(item);
                        isFind = true;
                    }
                }

                if(isFind == false)
                    Console.WriteLine("Сотрудников подобного пола у нас нет.");
            }

        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Задайте размер массива: ");
            int size = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            int cnt = 0;

            Console.WriteLine("<-- ЗАПОЛНЕНИЕ МАССИВА -->");
            while (cnt < size)
            {
                Employee employee = new Employee();
                Console.WriteLine("1. Имя и Фамилия");
                employee.FirstName = Console.ReadLine();
                employee.SecondName = Console.ReadLine();
                Console.WriteLine("2. Должность");
                employee.Job = Console.ReadLine();
                Console.WriteLine("3. Заработная плата");
                employee.Wage = int.Parse(Console.ReadLine());
                employee.GotTheJob = DateTime.Now.AddDays(-rnd.Next(1000));
                Console.WriteLine("4. Введите пол сотрудника: ");
                employee.Gender = Console.ReadLine();
                employees.Add(employee);
                cnt++;
            }

            //Employee.ManagerSearch("Менеджер", employees);
            Employee.SortBySecondName(employees);

            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nХотите ли увидеть сотрудников определенного пола?\n1. Да\n2. Нет\n");

            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        Console.WriteLine("\nВведите пол, по которому хотите отсортировать список: ");
                        string input = Console.ReadLine();
                        Employee.SortByGender(employees, input);
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        */
        #endregion

        enum Gender : int
        {
            male = 1,
            female,
            покемон,
            McDonnellDouglasAH64Apache
        }
        enum Forms
        {
            Очное = 1,
            Заочное,
            Онлайн
        }
        enum Relative
        {
            Брат = 1,
            Сестра,
            Мать,
            Отец
        }

        struct Family
        {
            public Relative Relative { get; set; }
            public int RelativesIncome { get; set; }
            public string FullName { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {

                return string.Format("<<< Член семьи >>>\n1. Кем приходится: " +
                    "{0}\n2. Доход: {1}\n3. Полное имя: {2}\n" +
                    "4. Возраст: {3}\n"
                    ,Relative, RelativesIncome, FullName, Age);
            }
        }

        private struct Rates
        {
            public double Math { get; set; }
            public double Physics { get; set; }
            public double English { get; set; }
            public double Average { get; set; }
        }

        struct Student
        {
            public string FullName { get; set; }
            public string Class { get; set; }
            public Rates Rates { get; set; }
            public List<Family> Family { get; set; }
            public Forms FormOfEducation { get; set; }
            public Gender Gen { get; set; }

            public static void ShowStudents(List<Student> students)
            {
                
                foreach (Student item in students)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine(item);
                    foreach (Family rel in item.Family)
                    {
                        Console.WriteLine(rel);
                    }
                    Console.WriteLine("----------------------------------");
                }
                
            }

            public override string ToString()
            {
                return string.Format(
                    "\n1. Полное имя: {0}\n" +
                    "2. Группа: {1}\n" +
                    "3. Оценки: \n\tМатематика: {2}\n\tФизика: {3}\n\tАнглийский: {4}\n" +
                    "\tСредний балл: {5}\n" +
                    "4. Форма обучения: {6}\n5. Пол: {7}\n", FullName, Class, 
                    Rates.Math,Rates.Physics,Rates.English, Rates.Average, FormOfEducation, Gen);
            }
        }
        struct Community
        {
            public List<Student> Students { get; set; }

            private List<Student> SortByRates(List<Student> students)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    for (int j = 1; j < students.Count; j++)
                    {
                        if(students[j - 1].Rates.Average < 75)
                        {
                            students.RemoveAt(j - 1);
                        }
                        if (students[j].Rates.Average < students[j - 1].Rates.Average)
                        {
                            Student newStudent = students[j];
                            students[j] = students[j - 1];
                            students[j - 1] = newStudent;

                        }
                    }
                }

                return students;
            }

            public static void ShowStudents(List<Student> Students)
            {
                foreach (Student item in Students)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine(item);
                    foreach (Family rel in item.Family)
                    {
                        Console.WriteLine(rel);
                    }
                    Console.WriteLine("----------------------------------");
                }

            }

            public void AddStudent(List<Student> students, Community community)
            {
                foreach (Student student in students)
                {
                    int averageIncome = 0;
                    foreach (Family Relative in student.Family)
                    {
                        averageIncome += Relative.RelativesIncome;
                    }

                    averageIncome /= student.Family.Count;

                    if (averageIncome < 85000)
                    {
                        community.Students.Add(student);
                        students.Remove(student);
                    }

                    //else if (averageIncome >= 85000)
                        //SortByRates(students);
                    //community.Students.Add(student);
                }

                Console.WriteLine("Отбор прошли эти студенты: ");
                Community.ShowStudents(community.Students);
            }

        }

        interface IChangeStructValue { void Change(int i, int j); }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Community community = new Community();
            Random rnd = new Random();

            Console.WriteLine("Сколько студентов вы хотите добавить в список на получение общежития?");
            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Student student = new Student();
                student.Family = new List<Family>();
                int localNum = rnd.Next(40, 100);
                int Gen = rnd.Next(1,10);
                int formGen = rnd.Next(1,3);

                student.FullName = string.Format("FullName_{0}", rnd.Next(1,100));
                student.Class = string.Format("Class_{0}", rnd.Next(1, 10));
                switch (Gen)
                {
                    case 1:
                        {
                            student.Gen = Gender.female;
                        }
                        break;
                    case 2:
                        {
                            student.Gen = Gender.male;
                        }
                        break;
                    case 3:
                        {
                            student.Gen = Gender.McDonnellDouglasAH64Apache;
                        }
                        break;
                    case 4:
                        {
                            student.Gen = Gender.покемон;
                        }
                        break;
                    default:
                        break;
                }
                switch (formGen)
                {
                    case 1:
                        {
                            student.FormOfEducation = Forms.Онлайн;
                        }
                        break;
                    case 2:
                        {
                            student.FormOfEducation = Forms.Очное;
                        }
                        break;
                    case 3:
                        {
                            student.FormOfEducation = Forms.Заочное;
                        }
                        break;
                    default:
                        break;
                }
                List<int> badNum = new List<int>();
                for (int j = 0; j < Gen; j++)
                {
                    Family person = new Family();
                    int relativeGen = rnd.Next(1, 4);
                    if (!badNum.Contains(relativeGen))
                    {
                        switch (relativeGen)
                        {
                            case 1:
                                {
                                    person.Relative = Relative.Брат;
                                    person.RelativesIncome = rnd.Next(20000, 80000);
                                    person.Age = rnd.Next(18, 23);
                                    person.FullName = string.Format("FullName_{0}", rnd.Next(1, 100));
                                }
                                break;
                            case 2:
                                {
                                    person.Relative = Relative.Мать;
                                    person.RelativesIncome = rnd.Next(200000, 400000);
                                    person.Age = rnd.Next(50, 70);
                                    person.FullName = string.Format("FullName_{0}", rnd.Next(1, 100));
                                }
                                break;
                            case 3:
                                {
                                    person.Relative = Relative.Отец;
                                    person.RelativesIncome = rnd.Next(200000, 400000);
                                    person.Age = rnd.Next(50, 70);
                                    person.FullName = string.Format("FullName_{0}", rnd.Next(1, 100));
                                }
                                break;
                            case 4:
                                {
                                    person.Relative = Relative.Сестра;
                                    person.RelativesIncome = rnd.Next(20000, 80000);
                                    person.Age = rnd.Next(18, 23);
                                    person.FullName = string.Format("FullName_{0}", rnd.Next(1, 100));
                                }
                                break;
                            default:
                                break;
                        }
                        badNum.Add(relativeGen);
                        student.Family.Add(person);
                    }
                }
                
                students.Add(student);
            }

            Student.ShowStudents(students);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            community.AddStudent(students, community);
        }
    }
}
