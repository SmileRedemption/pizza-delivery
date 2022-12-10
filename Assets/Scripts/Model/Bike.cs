using UnityEngine;

namespace Model
{
    public class Bike : Transformable, IMove
    {
        public IHealth Health { get; }

        public Bike(Vector3 position, IHealth health) : base(position)
        {
            Health = health;
        }

        public void Move(Vector3 position)
        {
            MoveTo(position);
        }
    }
}