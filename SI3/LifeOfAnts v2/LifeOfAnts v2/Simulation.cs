using System;

namespace LifeOfAnts_v2
{
    public static class Simulation
    {
        public static void Start()
        {
            var antColony = new AntColony(11);
            antColony.GenerateAnts(4, 4 , 4);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Input");
                string userInput = Console.ReadLine();
                if (userInput == String.Empty)
                {
                    foreach (var ant in antColony.Ants)
                    {
                        ant.Move();
                    }
                    Helper.Queen.DoQueenThings();

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