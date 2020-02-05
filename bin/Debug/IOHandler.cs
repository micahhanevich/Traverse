using System;
using System.Linq;
using System.Threading;

namespace Traverse
{
    public class IOHandler
    {
        public string LastInput { get; set; }
        public string[] LastOutput { get; set; }
        public static char[] Seperators { get; set; }

        // Handles dynamic commands and what they do

        public IOHandler()
        {
            Seperators = new char[] { ' ' };
        }
        public IOHandler(char[] seperators)
        {
            Seperators = seperators;
        }

        public void Process(string input, bool enableCommandHandling = true)
        {
            if (!Game.History) { Console.Clear(); }
            input = input.ToLower();
            LastInput = input;

            string[] splitInput = input.Split(Seperators);

            LastOutput = splitInput;

            for (int i = 0; i < splitInput.Length; i++)
            {
                if (Game.DebugMode) Print($" # {i}: [{splitInput[i]}]");
            }

            if (Game.Commands.Contains(LastOutput[0]) && enableCommandHandling) Game.EvHandler.CommandEvent(LastOutput);
            else if (enableCommandHandling) Print(" Invalid Command. (use ? or help)");
        }

        public void Print(string text, ConsoleColor color = ConsoleColor.White, bool startline = true, int newlines = 1)
        {
            Console.ForegroundColor = color;
            if (startline) { Console.Write("\n"); }
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                if (text[i] == '.') { Thread.Sleep(Game.TextSpeedInt / 2); }
                else if (text[i] != ' ' && text[i] != '[' && text[i] != ']') { Thread.Sleep(Game.TextSpeedInt); }
            }
            for (int i = 0; i < newlines; i++ ) { Console.Write("\n"); }
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public string Read()
        {
            Console.Write("\n > ");
            return Console.ReadLine();
        }
    }
}
