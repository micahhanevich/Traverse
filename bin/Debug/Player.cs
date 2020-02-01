using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class Player
    {
        public Location Location { get; set; }

        public int[] GridLoc { get; set; }

        // public Item[] Inventory

        public Player()
        {
            
        }

        public void Move(Game.Directions heading)
        {
            int[] targetLoc;

            switch (heading)
            {
                case Game.Directions.N:

                    if (GridLoc[1] <= 0) { targetLoc = new int[] { GridLoc[0], Game.Map.GetLength(1) - 1 }; }
                    else { targetLoc = new int[] { GridLoc[0], GridLoc[1] - 1 }; }

                    GridLoc[0] = targetLoc[0]; GridLoc[1] = targetLoc[1];
                    Location = Game.Map[GridLoc[0], GridLoc[1]];

                    if (Location == null)
                    { 
                        Game.Map[GridLoc[0], GridLoc[1]] = Game.RNGHandler.GenBiome(); 
                        Location = Game.Map[GridLoc[0], GridLoc[1]]; 
                    }

                    break;
                case Game.Directions.S:
                    break;
                case Game.Directions.E:
                    break;
                case Game.Directions.W:
                    break;
            }
        }
    }
}