using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class RNGHandler
    {
        public Choice LastChoice = null;
        public Location[] BiomePossibilities;

        public RNGHandler()
        {
            List<Location> exArray = new List<Location>();

            for (int i = 0; i < Game.Biomes.Length; i++)
            {
                switch (Game.Biomes[i])
                {
                    case ("forest"):
                        exArray.Add(new Forest(0));
                        break;
                    case ("desert"):
                        exArray.Add(new Desert(0));
                        break;
                    case ("mountain"):
                        exArray.Add(new Mountain(0));
                        break;
                    case ("plains"):
                        exArray.Add(new Plains(0));
                        break;
                    case ("lake"):
                        exArray.Add(new Lake(0));
                        break;
                    case ("sforest"):
                        exArray.Add(new SnowForest(0));
                        break;
                    case ("splains"):
                        exArray.Add(new SnowPlains(0));
                        break;
                    case ("slake"):
                        exArray.Add(new FrozenLake(0));
                        break;
                }
            }

            BiomePossibilities = exArray.ToArray();
        }

        public Location GenBiome()
        {
            double seed = Game.RNG.NextDouble();

            double total = 0;

            for (int i = 0; i < BiomePossibilities.Length; i++)
            {                
                total += BiomePossibilities[i].PlChance;
            }

            seed *= total;

            double lastval = 0.00;

            for (int i = 0; i < BiomePossibilities.Length; i++)
            {
                if (seed >= lastval && seed < BiomePossibilities[i].PlChance + lastval)
                {
                    return BiomePossibilities[i].Copy(seed);
                }
                lastval += BiomePossibilities[i].PlChance;
            }
            throw new Exception($"Seed outside of possible biome range. #{seed} ; #{lastval}");
        }


    }
}