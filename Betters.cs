using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquestrianGamblers
{
    internal class Betters
    {
        public string name;
        public int betAmount, horseNumber;
        public static int prizePool;

        public Betters(string name)
        {
            this.name = name;
        }
        public void PlaceBet(int amount)
        {
            betAmount = amount;
            prizePool += betAmount;
            Console.WriteLine($"Current prizepool: {prizePool}");
        }

        public void ChooseHorse(int horseNumber, int numHorses)
        {
            if (horseNumber >= 1 && horseNumber <= numHorses)
            {
                this.horseNumber = horseNumber;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid horse number. Please enter a number between 1 and 15.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                StartUI.OTGB();
                ChooseHorse(horseNumber, numHorses);
            }
        }
        public int GetHorseNumber()
        {
            return horseNumber;
        }

            public static List<string> HorseTag = new List<string>();

            public static void DisplayHorseyNames(int numHorses)
            {
                string filepath = "Racing Horse Names.csv";
                List<string> horseNames = new List<string>();
                List<string> colors = new List<string> { "Red", "Blue", "Green", "Yellow", "Magenta", "Cyan", "DarkRed", "DarkCyan", "DarkBlue", "White", "DarkMagenta", "DarkGreen", "DarkYellow", "Gray", "DarkGray" };

                using (StreamReader HorseNames = new StreamReader(filepath))
                {
                    string line = HorseNames.ReadLine();
                    while (line != null)
                    {
                        horseNames.Add(line);
                        line = HorseNames.ReadLine();
                    }
                }

                Random rand = new Random();
                int numDisplayedHorses = rand.Next(numHorses, numHorses);

                Console.WriteLine("\t\t\t\t\t\t=================================" +
                    "\n\t\t\t\t\t\tList of Horses Currently Playing:" +
                    "\n\t\t\t\t\t\t=================================");
                for (int i = 0; i < numDisplayedHorses; i++)
                {
                    int horseNumber = i + 1;
                    int randomIndex = rand.Next(horseNames.Count);
                    string horseName = horseNames[randomIndex];
                    string color = colors[randomIndex % colors.Count];
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
                    Console.WriteLine($"\t\t\t\t\t\t{horseNumber}\t" + horseName);
                    Console.ResetColor();
                    horseNames.RemoveAt(randomIndex);
                    colors.Remove(color);
                    HorseTag.Add(horseName);
                }
            }

        static public int NumberofHorsey()
        {
            Random rand = new Random();
            int numHorses = rand.Next(5, 15);
            return numHorses;
        }

        /// <summary>
        /// Getting every info avout the bettors
        /// </summary>
        /// <param name="numHorses"></param>
        public static void Participate(int numHorses, int initialPrizePool)
        {
            prizePool = initialPrizePool;

            StartUI.OTGB();
            StartUI.welcome();
            Console.WriteLine("\n\n\nParticipating bettors: ");
            string numBettor = Console.ReadLine().ToLower();
            if (int.TryParse(numBettor, out int numBettors) && numBettors <= 20 && numBettors > 1)
            {
                StartUI.Loading();
                Thread.Sleep(200);
                Console.Clear();
                StartUI.OTGB();
                DisplayHorseyNames(numHorses);
                Console.WriteLine("\n\t\t\t\t\t     Starting prizepool is at 1000. Always.");

                List<Betters> bettors = new List<Betters>();
                for (int i = 1; i <= numBettors; i++)
                {
                    Console.Write($"\nEnter name for bettor {i}: ");
                    string name = Console.ReadLine().ToLower();
                    Betters bettor = new Betters(name);
                    if (name == "")
                    {
                        StartUI.error();
                        Console.Clear();
                        i--;
                        continue;
                    }
                    if (name == "back")
                    {
                        Console.Clear();
                        Betters.Participate(numHorses, initialPrizePool);
                        return;
                    }
                    bettors.Add(bettor);

                    Console.Write($"Bettor {name}, on which horse would you like to bet? ( 1 - {numHorses} ): ");
                    string horseNumberInput = Console.ReadLine();
                    if (int.TryParse(horseNumberInput, out int horseNumber) && horseNumber >= 1 && horseNumber <= numHorses)
                    {
                        bettor.ChooseHorse(horseNumber, numHorses);
                    }
                    else if (horseNumberInput == "back")
                    {
                        Console.Clear();
                        i--;
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        StartUI.error();
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        i--;
                        StartUI.OTGB();
                        DisplayHorseyNames(numHorses);
                        continue;
                    }

                    Console.Write($"Bettor {name}, how much would you like to bet? ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("[enter the number] ");
                    Console.ResetColor();
                    string betAmountInput = Console.ReadLine();
                    if (int.TryParse(betAmountInput, out int betAmount))
                    {
                        bettor.PlaceBet(betAmount);
                    }
                    else if (betAmountInput == "back")
                    {
                        Console.Clear();
                        i--;
                        continue;
                    }
                    else
                    {
                        StartUI.error();
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        i--;
                        continue;
                    }

                }
                StartUI.bettors = bettors;
                proceed();
                return;
            }
            if (numBettors == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't play by yourself!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\t\t\t\t    You've been kicked out of the game for being alone.");
                Console.ReadKey();

                StartUI.HS();
            }
            if (numBettor == "back")
            {
                StartUI.HS();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number of bettors. Please enter a number between 2 and 20.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Betters.Participate(numHorses, initialPrizePool);
            }
        }

        public static void proceed()
        {
            Thread.Sleep(800);
            Console.Clear();
            Console.Write("\n\n\n\n\n\t\t\t\t\t\t   Proceed? ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[y/n] ");
            Console.ResetColor();
            string proceedtogame = Console.ReadLine().ToLower();
            switch (proceedtogame)
            {
                case "y":
                    StartUI.Loading();
                    break;
                case "n":
                    Console.Clear();
                    proceed();
                    break;
                default:
                    StartUI.error();
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}