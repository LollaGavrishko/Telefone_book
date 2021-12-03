using System;
using System.Collections.Generic;
using System.Linq;

namespace Telefone_book
{

    public class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string[] Addresses { get; set; }
        public string Note {get; set; }
    }
    class Program
    {
        
        public static List<Person> People = new List<Person>();
        static void Main()
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                Console.WriteLine("*-*-*-*-* Телефонная книжка *-*-*-*-*");
                Console.WriteLine("Введите команду: add, remove, search, edit, list: ");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "add":
                        AddPerson();
                        break;
                    case "remove":
                        RemovePerson();
                        break;
                    case "list":
                        ListPeople();
                        break;
                    case "search":
                        SearchPerson();
                        break;
                    case "edit":
                        EditPerson();
                        break;
                    default:
                       
                        if (command != "")
                        {
                            DisplayHelp();
                        }
                        break;
                }
            }
        }
       

        private static void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("Команда не найдена. Выберите из списка:");
            Console.WriteLine("add\tДобавить человека в телефонную книжку");
            Console.WriteLine("remove\tУдалить человека из электронной книжки");
            Console.WriteLine("list\tВывести всех людей из телефонной книжки");
            Console.WriteLine("search\tНайти человека");
            Console.WriteLine("edit\tРедактировать человека");
            Console.WriteLine("\nНажмите чтобы продолжить");
            Console.ReadKey();
        }


        private static void AddPerson()
        {
            Console.Clear();

            Person person = new Person();

            Console.Write("Имя: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Фамилия: ");
            person.LastName = Console.ReadLine();

            Console.Write("Отчество(не обязательно для заполнения): ");
            person.SecondName = Console.ReadLine();

            Console.Write("Номер телефона: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Write("Страна: ");
            person.Country = Console.ReadLine();

            Console.Write("Дата рождения(не обязательно для заполнения): ");
            person.DateOfBirth = Console.ReadLine();


            Console.Write("Организация(не обязательно для заполнения): ");
            string[] addresses = new string[2];
            addresses[0] = Console.ReadLine();
            Console.Write("Должность(не обязательно для заполнения): ");
            addresses[1] = Console.ReadLine();
            person.Addresses = addresses;
            Console.Write("Заметки(не обязательно для заполнения): ");
            person.Note = Console.ReadLine();

            People.Add(person);
        }

        private static void RemovePerson()
        {
            List<Person> people = FindPeopleByFirstName();

            Console.Clear();

            if (people.Count == 0)
            {
                Console.WriteLine("Человек не найден");
                Console.ReadKey();
                return;
            }

            if (people.Count == 1)
            {
                RemovePersonFromList(people.Single());
                return;
            }

            Console.WriteLine("Введите номер человека для удаления:");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(i);
                PrintPerson(people.ElementAt(i));
            }
            int removePersonNumber = Convert.ToInt32(Console.ReadLine());
            if (removePersonNumber > people.Count - 1 || removePersonNumber < 0)
            {
                Console.WriteLine("Неверный номер");
                Console.ReadKey();
                return;
            }
            RemovePersonFromList(people.ElementAt(removePersonNumber));
        }

        
        private static void RemovePersonFromList(Person person)
        {
            Console.Clear();
            Console.WriteLine("Хотите стереть человека из телефонной книжки и своего сердца? (Y/N):");
            PrintPerson(person);

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                People.Remove(person);
                Console.Clear();
                Console.WriteLine("Удалили и удалили, чего бубнить то...");
                Console.ReadKey();
            }
        }
        private static void EditPerson()
        {
           string newInfo;
            List<Person> people = FindPeopleByFirstName();
			string[] addresses = new string[2];
            Console.Clear();

            if (people.Count == 0)
            {
                Console.WriteLine("Человек не найден");
                Console.ReadKey();
                return;
           
            }
            else
            {
                Console.WriteLine("Задайте новые данные:");
                Console.WriteLine("Фамилия:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                  string LastName = newInfo;
                }
                Console.WriteLine("Имя");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    string FirstName = newInfo;
                }
                Console.WriteLine("Отчество:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    string LastName = newInfo;
                }
                Console.WriteLine("Номер телефона:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    try
                    {
                        string PhoneNumber = newInfo;
                    }
                    catch
                    {
                        Console.WriteLine("Заданный номер телефона не соответствует формату");
                    }
                }
                Console.WriteLine("Страна:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    string Country = newInfo;
                }
                Console.WriteLine("Дата рождения:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                   string DateOfBirth = newInfo;
                }
                Console.WriteLine("Организация:");
                newInfo = Console.ReadLine();
				
                if (newInfo != "")
                {
                   string Addresses = newInfo;
                }
                Console.WriteLine("Должность:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                   string Addresses = newInfo;
                }
                Console.WriteLine("Заметки:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    string Note = newInfo;
                }
                Console.WriteLine("Запись изменена.\n");
                Console.ReadLine();
            }
        }
        private static void SearchPerson()
        {
            List<Person> people = FindPeopleByFirstName();
            Console.Clear();
            if (people.Count == 0)
            {
                Console.WriteLine("Такого человека нет");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Люди соответсвующие параметру поиска:\n");
            foreach (var person in people)
            {
                PrintPerson(person);
            }
            Console.WriteLine("\nНажмите для продолжения");
            Console.ReadKey();
        }

        private static List<Person> FindPeopleByFirstName()
        {
            Console.Clear();
            Console.WriteLine("Введите имя для поиска:");
            string firstName = Console.ReadLine();
            return People.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToList();
        }

        private static void ListPeople()
        {
            Console.Clear();
            if (People.Count == 0)
            {
                Console.WriteLine("Телефонная книжка пуста");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Все люди в твоей телефонной книжке:\n");
            foreach (var person in People)
            {
                PrintPeople(person);
            }
            Console.WriteLine("\nНажмите для продолжения");
            Console.ReadKey();
        }
        private static void PrintPeople(Person person)
        {
            Console.WriteLine("Имя: " + person.FirstName);
            Console.WriteLine("Фамилия: " + person.LastName);
            Console.WriteLine("Номер телефона: " + person.PhoneNumber);
            Console.WriteLine("-------------------------------------------");
        }

        private static void PrintPerson(Person person)
        {
            Console.WriteLine("Имя: " + person.FirstName);
            Console.WriteLine("Фамилия: " + person.LastName);
            Console.WriteLine("Отчество: " + person.SecondName);
            Console.WriteLine("Номер телефона: " + person.PhoneNumber);
            Console.WriteLine("Страна: " + person.Country); 
            Console.WriteLine("Дата рождения: " + person.DateOfBirth);
            Console.WriteLine("Организация: " + person.Addresses[0]);
            Console.WriteLine("Должность: " + person.Addresses[1]);
            Console.WriteLine("Заметки: " + person.Note);
            Console.WriteLine("-------------------------------------------");
        }
   
    }

}


