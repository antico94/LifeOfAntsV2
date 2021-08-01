namespace LifeOfAnts_v2
{
    public class Worker : Ant
    {
        public override char Symbol { get; }
        public override Position Coordinates { get; set; }
        
        public Worker()
        {
            this.Symbol = 'W';
            this.Coordinates = Helper.GenerateRandomCoordinates();
        }

        public override void Move()
        {
            while (true)
            {
                var randomDirection = Helper.GenerateRandomDirection();
                var newCoordinates = Helper.MoveInDirection(Coordinates, randomDirection);
                if (Helper.IsCoordinateValid(newCoordinates) && Helper.IsPositionEmpty(newCoordinates))
                {
                    Coordinates = newCoordinates;
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}