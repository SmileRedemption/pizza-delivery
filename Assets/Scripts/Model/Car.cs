using UnityEngine;

namespace Model
{
    public class Car : Transformable, IMove
    {
        public Car(Vector3 position) : base(position)
        {
        }

        public void Move(Vector3 position)
        {
            MoveTo(position);
        }
    }
}