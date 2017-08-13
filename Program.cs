using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
            Console.WriteLine("Выбери игру:");
            Console.WriteLine("1 ----> Найди символ");
            Console.WriteLine("2 ----> Угадай число");
            Console.WriteLine("3 ----> ВЫЧИСЛИТЕЛЬ!");
            byte gameNum = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("0 -----> I'm a Potato");
            Console.WriteLine("1 -----> Адекватный");
            Console.WriteLine("2 -----> Мне не жалко свои нервы");
            int levelHard = Convert.ToInt32(Console.ReadLine());
            if (levelHard > 2)
            {
                Console.WriteLine("Ты картоха.");
                levelHard = 0;
            }

            int score = 0;
            Random r = new Random();
            
            ///////////////////////////////////////////////////////
            if (gameNum == 1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Ваше количество очков: " + score);
                    int randomNumber = r.Next(0, 100);
                    int symbolCount = 3000;
                    int sCount = 0;
                    while (symbolCount-- > 0)
                    {
                        if (r.Next(0, 1000) == '1')
                        {
                            if (levelHard == 2)
                            {
                                Console.ForegroundColor = (ConsoleColor)r.Next(16);
                            }
                            else if (levelHard == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('S');
                            sCount++;
                        }
                        else
                        {
                            if (levelHard == 2)
                            {
                                Console.ForegroundColor = (ConsoleColor)r.Next(16);
                            }
                            else if (levelHard == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write('C');
                        }
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Сколько S?");
                    int answer = Convert.ToInt32(Console.ReadLine());
                    if (answer == sCount)
                    {
                        score += 10;
                    }
                    else score--;
                }
                    Console.Clear();
            }
            //////////////////////////////////////////////////////////////
            if (gameNum == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Я загадал число.. Отгадай какое");
                    int question = 0;
                    if (levelHard == 0 || levelHard == 1)
                    {
                        question = r.Next(10, 1000);
                    }
                    else question = r.Next(10, 10000); Console.ForegroundColor = (ConsoleColor)r.Next(16);
                    int userNumber = 0;
                    do
                    {
                        userNumber = Convert.ToInt32(Console.ReadLine());
                        if (userNumber - question > 20 && userNumber - question < 200)
                        {
                            Console.WriteLine("Немного меньше...");
                        }
                        else if (userNumber - question > 200)
                        {
                            Console.WriteLine("Гораздо меньше...");
                        }
                        else if (question - userNumber > 20 && question - userNumber < 200)
                        {
                            Console.WriteLine("Чуть больше...");
                        }
                        else if (question - userNumber > 200)
                        {
                            Console.WriteLine("Гораздо больше...");
                        }
                        else
                        {
                            Console.WriteLine("Это правильный ответ!");
                            score += 10;
                        }
                    }
                    while (question != userNumber);
                }
                    Console.Clear();
            }
                /////////////////////////////////////

                {
                    Console.CursorVisible = false;
                    Console.Clear();
                    while (true)
                    {
                        int operand1 = r.Next(0, 100), operand2 = r.Next(0, 100);
                        string expression = operand1 + " + " + operand2;
                        int expressionResult = operand1 + operand2;
                        int shipX = 0, shipY = 30;
                        int rightBlock = r.Next(0, 3);
                        DateTime startTime = DateTime.Now;

                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(20 * i, 7);
                            if (i == rightBlock)
                            {
                                Console.Write(expressionResult);
                            }
                            else
                            {
                                Console.Write(r.Next(expressionResult - 10, expressionResult + 10));
                            }
                        }

                        while (true)
                        {
                            Console.MoveBufferArea(0, 100, Console.WindowWidth, 50, 0, 8);
                            Console.SetCursorPosition(shipX, shipY);
                            Console.WriteLine("#!#");
                            Console.SetCursorPosition(shipX, shipY + 4);
                            Console.WriteLine(expression);
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.Key == ConsoleKey.RightArrow)
                            {
                                if (shipX == 0)
                                {
                                    shipX = 20;
                                }
                                else if (shipX == 20)
                                {
                                    shipX = 40;
                                }
                            }
                            else if (keyInfo.Key == ConsoleKey.LeftArrow)
                            {
                                if (shipX == 40)
                                {
                                    shipX = 20;
                                }
                                else if (shipX == 20)
                                {
                                    shipX = 0;
                                }
                            }

                            if ((DateTime.Now - startTime).TotalMilliseconds > 5000)
                            {
                                if ((shipX / 20) == rightBlock)
                                {
                                    Console.WriteLine("Правильные ворота!");
                                }
                                else
                                {
                                    Console.WriteLine("Не верно!");
                                }
                                Thread.Sleep(10000);
                            }
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }
}