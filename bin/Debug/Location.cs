using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    abstract class Location
    {
        public double Seed { get; set; }

        public string PrintName;
        public double TestChance;
        public double EqChance;
        public double PlChance;

        abstract public Location Copy(double seed);
    }

    class Forest : Location
    {
        public Forest(double seed)
        {
            Seed = seed;

            PrintName = "Forest";
            TestChance = 0.50;
            EqChance = 0.20;
            PlChance = 0.05;
        }

        public override Location Copy(double seed)
        {
            return new Forest(seed);
        }
    }

    class SnowForest : Location
    {
        public SnowForest(double seed)
        {
            Seed = seed;
            PrintName = "Snowy Forest";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.30;
        }

        public override Location Copy(double seed)
        {
            return new SnowForest(seed);
        }
    }

    class Desert : Location
    {
        public Desert(double seed)
        {
            Seed = seed;

            PrintName = "Desert";
            TestChance = 0.35;
            EqChance = 0.40;
            PlChance = 0.00;
        }

        public override Location Copy(double seed)
        {
            return new Desert(seed);
        }
    }

    class Mountain : Location
    {
        public Mountain(double seed)
        {
            Seed = seed;

            PrintName = "Mountain";
            TestChance = 0.15;
            EqChance = 0.10;
            PlChance = 0.20;
        }

        public override Location Copy(double seed)
        {
            return new Mountain(seed);
        }
    }

    class Plains : Location
    {
        public Plains(double seed)
        {
            Seed = seed;

            PrintName = "Plains";
            TestChance = 0.00;
            EqChance = 0.20;
            PlChance = 0.05;
        }

        public override Location Copy(double seed)
        {
            return new Plains(seed);
        }
    }

    class SnowPlains : Location
    {
        public SnowPlains(double seed)
        {
            Seed = seed;

            PrintName = "Snowy Plains";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.25;
        }

        public override Location Copy(double seed)
        {
            return new SnowPlains(seed);
        }
    }

    class Lake : Location
    {
        public Lake(double seed)
        {
            Seed = seed;

            PrintName = "Lake";
            TestChance = 0.00;
            EqChance = 0.10;
            PlChance = 0.00;
        }

        public override Location Copy(double seed)
        {
            return new Lake(seed);
        }
    }

    class FrozenLake : Location
    {
        public FrozenLake(double seed)
        {
            Seed = seed;

            PrintName = "Frozen Lake";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.15;
        }

        public override Location Copy(double seed)
        {
            return new FrozenLake(seed);
        }
    }
}