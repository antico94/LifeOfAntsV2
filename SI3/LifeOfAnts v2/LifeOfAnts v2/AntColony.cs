using System;
using System.Collections.Generic;

namespace LifeOfAnts_v2
{
    public class AntColony
    {
        private List<List<char>> _map { get; }
        public List<Ant> Ants;
        
        public AntColony(int width)
        {
            for (int i = 0; i < width; i++)
            {
                _map.Add(new List<char>(width));
                for (int j = 0; j < width; j++)
                {
                    _map[i][j] = ' ';
                }
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
        }

        private void GenerateQueen()
        {
            Queen queen = new Queen(_map.Count);
            Helper.Queen = queen;
            Ants.Add(queen);
        }

        public void DisplayMap()
        {
            for (int i = 0; i < _map.Count; i++)
            {
                for (int j = 0; j < _map.Count; j++)
                {
                    Console.WriteLine("*");
                }
            }
        }
    }
}