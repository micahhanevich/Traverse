using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class EventHandler
    {
        public void CommandEvent(string[] parsedcommand)
        {
            switch (parsedcommand[0])
            {
                case "help":
                case "?":
                    Help();
                    break;
                case "where":
                    Where();
                    break;
                case "map":
                    Map();
                    break;
                case "go":
                    Go();
                    break;
                case "set":
                    Set();
                    break;
                case "test":
                    if (!Game.DebugMode) { Game.Print($"Invalid Command. (use ? or help)"); break; }
                    Test();
                    break;
            }
        }

        public void GenericTurn()
        {
            Game.Print("What do you do?");
            Game.IO.Process(Game.Read());
            if (Game.DebugMode) { Game.Print($"Time is {Game.Time}"); }
            Game.Print("O\\--o---o---o--/O\\--o---o---o--/O", ConsoleColor.Gray);
        }

        private void Help()
        {
            Game.Print("Available Commands:\n" +
                " Help [?]       - Prints this help menu\n" +
                " Where          - Gives you information about your surroundings\n" +
                " Map <type>     - Shows a map; either world or area\n" +
                " Go <direction> - Moves you in a direction. (N|S|E|W)\n" +
                " Set <param>    - Sets a background parameter's value.\n" +
                " Quit           - Quits the game.", ConsoleColor.Red);
        }

        private void Where()
        {
            Game.Print($"You are in a {Game.Player.Location.PrintName.ToUpper()}");

            if (Game.DebugMode)
            {
                Map();
            }
        }

        private void Map()
        {
            Game.Print("\n", ConsoleColor.Black, false, 0);
            for (int i = 0; i < Game.Map.GetLength(0); i++)
            {
                for (int j = 0; j < Game.Map.GetLength(1); j++)
                {
                    if (Game.Player.GridLoc[0] == j && Game.Player.GridLoc[1] == i) 
                    { 
                        Game.Print("[", ConsoleColor.Gray, false, 0);
                        Game.Print("x", ConsoleColor.Blue, false, 0);
                        Game.Print("]", ConsoleColor.Gray, false, 0);
                    }
                    else if (Game.Map[j, i] is null) { Game.Print("[?]", ConsoleColor.Black, false, 0); }
                    else if (Game.Map[j, i] is Forest) { Game.Print("[F]", ConsoleColor.Gray, false, 0); }
                    else if (Game.Map[j, i] is Desert) { Game.Print("[D]", ConsoleColor.Gray, false, 0); }
                    else if (Game.Map[j, i] is Mountain) { Game.Print("[M]", ConsoleColor.Gray, false, 0); }
                }
                Game.Print("\n", ConsoleColor.Black, false, 0);
            }
        }

        private void Go()
        {
            try
            {
                switch (Game.IO.LastOutput[1])
                {
                    case "north":
                    case "n":
                        Game.Player.Move(Game.Directions.N);
                        Game.Print("Moved North...", ConsoleColor.White, true, 1);
                        break;
                    case "south":
                    case "s":
                        Game.Player.Move(Game.Directions.S);
                        Game.Print("Moved South...", ConsoleColor.White, true, 1);
                        break;
                    case "east":
                    case "e":
                        Game.Player.Move(Game.Directions.E);
                        Game.Print("Moved East", ConsoleColor.White, true, 1);
                        break;
                    case "west":
                    case "w":
                        Game.Player.Move(Game.Directions.W);
                        Game.Print("Moved West", ConsoleColor.White, true, 1);
                        break;
                    default:
                        throw new Exception();
                }

                Where();
                Game.Time += 3;
            }
            catch { Game.Print(" Please provide a valid direction to move in. (N|S|E|W)", ConsoleColor.Red); }
        }

        private void Set()
        {
            try
            {
                switch (Game.IO.LastOutput[1])
                {
                    case "text":

                        try
                        {
                            switch (Game.IO.LastOutput[2])
                            {
                                case "speed":
                                case "spd":
                                    try
                                    {
                                        SetTextSpeed(Game.IO.LastOutput[3]);
                                        Game.Print($" Text Speed is now set to {Game.TextSpeed.ToString().ToLower()}.", ConsoleColor.Yellow);
                                    }
                                    catch { Game.Print(" Please provide the desired text speed.", ConsoleColor.Red); }
                                    break;
                            }
                        }
                        catch { Game.Print(" Please provide which text value you want to change.", ConsoleColor.Red); }
                        break;
                    case "textspeed":
                    case "txtspd":
                        try
                        {
                            SetTextSpeed(Game.IO.LastOutput[2]);
                            Game.Print($" Text Speed is now set to {Game.TextSpeed.ToString().ToLower()}.", ConsoleColor.Yellow);
                        }
                        catch { Game.Print(" Please provide the desired text speed.", ConsoleColor.Red); }
                        break;

                    case "biome":
                    case "loctype":
                        if (!Game.DebugMode) { Game.Print($" Invalid Second Parameter: {Game.IO.LastOutput[1]}", ConsoleColor.Red); break; }

                        try
                        {
                            switch (Game.IO.LastOutput[2])
                            {
                                case "forest":
                                    Game.Player.Location = new Forest(Game.RNG.NextDouble());
                                    break;
                                case "desert":
                                    Game.Player.Location = new Desert(Game.RNG.NextDouble());
                                    break;
                                case "mountain":
                                    Game.Player.Location = new Mountain(Game.RNG.NextDouble());
                                    break;
                                default:
                                    throw new Exception();
                            }
                            Where();
                        }
                        catch { Game.Print(" Please provide a valid biome.", ConsoleColor.Red); }
                        break;
                    case "debug":
                        Game.DebugMode = !Game.DebugMode;
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch { Game.Print(" Please enter a valid second parameter.", ConsoleColor.Red); }
        }

        private void Test()
        {
            try
            {
                switch (Game.IO.LastOutput[1])
                {
                    case "genbiome":
                        var outvar = Game.RNGHandler.GenBiome();
                        Game.Print($" Test [genbiome] Results\n" +
                            $" # {{{outvar.PrintName}}}\n" +
                            $" # {{{outvar.Seed.ToString()}}}", ConsoleColor.Yellow, true, 1);
                        break;
                    case "gridloc":
                        Game.Print($" Test [gridloc] Results\n" +
                            $" # {{x: {Game.Player.GridLoc[0]}}}\n" +
                            $" # {{y: {Game.Player.GridLoc[1]}}}", ConsoleColor.Yellow, true, 1);
                        break;
                    case "debug":
                        Game.Print(" Test [debug] Results\n" +
                            $" # {{{Game.DebugMode}}}", ConsoleColor.Yellow, true, 1);
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch { Game.Print(" Please provide a valid testable function.", ConsoleColor.Red); }
        }

        public void Intro()
        {
            SetHistory();
            GetTextSpeed();
            GetMapSize();

            InitializeMap();

            double mapLength = Game.Map.Length;
            Game.Player.GridLoc = new int[] { (int)(Math.Sqrt(mapLength) / 2), (int)(Math.Sqrt(mapLength) / 2) };
            Location startingLoc = new Forest(Game.RNG.NextDouble());
            Game.Player.Location = startingLoc;
            Game.Map[Game.GetPlayerPos('x'), Game.GetPlayerPos('y')] = startingLoc;

            Console.Clear();
            StartGame();
        }

        private void SetHistory()
        {
            Game.Print(" Would you like to see your command history? (Y/N)", ConsoleColor.Gray);
            Game.IO.Process(Game.Read(), false);

            while (Game.IO.LastInput != "y" && Game.IO.LastInput != "n" && Game.IO.LastInput != "yes" && Game.IO.LastInput != "no")
            {
                if (Game.IO.LastOutput.Contains("debug"))
                {
                    Game.DebugMode = !Game.DebugMode;
                    Game.Print($" Debug Mode: {Game.DebugMode}", ConsoleColor.Yellow);
                }
                Game.Print(" Please enter Y for yes or N for no.", ConsoleColor.Red);
                Game.IO.Process(Game.Read(), false);
            }

            if (Game.IO.LastInput == "y" || Game.IO.LastInput == "yes") { Game.History = true; }
            else { Game.History = false; }
        }

        private void GetTextSpeed()
        {
            Game.Print(" How quickly would you like text to print? (Slow, Normal, Fast, Instant)", ConsoleColor.Gray);
            Game.IO.Process(Game.Read(), false);

            while (Game.IO.LastInput != "slow" && Game.IO.LastInput != "normal" && Game.IO.LastInput != "fast" && Game.IO.LastInput != "instant"
                   && Game.IO.LastInput != "s" && Game.IO.LastInput != "n" && Game.IO.LastInput != "f" && Game.IO.LastInput != "i")
            {
                if (Game.IO.LastOutput.Contains("debug"))
                {
                    Game.DebugMode = !Game.DebugMode;
                    Game.Print($" Debug Mode: {Game.DebugMode}", ConsoleColor.Yellow);
                }
                Game.Print(" Please enter Slow, Normal, Fast, or Instant", ConsoleColor.Red);
                Game.IO.Process(Game.Read(), false);
            }

            SetTextSpeed(Game.IO.LastInput);
        }

        private void SetTextSpeed(string switcher)
        {
            switch (switcher)
            {
                case "slow":
                case "s":
                    Game.TextSpeed = Game.TextSpeeds.Slow;
                    Game.TextSpeedInt = 35;
                    break;
                case "normal":
                case "n":
                    Game.TextSpeed = Game.TextSpeeds.Normal;
                    Game.TextSpeedInt = 25;
                    break;
                case "fast":
                case "f":
                    Game.TextSpeed = Game.TextSpeeds.Fast;
                    Game.TextSpeedInt = 5;
                    break;
                case "instant":
                case "i":
                    Game.TextSpeed = Game.TextSpeeds.Instant;
                    Game.TextSpeedInt = 0;
                    break;
                default:
                    break;
            }
        }

        private void GetMapSize()
        {
            Game.Print(" How large would you like the map? (Small, Medium, Large)", ConsoleColor.Gray);
            Game.IO.Process(Game.Read(), false);

            while (Game.IO.LastInput != "small" && Game.IO.LastInput != "medium" && Game.IO.LastInput != "large" 
                   && Game.IO.LastInput != "s" && Game.IO.LastInput != "m" && Game.IO.LastInput != "l")
            {
                if (Game.IO.LastInput.Contains("debug"))
                {
                    Game.DebugMode = !Game.DebugMode;
                    Game.Print($" Debug Mode: {Game.DebugMode}", ConsoleColor.Yellow);
                }
                Game.Print(" Please enter Small, Medium, or Large.", ConsoleColor.Red);
                Game.IO.Process(Game.Read(), false);
            }

            switch (Game.IO.LastInput)
            {
                case "small":
                case "s":
                    Game.MapSize = Game.MapSizes.Small;
                    break;
                case "medium":
                case "m":
                    Game.MapSize = Game.MapSizes.Medium;
                    break;
                case "large":
                case "l":
                    Game.MapSize = Game.MapSizes.Large;
                    break;
                default:
                    Game.Print(" MapSize error occured. Please restart your game.", ConsoleColor.DarkRed);
                    Game.MapSize = Game.MapSizes.Large;
                    break;
            }

            Game.Print($" Map Size Selected: {Game.MapSize}", ConsoleColor.Gray);
            Game.Print("Press any key to continue...", ConsoleColor.Yellow, false, 0);
            Console.ReadKey();
        }

        private void InitializeMap()
        {
            switch (Game.MapSize)
            {
                case Game.MapSizes.Small:
                    Game.Map = new Location[11,11];
                    break;
                case Game.MapSizes.Medium:
                    Game.Map = new Location[19,19];
                    break;
                case Game.MapSizes.Large:
                    Game.Map = new Location[31, 31];
                    break;
            }
        }

        private void StartGame()
        {
            Game.Print("You awake to light filtering through leaves above you.\n" +
                "You lie on the top of a small hill in some woods.\n" +
                "You Look around, and see trees as far as the eye can see.", ConsoleColor.Cyan);
        }
    }
}
