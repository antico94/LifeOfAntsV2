using System;

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
            Position newCoordinates = Helper.MoveInDirection(Coordinates, leftDirection);
            if (Helper.IsPositionEmpty(newCoordinates))
            {
                Coordinates = newCoordinates;
                _lastDirection = leftDirection;
            }
            else
            {
                Relocate();
            }

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

        private void Relocate()
        {
            Console.WriteLine("A soldier has been relocated.");
            Coordinates = Helper.GenerateSoldierCoordinates();
        }
    }
}