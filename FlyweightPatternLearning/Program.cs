using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double longitude = 35.33;
            double latitude = 60.23;

            CampFactory campFactory = new CampFactory();
            for (int i = 0; i < 10; i++)
            {
                Camp goblinCamp = campFactory.GetCamps("Goblin");
                if (goblinCamp != null)
                    goblinCamp.Spawn(longitude, latitude);
                longitude += 2.1;
                latitude += (double)rand.Next(-10, 10);
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Camp banditCamp = campFactory.GetCamps("Bandit");
                if (banditCamp != null)
                    banditCamp.Spawn(longitude, latitude);
                longitude += (double)rand.Next(-5, 3);
                latitude += 0.7;
            }

            Console.Read();
        }
    }
    //flyweight
    abstract class Camp
    {
        protected int enemies; // count of enemies

        public abstract void Spawn(double longitude, double latitude);
    }
    //concrete flyweight
    class GoblinCamp : Camp
    {
        public GoblinCamp()
        {
            enemies = 25;
        }

        public override void Spawn(double longitude, double latitude)
        {
            Console.WriteLine("There was spawned goblin's camp with {0} enemies; координаты: {1} широты и {2} долготы",
                enemies, latitude, longitude);
        }
    }
    //concrete flyweight
    class BanditCamp : Camp
    {
        public BanditCamp()
        {
            enemies = 5;
        }

        public override void Spawn(double longitude, double latitude)
        {
            Console.WriteLine("There was spawned bandit's camp with {0} enemies; координаты: {1} широты и {2} долготы",
                enemies, latitude, longitude);
        }
    }

    //flyweight factory
    class CampFactory
    {
        Dictionary<string, Camp> camps = new Dictionary<string, Camp>();
        public CampFactory()
        {
            camps.Add("Goblin", new GoblinCamp());
            camps.Add("Bandit", new BanditCamp());
        }

        public Camp GetCamps(string key)
        {
            if (camps.ContainsKey(key))
                return camps[key];
            else
                return null;
        }
    }
}
