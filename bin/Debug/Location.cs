using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    abstract class Location
    {
        public string PrintName;
        public double TestChance;
        public double EqChance;
        public double PlChance;
    }

    class Forest : Location
    {
        public Forest()
        {
            PrintName = "Forest";
            TestChance = 0.50;
            EqChance = 0.20;
            PlChance = 0.05;
        }
    }

    class SnowForest : Location
    {
        public SnowForest()
        {
            PrintName = "Snowy Forest";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.30;
        }
    }

    class Desert : Location
    {
        public Desert()
        {
            PrintName = "Desert";
            TestChance = 0.35;
            EqChance = 0.40;
            PlChance = 0.00;
        }
    }

    class Mountain : Location
    {
        public Mountain()
        {
            PrintName = "Mountain";
            TestChance = 0.15;
            EqChance = 0.10;
            PlChance = 0.20;
        }
    }

    class Plains : Location
    {
        public Plains()
        {
            PrintName = "Plains";
            TestChance = 0.00;
            EqChance = 0.20;
            PlChance = 0.05;
        }
    }

    class SnowPlains : Location
    {
        public SnowPlains()
        {
            PrintName = "Snowy Plains";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.25;
        }
    }

    class Lake : Location
    {
        public Lake()
        {
            PrintName = "Lake";
            TestChance = 0.00;
            EqChance = 0.10;
            PlChance = 0.00;
        }
    }

    class FrozenLake : Location
    {
        public FrozenLake()
        {
            PrintName = "Frozen Lake";
            TestChance = 0.00;
            EqChance = 0.00;
            PlChance = 0.15;
        }
    }
}