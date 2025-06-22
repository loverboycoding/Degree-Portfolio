using static MiNET.Entities.Entity;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;
        private Direction _direction;
        public enum Direction
        {
            North,
            South,
            East,
            West,
          
        }
        public Path(Direction direction, Location destination)
            : base(new string[] { direction.ToString().ToLower() }, direction.ToString(), $"A path to the {direction}")
        {
            _direction = direction;
            _destination = destination;
        }

        public Location Destination => _destination;

        public Direction direction => _direction;
    }
}

