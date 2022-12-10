using System;
using UnityEngine;

namespace Model
{
    public abstract class Transformable
    {
        public Vector3 Position { get; protected set; }

        protected Transformable(Vector3 position)
        {
            Position = position;
        }

        protected void MoveTo(Vector3 position)
        {
            Position = position;
        }
    }
}