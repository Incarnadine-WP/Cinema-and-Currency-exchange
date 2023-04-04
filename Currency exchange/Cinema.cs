using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class CinemaDemo
    {
        static void Main(string[] args)
        {
            ColorTheme color = new ColorTheme();

            int[] sectors = { 6, 15, 15, 12 };
            bool usingProgram = true;

            string[,] space = new string[,]
              {
                {"Ряд -  1, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  2, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  3, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  4, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  5, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  6, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  7, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  8, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд -  9, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд - 10, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд - 11, места: ","1","2","3","4","5","6","7","8","9","10" },
                {"Ряд - 12, места: ","1","2","3","4","5","6","7","8","9","10" },

              };

            while (usingProgram)
            {
                Console.WriteLine("Добро пожаловать в Кинотеатр.");

                Console.SetCursorPosition(0, 18);

                for (int i = 0; i < space.GetLength(0); i++)
                {
                    for (int j = 0; j < space.GetLength(1); j++)
                    {
                        if (space[i, j] == "X")
                            color.ChangeColor(space[i, j] + " ");

                        else
                            Console.Write(space[i, j] + "  ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\n\n1) Забронировать места.\n\n2) Выйти из программы.\n");
                Console.Write("Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("В каком ряду хотите забронировать место?");
                        string userSector = Console.ReadLine();
                        int cleanSector;

                        while (!int.TryParse(userSector, out cleanSector))
                        {
                            Console.WriteLine("Выберите доступный вариант программы: 1 или 2");
                            userSector = Console.ReadLine();
                        }

                        if (cleanSector > space.GetLength(1) +1 || cleanSector <= 0)
                        {
                            Console.WriteLine("Такого ряда не существует.");
                            break;
                        }

                        Console.Write("Какое место хотите забронировать?: ");
                        string placeCount = Console.ReadLine();
                        int cleanCount;

                        while (!int.TryParse(placeCount, out cleanCount))
                        {
                            Console.WriteLine("Это места забронировать невозможно");
                            placeCount = Console.ReadLine();
                        }

                        if (cleanCount >= space.GetLength(1) || cleanCount <= 0)
                        {
                            Console.WriteLine("Такого места не существует.");
                            break;
                        }

                        if (space[cleanSector - 1, cleanCount] != "X")
                        {

                            Console.WriteLine($"Вы забронировали билет: ряд {cleanSector} место {cleanCount} ");
                            space[cleanSector - 1, cleanCount] = "X";
                            Console.WriteLine("\nДля продолжения нажмите любую клавишу.");
                            break;
                        }

                        else
                            Console.WriteLine("Место занято");
                        break;

                    case "2":
                        usingProgram = false;
                        break;

                    default:
                        Console.WriteLine("Выберите доступный вариант 1 или 2");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class ColorTheme
    {
        public void ChangeColor(string item, ConsoleColor color = ConsoleColor.Blue)
        {
            ConsoleColor mainColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(item+" ");
            Console.ForegroundColor = mainColor;
        }
    }

}


