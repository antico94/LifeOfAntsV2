using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LifeOfAnts_v2
{
    public class AntColony
    {
        private List<List<char>> _map = new List<List<char>>();
        public List<Ant> Ants = new List<Ant>();

        public AntColony(int width)
        {
            for (int i = 0; i < width; i++)
            {
                List<char> Sublist = new List<char>();
                for (int j = 0; j < width; j++)
                {
                    Sublist.Add(' ');
                }

                _map.Add(Sublist);
            }

            GenerateQueen();
            Helper.MapSize = width;
        }

        public void GenerateAnts(int drones, int workers, int soldiers)
        {
            for (int i = 0; i < drones; i++)
            {
                Ants.Add(new Drone());
            }

            for (int i = 0; i < workers; i++)
            {
                Ants.Add(new Worker());
            }

            for (int i = 0; i < soldiers; i++)
            {
                Ants.Add(new Soldier());
            }

            Helper.Ants = Ants;
        }

        private void GenerateQueen()
        {
            Queen queen = new Queen(_map.Count);
            Helper.Queen = queen;
            Ants.Add(queen);
        }

        public void DisplayMap()
        {
            var delimiter = String.Concat(Enumerable.Repeat("-----", _map.Count-1));
            
            for (int i = 0; i < _map.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine(delimiter);
                for (int j = 0; j < _map.Count; j++)
                {

                    bool completed = false;
                    foreach (var ant in Ants)
                    {
                        if (ant.Coordinates.X == i && ant.Coordinates.Y == j)
                        {
                            Console.Write($"{ant.Symbol}    ");
                            completed = true;
                        }
                    }

                    if (!completed)
                    {
                        Console.Write("|    ");
                    }
                }
            }
        }
    }
}