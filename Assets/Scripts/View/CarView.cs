using System;
using Movement;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class CarView : View
    {
        private float _damage = 1f;
        private PhysicsMovement _movement;
        
        public float Damage => _damage;
        
        public event Action<Vector3> Moved;

        private void Awake()
        {
            _movement = GetComponent<PhysicsMovement>();
        }

        private void FixedUpdate()
        {
            _movement.Move(Vector3.forward);
            Moved?.Invoke(Position);
        }
    }
}