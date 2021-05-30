using System;
using System.Collections;
using System.Collections.Generic;

namespace Question1
{
    abstract class Person
    {
        public int idBook;
        public byte course;
        public string surname;

        public int IDBook { get { return idBook; } set { idBook = value; } }

        public byte Course { get { return course; } set { course = value; } }

        public string Surname { get { return surname; } set { surname = value; } }

        public Person(string Surname, byte Course, int IDBook)
        {
            surname = Surname;
            course = Course;
            idBook = IDBook;
        }

        public abstract void Print();
    }

    class Student : Person
    {
        public Student(string Surname, byte Course, int IdBook)
            : base(Surname, Course, IdBook)
        {

        }

        public override void Print()
        {
            Console.WriteLine($"Student: { Surname }, Course: { Course }, ID card: { IDBook }");
        }
    }

    class Aspirant : Person
    {
        private string desertation;

        public string Desertation { get { return desertation; } set { desertation = value; } }

        public Aspirant(string Surname, byte Course, int IdBook, string Desertation)
            : base(Surname, Course, IdBook)
        {
            desertation = Desertation;
        }

        public override void Print()
        {
            Console.WriteLine($"Aspirant: { Surname }, Desertation: { Desertation }, Course: { Course }, ID card: { IDBook }");
        }
    }

    class Program
    {
        public static bool checkerSurname;
        public static int counterStudent = 0;
        public static int counterAspirant = 0;

        static int NumberCheckerForInt()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        static int NumberCheckerForId()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    if (numberInString.Length == 5)
                    {
                        return number;
                    }
                    else
                    {
                        Console.Write("Incorrect, id card can be 5 digit number: ");
                    }
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        static byte NumberCheckerForByte()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    if (number > 6)
                    {
                        Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                    }
                    else if (number == 0)
                    {
                        Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                    }
                    else
                    {
                        return number;
                    }
                }

                else
                {
                    Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                }
            }
        }

        public static string SurnameChecker()
        {
            string surname;
            do
            {
                surname = Console.ReadLine();

                for (int i = 0; i < surname.Length; i++)
                {
                    char element = surname[i];

                    if (!Char.IsLetter(element))
                    {
                        checkerSurname = false;
                        Console.Write("Incorrect surname type, please enter correct surname: ");
                        break;
                    }
                    else
                    {
                        checkerSurname = true;
                    }
                }
            }
            while (checkerSurname == false);

            return surname;
        }

        static byte NumberCheckerForByte1OR2()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("Incorrect choice type 1 or 2: ");
                }
            }
        }

        public static void Read()
        {
            Console.Write("\nPress any button...");
            Console.ReadKey();
            Console.WriteLine("\n\n\n");
        }

        public static void Menu()
        {
            Console.WriteLine("\n1)Add student");
            Console.WriteLine("2)Add aspirant");
            Console.WriteLine("3)Display the number of students in ArrayList");
            Console.WriteLine("4)Display the number of aspirants in Arraylist");
            Console.WriteLine("5)Display the number of students in LinkedList");
            Console.WriteLine("6)Display the number of aspirants in LinkedList");
            Console.WriteLine("7)List all students in ArrayList");
            Console.WriteLine("8)List all aspirants in ArrayList");
            Console.WriteLine("9)List all students in LinkedList");
            Console.WriteLine("10)List all aspirants in LinkedList");
            Console.WriteLine("11)Delete index of student in ArrayList");
            Console.WriteLine("12)Delete index of aspirant in ArrayList");
            Console.WriteLine("13)Delete index of student in LinkedList");
            Console.WriteLine("14)Delete index of aspirant in LinkedList");
            Console.WriteLine("15)Exit");
            Console.Write("Your select: ");
        }

        static void Main(string[] args)
        {
            ArrayList ArrayListStudents = new ArrayList();
            ArrayList ArrayListAspirants = new ArrayList();

            LinkedList<Student> LinkedListStudents = new LinkedList<Student>();
            LinkedList<Aspirant> LinkedListAspirants = new LinkedList<Aspirant>();

            bool selectionForAll = false; // Ayaz klanus bes false ne rabotayet
            bool selectionForSwitch = false; // Ayaz klanus bes false ne rabotayet

            do
            {
                Menu();
                do
                {
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                Console.Write("\nSurname: ");
                                string surname = SurnameChecker();

                                Console.Write("Course: ");
                                byte course = NumberCheckerForByte();

                                Console.Write("ID card: ");
                                int idCard = NumberCheckerForId();


                                bool choiceForArrLinLists;
                                Console.Write("\nThis informmation about student for \n1)ArrayList \n2)LinkedList\nChoice: ");

                                do
                                {
                                    byte arrayLinkedChoice = NumberCheckerForByte1OR2();
                                    if (arrayLinkedChoice == 1)
                                    {
                                        ArrayListStudents.Add(new Student(surname, course, idCard));
                                        counterStudent++;
                                        choiceForArrLinLists = true;
                                    }
                                    else if (arrayLinkedChoice == 2)
                                    {
                                        LinkedListStudents.AddLast(new Student(surname, course, idCard));
                                        counterAspirant++;
                                        choiceForArrLinLists = true;
                                    }
                                    else
                                    {
                                        Console.Write("Enter 1 or 2: ");
                                        choiceForArrLinLists = false;
                                    }
                                } while (choiceForArrLinLists == false);

                                selectionForSwitch = true;
                                Read();
                                break;
                            }
                        case "2":
                            {
                                Console.Write("Desertation: ");
                                string desertation = Console.ReadLine();

                                Console.Write("Surname: ");
                                string surname = Console.ReadLine();

                                Console.Write("Course: ");
                                byte course = NumberCheckerForByte();

                                Console.Write("ID card: ");
                                int idCard = NumberCheckerForInt();

                                bool choiceForArrLinLists;
                                Console.Write("\nThis informmation about student for \n1)ArrayList \n2)LinkedList\nChoice: ");

                                do
                                {
                                    byte arrayLinkedChoice = NumberCheckerForByte1OR2();
                                    if (arrayLinkedChoice == 1)
                                    {
                                        ArrayListAspirants.Add(new Aspirant(surname, course, idCard, desertation));
                                        counterStudent++;
                                        choiceForArrLinLists = true;
                                    }
                                    else if (arrayLinkedChoice == 2)
                                    {
                                        LinkedListAspirants.AddLast(new Aspirant(surname, course, idCard, desertation));
                                        counterAspirant++;
                                        choiceForArrLinLists = true;
                                    }
                                    else
                                    {
                                        Console.Write("Enter 1 or 2: ");
                                        choiceForArrLinLists = false;
                                    }
                                } while (choiceForArrLinLists == false);

                                selectionForSwitch = true;
                                Read();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine($"Total students in ArrayList = { ArrayListStudents.Count }");

                                Read();
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine($"Total aspirant in ArrayList = { ArrayListAspirants.Count }");

                                Read();
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine($"Total students in LinkedList = { LinkedListStudents.Count }");

                                Read();
                                break;
                            }
                        case "6":
                            {
                                Console.WriteLine($"Total aspirants in LinkedList = { LinkedListAspirants.Count }");

                                Read();
                                break;
                            }
                        case "7":
                            {
                                foreach (Student studentList in ArrayListStudents)
                                {
                                    Console.Write($"\nInformation about student\n");
                                    studentList.Print();
                                }

                                Read();
                                break;
                            }
                        case "8":
                            {
                                foreach (Aspirant aspirantList in ArrayListAspirants)
                                {
                                    Console.Write($"\nInformation about aspirant\n");
                                    aspirantList.Print();
                                }

                                Read();
                                break;
                            }
                        case "9":
                            {
                                foreach (Student studentList in LinkedListStudents)
                                {
                                    Console.Write($"\nInformation about student\n");
                                    studentList.Print();
                                }

                                Read();
                                break;
                            }
                        case "10":
                            {
                                foreach (Aspirant aspirantList in LinkedListAspirants)
                                {
                                    Console.Write($"Information about aspirant: ");
                                    aspirantList.Print();
                                }

                                Read();
                                break;
                            }
                        case "11":
                            {
                                bool checker;
                                if (counterStudent > 0)
                                {
                                    do
                                    {
                                        Console.Write("Enter index which student you want to delete: ");
                                        int indexStuDel = NumberCheckerForInt();

                                        if (indexStuDel >= counterStudent)
                                        {
                                            Console.WriteLine("We have not that student.");
                                            checker = false;
                                        }
                                        else
                                        {
                                            ArrayListStudents.RemoveAt(indexStuDel);
                                            counterStudent--;
                                            checker = true;
                                        }

                                    } while (checker == false);
                                }
                                else
                                {
                                    Console.WriteLine("ArrayList Students is empty");
                                    selectionForSwitch = true;
                                }

                                Read();
                                break;
                            }
                        case "12":
                            {
                                if (counterAspirant > 0)
                                {
                                    bool checker;
                                    do
                                    {
                                        Console.Write("Enter index which aspirant you want to delete: ");
                                        int indexAspDel = NumberCheckerForInt();

                                        if (indexAspDel >= counterAspirant)
                                        {
                                            Console.WriteLine("We have not that aspirant.");
                                            checker = false;
                                        }
                                        else
                                        {
                                            ArrayListAspirants.RemoveAt(indexAspDel);
                                            counterAspirant--;
                                            checker = true;
                                        }

                                    } while (checker == false);
                                }
                                else
                                {
                                    Console.WriteLine("ArrayList Aspirants is empty");
                                    selectionForSwitch = true;
                                }

                                Read();
                                break;
                            }
                        case "13":
                            {
                                bool firstLastChoice;
                                Console.Write("Enter which student you want to delete\n1)First\n2)Last\nChoice: ");
                                do
                                {
                                    byte lastFirstChoice = NumberCheckerForByte1OR2();

                                    if (lastFirstChoice == 1)
                                    {
                                        LinkedListStudents.RemoveFirst();
                                        counterStudent--;
                                        firstLastChoice = true;
                                    }
                                    else if (lastFirstChoice == 2)
                                    {
                                        LinkedListStudents.RemoveLast();
                                        counterStudent--;
                                        firstLastChoice = true;
                                    }
                                    else
                                    {
                                        Console.Write("Incorrect type, enter 1 or 2: ");
                                        firstLastChoice = false;
                                    }
                                } while (firstLastChoice == false);

                                Read();
                                break;
                            }
                        case "14":
                            {
                                bool firstLastChoice;
                                Console.Write("Enter which aspirant you want to delete\n1)First\n2)Last\nChoice: ");
                                do
                                {
                                    byte lastFirstChoice = NumberCheckerForByte1OR2();
                                    if (lastFirstChoice == 1)
                                    {
                                        LinkedListAspirants.RemoveFirst();
                                        counterAspirant--;
                                        firstLastChoice = true;
                                    }
                                    else if (lastFirstChoice == 2)
                                    {
                                        LinkedListAspirants.RemoveLast();
                                        counterAspirant--;
                                        firstLastChoice = true;
                                    }
                                    else
                                    {
                                        Console.Write("Incorrect type, enter 1 or 2: ");
                                        firstLastChoice = false;
                                    }
                                } while (firstLastChoice == false);

                                Read();
                                break;
                            }
                        case "15":
                            {
                                Console.WriteLine("Have a good day :)");
                                selectionForAll = true;
                                selectionForSwitch = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You enter incorrect number, please enter from 1 till 15");
                                Menu();
                                continue;
                            }
                    }
                } while (selectionForSwitch == false);
            } while (selectionForAll == false);

            Console.ReadKey();
        }
    }
}