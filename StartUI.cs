using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquestrianGamblers
{
    internal class StartUI
    {
        internal static List<Betters> bettors = new List<Betters>();
        /// <summary>
        /// Unimportant. Just Credits.
        /// </summary>
        public static void Credit()
        {
            Console.WriteLine("MIDTERMS\n\n");
            Console.WriteLine("Made by.");
            Console.WriteLine("Anthonette Llorhayne S. Yao");
        }

        public static void TitleScreen()
        {
            String Line1 = "Welcome to the game";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line1.Length) / 2.0f), 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Line1);
            String Line2 = "EQUESTRIAN BETTERS!";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line2.Length) / 2.0f), 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Line2);
            Console.ResetColor();
            String Line3 = "Menu  ";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line3.Length) / 2.0f), 10);
            Console.Write(Line3);

            String Line4 = "⮞ Start  ";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line4.Length) / 2.4f), 12);
            Console.Write(Line4);
            String Line5 = "⮞ Options";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line5.Length) / 2.4f), 13);
            Console.Write(Line5);
            String Line6 = "⮞ Exit   ";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line6.Length) / 2.4f), 14);
            Console.Write(Line6);
            Console.WriteLine();
        }

        public static void HS()
        {
            Console.Clear();
            StartUI.HorseDotArt();
            TitleScreen();
            Console.WriteLine();
            string menUinput = Console.ReadLine().ToLower();
            switch (menUinput)
            {
                case "start":
                    Console.Clear();
                    OTGB();
                    Game.Start();
                    break;
                case "options":
                    Console.Clear();
                    OTGB();
                    BGM.Audio();

                    int music = 0;
                    if (music != 0)
                    {
                        Console.WriteLine("Music is turned on");
                    }
                    else if (music == 0)
                    {
                        Console.WriteLine("The music is turned off");
                    }
                    string OPinput = Console.ReadLine();
                    switch (OPinput)
                    {
                        case "Audio":
                            BGM.Audio();
                            break;
                        case "Test Audio":
                            //put rick astley music here
                            BGM.Audio();
                            break;
                    }
                    break;
                case "credits":
                    Credit();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    error();
                    Console.ReadKey();
                    HS();
                    return;

            }
        }

        /// <summary>
        /// Retry at the end of the gamme
        /// </summary>
        public static void retry()
        {
            Console.WriteLine("This is the end of the game . . .");

            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\nRetry?");
            Console.WriteLine("⮞ Yes" +
                "\n⮞ No");
            string rans = Console.ReadLine().ToLower();

            switch (rans)
            {
                case "yes":
                    HS();
                    break;
                case "no":
                    Environment.Exit(0);
                    break;
            }
        }

        /// Error window
        /// </summary>
        public static void error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid. Try again.");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Option to get bacc to homescreen
        /// </summary>
        public static void OTGB()
        {
            string Line0 = "Back ⮌ ";
            Console.SetCursorPosition((int)((Console.WindowWidth - Line0.Length) / 1.0f), 1);
            Console.WriteLine(Line0);
            Console.WriteLine();
        }

        /// Displays the names of the bettors in a line like a formation in a stadium
        /// </summary>
        /// <param name="bettors"></param>
        public static void Audience(List<Betters> bettors)
        {
            int maxNameLength = bettors.Max(b => b.name.Length) + 2;
            int rowLength = Math.Min(bettors.Count, 20);
            int rows = (int)Math.Ceiling((double)bettors.Count / rowLength);

            Console.Clear();
            OTGB();
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(new string('-', 120));
                for (int j = i * rowLength; j < (i + 1) * rowLength && j < bettors.Count; j++)
                {
                    Console.WriteLine("\t\t");
                    Console.Write("{0, -" + maxNameLength + "}", bettors[j].name);
                    Console.WriteLine("\t\t");
                    Console.Write(" (Horse {0}, Bet {1})\n", bettors[j].GetHorseNumber(), bettors[j].betAmount);
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 120));
            Console.WriteLine();
            Console.WriteLine("\n\n\nEnter any key to go back.");
            Console.ReadKey();
            Game.PreGame();
        }
        /// <summary>
        /// option to spy ont he competition
        /// </summary>
        public static void Spying()
        {
            Console.WriteLine("\t╔═══════════════════▣◎▣═══════════════════╗");
            Console.WriteLine("\t|       [1] Look at the competition       |\t\tYou've been given a choice, type [1] or [2].");
            Console.WriteLine("\t|       [2] Start the Game                |");
            Console.Write("\t╚═══════════════════▣◎▣═══════════════════╝\t\t");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Spying();
                return;
            }

            if (int.TryParse(input, out int spyChoice))
            {
                switch (spyChoice)
                {
                    case 1:
                        Audience(bettors);
                        break;
                    case 2:
                        Console.WriteLine("Let the Game Commence!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter 1 or 2.");
                        Spying();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Spying();
            }
        }

        public static void flag()
        {
            Console.WriteLine();

        }

        /// <summary>
        /// Background for Home Screen
        /// </summary>
        public static void HorseDotArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(@"
                            ⠀⠀⠀⠀⠀⠀⢀⠀⠀⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠘⣦⡀⠘⣆⠈⠛⠻⣗⠶⣶⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠈⣿⠀⠈⠳⠄⠀⠈⠙⠶⣍⡻⢿⣷⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⣰⣿⣧⠀⠀⠀⠀⠀⠀⠀⠈⠻⣮⡹⣿⣿⣷⣦⣄⣀⠀⠀⢀⣸⠃⠀⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⢠⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣮⢿⣿⣿⣿⣿⣿⣿⣿⠟⠀⢰⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⢀⣾⣿⠀⠀⠀⠀⠀⠀⠀⣷⠀⢷⠀⠀⠀⠙⢷⣿⣿⣿⣿⣟⣋⣀⣤⣴⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⢀⣼⢿⣿⡀⠀⠀⢀⣀⣴⣾⡟⠀⠈⣇⠀⠀⠀⠈⢻⡙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⣼⡏⠸⣿⣿⣶⣾⣿⡿⠟⠋⠀⠀⠀⢹⡆⠀⠀⠀⠀⠹⡽⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⣰⣿⠀⠀⠀⣀⡿⠛⠉⠀⠀⢿⠀⠀⠀⠘⣿⡄⠀⠀⠀⠀⠑⢹⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⣿⣿⣷⣶⣾⠏⠀⠀⠀⠀⠀⠘⣇⠀⠀⠀⢻⡇⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⡿⠃⠀⣠⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠈⠙⠿⠿⠋⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⢸⣷⠀⠀⠀⠀⠀⢀⠀⠹⣿⣿⣿⣿⣷⣶⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⠀⠀⢸⣿⠀⠀⠀⠀⢀⡞⠀⠀⠈⠛⠻⠿⠿⠯⠥⠤⢄⣀⣀⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⠀⠀⠀⢸⡇⠀⠀⠀⢀⡼⠃⠀⠀⠀⠀⠀⣄⠀⠀⠀⠀⠀⠀⠈⠙⠂⠙⠳⢤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠇⠀⠀⠀⡾⠁⠀⠀⣠⡿⠃⠀⠀⠀⠀⠀⠀⠸⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠀⠀⠀⡸⠃⠀⢀⣴⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣷⣶⣶⣦⣤⣀⡀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠇⠀⠀⠀⠃⢀⣴⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣶⣤⡀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠏⠀⠀⠀⠀⣰⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣧⠙⠻⣿⣿⣿⣿⣿⣿⣦⡀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡏⠀⠀⢀⡖⢰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠟⠀⠀⠀⢸⣿⠀⠀⠈⢿⣿⣿⣿⣿⣿⡿
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡇⠀⠀⣼⠁⠼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⣼⡇⠀⠀⣠⣾⣿⣿⣿⣿⠟⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠘⣇⠀⠀⢻⡄⢠⡄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⠁⠀⠀⠀⢀⣼⠏⠀⣠⣾⣿⣿⡿⣿⡿⠁⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠁⠀⠘⠂⠀⠀⢳⠀⢳⡀⠀⠀⠀⠀⠀⠀⢀⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣾⣿⠃⠀⠀⠀⠀⣠⣾⠃⣠⣾⣿⣿⠿⠋⢰⡟⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⢠⣿⠃⠀⠀⠀⢀⣀⡴⠞⠙⠲⣷⡄⠀⠀⠀⠀⢠⡾⠁⠀⠀⠀⢀⣀⣠⣤⣶⠿⠟⠋⠀⡾⠀⠀⠀⢀⣴⠟⠁⢠⡟⢱⡿⠃⠀⠀⠸⣇⡀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⢀⡴⠟⠁⠀⣀⡤⠖⠋⠁⠀⠀⠀⠀⣸⠇⠀⠀⠀⣤⠟⠑⠋⠉⣿⠋⠉⠉⠉⠁⣠⠞⠀⠀⠀⡇⠀⠀⢠⡿⠋⠀⠀⠈⠁⡿⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀
                            ⠀⠀⠀⢀⣾⣏⣤⣶⡾⠛⠉⠀⠀⠀⠀⠀⠀⢀⡼⠃⠀⠀⣠⠞⠁⠀⠀⠀⠀⣿⠀⠀⠀⢀⡼⠃⠀⠀⠀⢸⠇⠀⣰⠟⠀⠀⠀⠀⠀⠐⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⢀⣿⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⢀⣴⠏⠀⠀⣠⠞⠁⠀⠀⠀⠀⠀⠀⣿⠀⠀⢀⡾⠃⠀⠀⠀⢀⡞⠀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⣼⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣶⣶⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⣾⠇⠀⠀⠀⢀⣾⣣⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⢠⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⢠⡟⠀⠀⠀⢀⣾⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⢀⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⡄⢀⣀⡀⠀⠀⠀⠀⠀⠀⢸⡇⠀⣾⠇⠀⠀⣰⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⢸⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⣾⠀⣰⠟⠀⢀⣼⣿⣿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⢸⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⠿⠿⠿⠿⠿⠃⠀⠀⠀⢸⣿⣶⠏⢀⣴⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⢸⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⠃⢠⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⢿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⢃⣴⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠈⠛⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣧⣾⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⡟⢸⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⠁⠀⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⠿⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀𐂃");
        }

        public static void JoshHutcherson()
        {
            Console.WriteLine(@"
                                ⣿⣿⣿⣿⣿⣿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⠤⠤⠀⠒⠶⣀⠀⠀⠀⠈⣿⣿⣿⡿⠁
                                ⣿⣿⣿⣿⣿⡗⠈⠀⠀⠀⣠⢀⣀⠀⣀⠀⢀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠶⠚⣛⣉⠠⠀⣄⣀⠀⠀⠀⠀⠀⠀⠀⢿⣿⡿⠁⠀
                                ⠹⣯⢼⣿⣿⣿⠀⠀⣰⣷⢴⠳⠟⠛⠙⢻⣛⣟⣓⡋⠢⠀⢀⠀⠀⠀⠀⠀⠀⠀⠠⣪⢵⣶⣶⣶⠦⣌⡙⠀⠀⠀⠀⠀⠀⢸⣿⠃⠀⠀
                                ⠀⣿⣼⡟⣿⣿⠀⢀⠢⠁⠀⣰⣜⣿⢿⣿⠿⢿⠟⢕⠢⠀⠃⠀⠀⠀⠀⠀⠀⠀⠐⠁⠈⠒⠒⠁⠀⠈⠅⠀⠀⠀⠀⠀⠀⡘⠟⢀⠀⠀
                                ⠲⣿⢧⡃⣽⣿⠂⠀⠀⠀⠀⠉⠟⠉⠠⠈⠁⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠺⠀⠀⠀⠀
                                ⠀⡹⠸⣇⢸⣿⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠆⠀⠀⠀
                                ⢠⡇⠀⣿⡘⢿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀
                                ⣼⣯⡈⠈⢯⠎⠻⡜⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀
                                ⣿⣷⣿⣆⢘⣆⠀⣷⢁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠮⠁⠀⠀
                                ⣿⣿⣿⣿⣶⣌⠦⣜⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⣀⡄⠀⠀⠀⣰⣤⡠⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⢋⠄⠀⢀⢠
                                ⣿⣿⣿⣿⣿⣿⣷⣎⣗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢛⠙⠛⡈⠀⠜⠈⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡂⢠⡴⣏⢧
                                ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⢿⡱⣏⠖
                                ⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠠⢤⣤⣤⣤⣄⣀⣠⣀⣠⠶⠴⠦⠤⠒⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡿⣏⠷⠈⠌
                                ⠀⠌⠙⠻⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢺⠟⠀⠀⠀⠀
                                ⠀⠀⠀⠀⢉⠻⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⡈⠇⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠈⠉⠙⠻⢿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠔⠇⢠⠃⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣦⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⠁⠀⢠⠎⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⢹⣿⣞⡄⡀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠎⠀⠀⣀⠔⠁⠀⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣈⢻⣿⣧⣗⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⢖⡡⠔⣠⡰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⠀⣼⣿⡏⠈⣿⡿⠁⠀⠀⠽⢿⣿⣾⣽⡷⣦⢤⡀⡄⣀⠀⡀⡀⠄⠔⣒⢱⣜⣮⡴⠚⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⣾⣿⣿⡇⠀⢿⠁⠀⠀⠀⠀⠈⠙⣿⣿⣿⣿⣯⣷⡬⣫⡀⡱⣀⣖⣼⣾⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀⠀⠀⠻⡟⠙⡷⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣷⣿⣿⣿⣿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⣻⣟⢿⣿⠟⣋⡀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⠹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡾⢛⣽⣴⢴⣟⢙⣿⣦⡙⠑⠓⠙⠃⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        }

        /// <summary>
        /// Welcome sign for the game
        /// </summary>
        public static void welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t█░█░█ █▀▀ █░░ █▀▀ █▀█ █▀▄▀█ █▀▀\n\t\t\t\t\t\t▀▄▀▄▀ ██▄ █▄▄ █▄▄ █▄█ █░▀░█ ██▄");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nDescription: This is a horse track race, where you can gamble away for the horse of your picking. To start, you have to type the number of bettors that want to participate in this round.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("MAX PLAYERS IS 20.");
            Console.ResetColor();
        }

        public static void ReadySet()
        {
            for (int r = 3; r >= 0; r--)
            {
                string readyset = "READY,SET,GO!,";
                string[] readysetgo = readyset.Split(',');
                foreach (string ready in readysetgo)
                {
                    Console.Clear();
                    Console.WriteLine(ready);
                    Thread.Sleep(1500);
                }
                return;
            }
        }

        public static void Loading()
        {
            for (int l = 3; l >= 0; l--)
            {
                string loading = "\nLOADING ,. ,. ,.";
                string[] loads = loading.Split(',');
                foreach (string load in loads)
                {
                    Console.Write(load);
                    Thread.Sleep(1300);
                }
                return;
            }
        }
    }
}
