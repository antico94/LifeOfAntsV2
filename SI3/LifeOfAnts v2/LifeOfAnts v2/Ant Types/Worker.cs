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
            var randomDirection = Helper.GenerateRandomDirection();
            Coordinates = Helper.MoveInDirection(Coordinates, randomDirection);
        }
    }
}