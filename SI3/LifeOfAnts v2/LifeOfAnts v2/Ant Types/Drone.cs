using System;

namespace LifeOfAnts_v2
{
    public class Drone : Ant
    {
        public override char Symbol { get; }
        public override Position Coordinates { get; set; }
        private int MatingCountdown;

        public Drone()
        {
            this.Symbol = 'D';
            this.Coordinates = Helper.GenerateRandomCoordinates();
            MatingCountdown = 0;
        }

        public override void Move()
        {
            if (MatingCountdown == 0)
            {
                if (Helper.IsCloseEnoughToQueen(Coordinates))
                {
                    TryMate(Helper.Queen);
                }
                else
                {
                    MoveTowardsTheQueen();
                }
            }
            else
            {
                MatingCountdown--;
                if (MatingCountdown == 0)
                {
                    GetThrownAway();
                }
            }
        }

        private void TryMate(Queen queen)
        {
            if (queen.ReadyToMate)
            {
                Console.WriteLine("HALLELUJAH!!! A drone has successfully convinced the queen to mate with him.");
                StartMating();
            }

            else
            {
                Console.WriteLine("A Drone tried to mate with the Queen but got kicked away. :(");
                Coordinates = Helper.GenerateRandomCoordinates();
            }
        }

        private void StartMating()
        {
            Helper.Queen.Mate();
            MatingCountdown = 10;
        }

        private void MoveTowardsTheQueen()
        {
            if (Coordinates.X < Helper.QueenLocation.X)
            {
                Coordinates = new Position(Coordinates.X + 1, Coordinates.Y);
            }
            else if (Coordinates.X > Helper.QueenLocation.X)
            {
                Coordinates = new Position(Coordinates.X - 1, Coordinates.Y);
            }
            else if (Coordinates.Y < Helper.QueenLocation.Y)
            {
                Coordinates = new Position(Coordinates.X, Coordinates.Y + 1);
            }
            else
            {
                Coordinates = new Position(Coordinates.X, Coordinates.Y - 1);
            }
        }

        private void GetThrownAway()
        {
            Direction direction = Helper.GenerateRandomDirection();
            Console.WriteLine($"A Drone has finished mating with the queen and has been trown away into the {direction} direction.");
            if (direction == Direction.East)
            {
                Coordinates = new Position(Helper.MapSize/2, Helper.MapSize-1);
            }
            else if (direction == Direction.West)
            {
                Coordinates = new Position(Helper.MapSize/2, 0);
            }
            else if (direction == Direction.North)
            {
                Coordinates = new Position(0, Helper.MapSize/2);
            }
            else if (direction == Direction.South)
            {
                Coordinates = new Position(Helper.MapSize-1, Helper.MapSize/2);
            }
        }
    }
}