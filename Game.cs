using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquestrianGamblers
{
    internal class Game
    {
        static int NumberofHorses = -1;

        public static void Start()
        {
            int numHorses = Betters.NumberofHorsey();
            int initialPrizePool = 1000;

            Betters.Participate(numHorses, initialPrizePool);
            PreGame();
            NumberofHorses = numHorses;
        }

        public static void LoadingtoGame()
        {

            Console.Clear();
            string momint = "Please take a moment to settle down onto your respected seats";

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n" +
                "\t\t\t\t" + $"{momint}");
            string dot = "\n\t\t\t\t\t\t\t   . ,. ,.";
            string[] dotz = dot.Split(',');
            foreach (string dotted in dotz)
            {
                Console.Write(dotted);
                Thread.Sleep(1300);
            }

            Console.Clear();
        }

        public static void PreGame()
        {
            LoadingtoGame();
            prefield();
            StartUI.Spying();
        }

        public void Winner()
        {

        }

        public static void prefield()
        {
            Random rand = new Random();
            //while (true)
            //{
            //    Console.WriteLine(new string('-', 120));
            //    Thread.Sleep(360);
            //    for (int tracks = 1; tracks <= 100; tracks++)
            //    {
            //        for (int i = 0; i <= NumberofHorses; i++)
            //        {
            //            int hooves = rand.Next(0, 101);
            //            if (hooves == -1)
            //            {

            //            }
            //            else if (hooves == 0)
            //            {

            //            }
            //            else if (hooves == 1)
            //            {

            //            }
            //            else if (hooves == 2)
            //            {

            //            }
            //        }
            //    }
            //    Console.WriteLine(new string('-', 120));
            //    Console.WriteLine();
            //    return;
            //}

            int[] num = new int[NumberofHorses];
            int[] position = new int[NumberofHorses];
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Thread.Sleep(360);
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine(new string('-', 120));
                for (int x = 0; x < NumberofHorses; x++)
                {
                    if (position[x] >= 100)
                    {
                        for (int y = 0; y < 100; y++)
                            Console.Write(" ");
                        Console.Write("𐂃");
                    }
                    else
                    {
                        for (int y = 0; y < position[x]; y++)
                            Console.Write(" ");
                        Console.Write("𐂃");
                    }
                    for (int y = 0; y < 100 - position[x]; y++)
                        Console.Write(" ");
                    if (position[x] <= 100)
                        Console.WriteLine("|");
                    else
                    {
                        Console.WriteLine();
                    }
                    position[x] += rand.Next(-1, 3);
                }
                for (int x = 0; x < NumberofHorses; x++)
                {
                    if (position[x] >= 100)
                    {
                        num[x] = 1;
                    }
                }
                int total = 0;
                for (int x = 0; x < NumberofHorses; x++)
                {
                    total += num[x];
                }
                if (total * NumberofHorses == NumberofHorses * NumberofHorses)
                    break;
                //    Console.WriteLine(new string('-', 120));
            }
            Console.WriteLine("The Race Has Ended.");
        }


    }
}