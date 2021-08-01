namespace LifeOfAnts_v2
{
    public class Soldier : Ant
    {
        public override char Symbol { get; }
        public override Position Coordinates { get; set; }
        private Direction _lastDirection;
        
        public Soldier()
        {
            this.Symbol = 'S';
            this.Coordinates = Helper.GenerateSoldierCoordinates();
            _lastDirection = Helper.GenerateRandomDirection();
        }

        public override void Move()
        {
            Direction leftDirection = WhatDirectionIsOnLeft(_lastDirection);
            Coordinates = Helper.MoveInDirection(Coordinates, leftDirection);
            _lastDirection = leftDirection;
        }

        private Direction WhatDirectionIsOnLeft(Direction currentDirection)
        {
            return currentDirection switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                _ => Direction.North
            };
        }
    }
}