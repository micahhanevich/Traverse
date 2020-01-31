using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    static class Game
    {
        public static string[] Commands { get; } = new string[] { "help", "?", "where", "go", "set", "quit" };

        public static string[] Biomes { get; } = new string[] { "forest", "desert", "mountain" };

        public enum MapSizes { Small, Medium, Large };

        public enum TextSpeeds { Slow, Normal, Fast, Instant };

        public enum Discoverables { Item, Creature, Structure };

        public static IOHandler IO = new IOHandler();

        public static EventHandler EvHandler = new EventHandler();

        public static Random RNG = new Random();

        public static RNGHandler RNGHandler = new RNGHandler();

        public static Player Player = new Player();

        // -------------------------------------------------------

        public static MapSizes MapSize;

        public static TextSpeeds TextSpeed;

        public static int TextSpeedInt;

        public static Location[,] Map;

        public static bool DebugMode = false;

        public static void Close()
        {
            Print("Press Any Key to Close...", true, 0);
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Print(string text, bool startline = true, int newlines = 2)
        {
            IO.Print(text, startline, newlines);
        }

        public static string Read()
        {
            return IO.Read();
        }
    }
}
