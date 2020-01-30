using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class RNGHandler
    {
        Location[] BiomePossibilities;

        public RNGHandler()
        {

            Location[] exArray = new Location[8];

            for (int i = 0; i < Game.Biomes.Length; i++)
            {
                switch (Game.Biomes[i])
                {
                    case ("forest"):
                        exArray.Append(new Forest());
                        break;
                    case ("desert"):
                        exArray.Append(new Desert());
                        break;
                    case ("mountain"):
                        exArray.Append(new Mountain());
                        break;
                    case ("plains"):
                        exArray.Append(new Plains());
                        break;
                    case ("lake"):
                        exArray.Append(new Lake());
                        break;
                    case ("sforest"):
                        exArray.Append(new SnowForest());
                        break;
                    case ("splains"):
                        exArray.Append(new SnowPlains());
                        break;
                    case ("slake"):
                        exArray.Append(new FrozenLake());
                        break;
                }
            }
        }

        public Location GenerateRandomBiome()
        {
            Location ChosenBiome = new Forest();



            return ChosenBiome;
        }

    }
}
