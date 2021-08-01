using System;

namespace LifeOfAnts_v2
{
    public static class Simulation
    {
        public static void Start()
        {
            var antColony = new AntColony(10);
            antColony.GenerateAnts(5, 5 , 5);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == String.Empty)
                {
                    foreach (var ant in antColony.Ants)
                    {
                        ant.Move();
                        Helper.Queen.DoQueenThings();
                    }

                    antColony.DisplayMap();
                }
                else if (userInput == "q")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}