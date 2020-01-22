﻿using System;
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
                case "go":
                    Go();
                    break;
                case "set":
                    Set();
                    break;
            }
        }

        public void GenericTurn()
        {
            Game.Print("What do you do?");
            Game.IO.Process(Game.Read());
        }

        private void Help()
        {
            Game.Print("Available Commands:\n" +
                " Help [?]       - Prints this help menu\n" +
                " Where          - Gives you information about your surroundings\n" +
                " Go <direction> - Moves you in a direction. [North, South, East, West]\n" +
                " Set <value>    - Sets a background value.");
        }
        private void Where()
        {
            Game.Print($"You are in a {Game.Player.Location.Biome.ToUpper()}");
        }
        private void Go()
        {
            try
            {
                Game.Print($" You moved {Game.IO.LastOutput[1].ToUpper()}.");
            }
            catch { Game.Print("You moved."); }
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
                                        Game.Print($" Text Speed is now set to {Game.TextSpeed.ToString().ToLower()}.");
                                    }
                                    catch { Game.Print(" Please provide the desired text speed."); }
                                    break;
                            }
                        }
                        catch { Game.Print(" Please provide which text value you want to change."); }

                        break;
                    case "textspeed":
                    case "txtspd":
                        try
                        {
                            SetTextSpeed(Game.IO.LastOutput[2]);
                            Game.Print($" Text Speed is now set to {Game.TextSpeed.ToString().ToLower()}.");
                        }
                        catch { Game.Print(" Please provide the desired text speed."); }
                        break;
                }
            }
            catch { Game.Print(" Please enter a second parameter if using Set."); }
        }

        public void Intro()
        {
            GetTextSpeed();
            GetMapSize();

            InitializeMap();

            Console.Clear();
            StartGame();
        }

        private void GetTextSpeed()
        {
            Game.IO.Print("How quickly would you like text to print? (Slow, Normal, Fast, Instant)");
            Game.IO.Process(Game.Read(), false);

            while (Game.IO.LastInput != "slow" && Game.IO.LastInput != "normal" && Game.IO.LastInput != "fast" && Game.IO.LastInput != "instant"
                   && Game.IO.LastInput != "s" && Game.IO.LastInput != "n" && Game.IO.LastInput != "f" && Game.IO.LastInput != "i")
            {
                if (Game.IO.LastOutput.Contains("debug"))
                {
                    Game.DebugMode = !Game.DebugMode;
                    Game.IO.Print($"Debug Mode: {Game.DebugMode}");
                }
                Game.IO.Print("Please enter Slow, Normal, Fast, or Instant");
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
                    Game.TextSpeedInt = 25;
                    break;
                case "normal":
                case "n":
                    Game.TextSpeed = Game.TextSpeeds.Normal;
                    Game.TextSpeedInt = 15;
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
            }
        }

        private void GetMapSize()
        {
            Game.IO.Print("How large would you like the map? (Small, Medium, Large)");
            Game.IO.Process(Game.Read(), false);

            while (Game.IO.LastInput != "small" && Game.IO.LastInput != "medium" && Game.IO.LastInput != "large" 
                   && Game.IO.LastInput != "s" && Game.IO.LastInput != "m" && Game.IO.LastInput != "l")
            {
                if (Game.IO.LastInput.Contains("debug"))
                {
                    Game.DebugMode = !Game.DebugMode;
                    Game.IO.Print($"Debug Mode: {Game.DebugMode}");
                }
                Game.IO.Print("Please enter Small, Medium, or Large.");
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
                    Game.IO.Print("MapSize error occured. Please restart your game.");
                    Game.MapSize = Game.MapSizes.Large;
                    break;
            }

            Game.Print($"Map Size Selected: {Game.MapSize}");
            Game.Print("Press any key to continue...", false, 0);
            Console.ReadKey();
        }

        private void InitializeMap()
        {
            Location startingLoc = new Location("forest");
            Game.Player.Location = startingLoc;

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
                "You Look around, and see trees as far as the eye can see.");
        }
    }
}