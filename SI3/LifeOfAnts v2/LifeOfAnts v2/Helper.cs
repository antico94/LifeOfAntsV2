using System;

namespace LifeOfAnts_v2
{
    public static class Helper
    {
        public static int MapSize;
        public static Position QueenLocation;
        public static Queen Queen;

        public static Position GenerateRandomCoordinates()
        {
            return new Position(new Random().Next(0, MapSize - 1), new Random().Next(0, MapSize - 1));
        }

        public static Position GenerateSoldierCoordinates()
        {
            return new Position(new Random().Next(1, MapSize-2), new Random().Next(1, MapSize-2));
        }

        public static bool IsCoordinateValid(Position coordinates)
        {
            return (coordinates.X >= 0 && coordinates.X < MapSize) && (coordinates.Y >= 0 && coordinates.Y < MapSize);
        }

        public static Position MoveInDirection(Position coordinates, Direction direction)
        {
            return direction switch
            {
                Direction.East => new Position(coordinates.X - 1, coordinates.Y),
                Direction.West => new Position(coordinates.X + 1, coordinates.Y),
                Direction.North => new Position(coordinates.X, coordinates.Y + 1),
                Direction.South => new Position(coordinates.X, coordinates.Y - 1),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "It cannot occur.")
            };
        }

        public static Direction GenerateRandomDirection()
        {
            Random random = new Random();
            Type type = typeof(Direction);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);
            Direction value = (Direction)values.GetValue(index);
            
            return value;
        }
    }
}