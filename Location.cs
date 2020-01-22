using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class Location
    {
        public string Biome { get; } = Game.Biomes[Game.RNG.Next(Game.Biomes.Length)];

        public int[] Loc { get; set; }
        public Location(string biome)
        {
            if (Game.Biomes.Contains(biome)) Biome = biome;
        }
        public Location() { }
    }
}
