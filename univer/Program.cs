using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Human.Human;
using static Menu_and_other_staff.Menu;
using static Menu_and_other_staff.Input;
using static Menu_and_other_staff.Output;

namespace Универ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int i = 0;
            List<Teacher> teacher = new List<Teacher>();
            List<Tech> tech = new List<Tech>();
            List<Boss> boss = new List<Boss>();
            List<Student> student = new List<Student>();

            while (true)
            {
                Menu_Start(i);

                ConsoleKeyInfo key = Console.ReadKey();
                int n = 3;
                if (key.Key == ConsoleKey.Enter && i == 0) // Ввод данных
                {
                    Console.Clear();
                    while (true)
                    {
                        Menu_Input(i);

                        ConsoleKeyInfo new_key = Console.ReadKey();
                        n = 5;

                        if (new_key.Key == ConsoleKey.Enter && i == 0) 
                        {
                            Input_Teacher(teacher);
                        }
                        if (new_key.Key == ConsoleKey.Enter && i == 1) 
                        {
                            Input_Tech(tech);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 2) 
                        {
                            Input_Boss(boss);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 3) 
                        {
                            Input_Student(student);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 4) 
                        {
                            Console.Clear();
                            Console.SetCursorPosition(40, 0);
                            break;
                        }

                        i = Move(new_key, i, n);
                    }
                    i = 0;
                }

                if (key.Key == ConsoleKey.Enter && i == 1) 
                {
                    Console.Clear();
                    i = 0;
                    while (true)
                    {
                        Menu_Search(i);

                        ConsoleKeyInfo very_new_key = Console.ReadKey();
                        n = 6;

                        if (very_new_key.Key == ConsoleKey.Enter && i == 0) 
                        {
                            Search_Bad_Guys(student);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 1) 
                        {
                            Search_Debt(student);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 2) 
                        {
                            Search_Subject(teacher);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 3)
                        {
                            Search_Orders(boss);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 4)  
                        {
                            Search_Teacher_Experience(teacher);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 5) 
                        {
                            Console.Clear();
                            break;
                        }

                        i = Move(very_new_key, i, n);
                    }
                    i = 0;
                }

                if (key.Key == ConsoleKey.Enter && i == 2)
                {
                    break;
                }

                i = Move(key, i, n);
            }

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            foreach (Boss b in boss)
            {
                Console.WriteLine($"surname: {b.surname}");
                foreach (KeyValuePair<string, List<string>> d in b.order)
                {
                    Console.WriteLine($"key: {d.Key}");
                    Console.Write("value: ");
                    foreach (string s in d.Value)
                    {
                        Console.Write(s + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
