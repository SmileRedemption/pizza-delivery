using System;
using System.Collections.Generic;
using System.Linq;
using Movement;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class BikeView : View
    {
        [SerializeField] private PizzaView[] _pizzas;
        private PhysicsMovement _movement;
        
        public event Action<Vector3> Moved;
        public event Action<float> CollidedWithCar;
        public event Action BikeDestroyed;

        private void Awake()
        {
            _movement = GetComponent<PhysicsMovement>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out CarView carView))
            {
                CollidedWithCar?.Invoke(carView.Damage);
            }
        }

        public void MovePosition(Vector3 direction, bool canSpeedUp)
        {
            _movement.Move(direction, canSpeedUp);
            Moved?.Invoke(Position);
        }

        public void TurnOffPizza()
        {
            _pizzas.FirstOrDefault(pizza => pizza.gameObject.activeSelf)?.TurnOff();
        }

        public void DestroyBike()
        {
            BikeDestroyed?.Invoke();
        }
    }
}