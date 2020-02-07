using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class Choice
    {
        double Weight { get; }
        double Seed { get; }
        string Text { get; }

        public Choice(double weight)
        {
            Weight = weight;
            Seed = Game.RNG.NextDouble();
            Text = null;
        }
        public Choice(double weight, double seed)
        {
            Weight = weight;
            Seed = seed;
            Text = null;
        }
        public Choice(double weight, string text)
        {
            Weight = weight;
            Seed = Game.RNG.NextDouble();
            Text = text;
        }
        public Choice(double weight, double seed, string text)
        {
            Weight = weight;
            Seed = seed;
            Text = text;
        }
    }
}
