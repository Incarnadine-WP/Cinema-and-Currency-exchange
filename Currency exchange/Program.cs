using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_exchange
{
    class Program
    {
        static void Main(string[] args)
        {

            float USD;
            float Rub;

            int sellUSD = 66;
            int buyUSD = 71;

            string userInput;

            string howMuchToChange;

            Console.WriteLine("Добро пожаловать в обмен валют.\nТекущий курс обмена: купить доллары по 71 / продать доллары по 66");
            Console.WriteLine("Укажите сумму денег на вашем счете.");

            Console.Write("Сколько долларов: ");
            USD = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько рублей: ");
            Rub = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1 - обменять рубли на доллары:");
            Console.WriteLine("2 - обменять доллары на рубли:");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":

                    Console.Write("Сколько рублей хотите обменять: ");
                    howMuchToChange = Console.ReadLine();
                    if (float.TryParse(howMuchToChange, out float result))
                    {
                        if (result <= Rub)
                        {
                            Rub -= result;
                            USD += result / buyUSD;
                        }
                    }

                    else
                        Console.WriteLine("невозможно обменять указанную сумму.");
                    break;

                case "2":

                    Console.Write("Сколько долларов хотите обменять: ");
                    howMuchToChange = Console.ReadLine();
                    if (float.TryParse(howMuchToChange, out result))
                    {
                        if (result <= USD)
                        {
                            Rub += result * sellUSD;
                            USD -= result;
                        }
                    }
                    else
                    {
                        Console.WriteLine("невозможно обменять указанную сумму.");
                    }
                    break;

                default:
                    Console.WriteLine("Неверная команда");
                    break;
            }

            Console.WriteLine($"Ваш баланс {USD} долларов, {Rub} рублей");

        }
    }
}
