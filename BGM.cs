using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.Collections;
using System.Reflection;

namespace EquestrianGamblers
{
    internal class BGM
    {
        private List<SoundPlayer> _bgmPlayers;
        /// <summary>
        /// This is the optionin the start menu if the user wants to toggle audio off or on.
        /// </summary>
        /// <returns></returns>
        /// 
        public BGM()
        {
            _bgmPlayers = new List<SoundPlayer>();
            _bgmPlayers.Add(new SoundPlayer("")); //for the lols
            _bgmPlayers.Add(new SoundPlayer("")); //during race
            //_bgmPlayers.Add(new SoundPlayer(""));
        }

        public void PlayAudio(int Index)
        {
            if (Index >= 0 && Index < _bgmPlayers.Count)
            {
                _bgmPlayers[Index].Play();
            }
        }

        public void StopAudio(int Index)
        {
            if (Index >= 0 && Index < _bgmPlayers.Count)
            {
                _bgmPlayers[Index].Stop();
            }
        }

        public static bool Audio()
        {
            Console.WriteLine("Allow background music? [y/n]");
            string yn1 = Console.ReadLine().ToLower();

            switch (yn1)
            {
                case "y":
                    Console.WriteLine("Music is On");
                    Console.WriteLine("Test music if on: [y/n]");
                    string yn2 = Console.ReadLine().ToLower();
                    switch (yn2)
                    {
                        case "y":
                        case "n":
                            Console.Clear();
                            StartUI.OTGB();
                            Console.WriteLine("There is no music for the game--only for this test. LOL. You got tricked.");
                            StartUI.JoshHutcherson();

                            Thread.Sleep(1000);

                            Console.WriteLine("Type 'back' to go back");
                            string musicback = Console.ReadLine().ToLower();
                            if (musicback == "back")
                            {
                                StartUI.HS();
                            }
                            else
                            {
                                StartUI.error();
                                Console.ReadLine();
                                Console.Clear();
                            }
                            break;
                        default:
                            StartUI.error();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                    break;
                case "n":
                    Console.WriteLine("Music is off");
                    break;
                default:
                    StartUI.error();
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }

            return true;
        }
    }
}