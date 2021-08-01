using System;

namespace LifeOfAnts_v2
{
    public class Queen : Ant

    {
        public override char Symbol { get; }
        public override Position Coordinates { get; set; }
        private int Countdown;
        public bool ReadyToMate;

        public Queen(int mapSize)
        {
            this.Coordinates = new Position(mapSize / 2, mapSize / 2);
            this.Symbol = 'Q';
            Helper.QueenLocation = Coordinates;
            ReadyToMate = true;
            Countdown = 0;
        }

        public void Mate()
        {
            Countdown = new Random().Next(50, 100);
        }

        public void DoQueenThings()
        {
            Console.WriteLine(Countdown);
            if (Countdown > 0)
            {
                Countdown--;
                ReadyToMate = false;
            }

            if (Countdown == 0)
            {
                ReadyToMate = true;
            }
        }
        
        
    }
}