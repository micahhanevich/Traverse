using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Traverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.EvHandler.Intro();

            while (Game.IO.LastInput != "quit")
            {
                Game.EvHandler.GenericTurn();
            }

            Game.Close();
        }
    }
}
