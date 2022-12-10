using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using View.UI;

namespace View
{
    public class CustomerView : View
    {
        [SerializeField] private PizzaView _pizzaView;
        private IEnumerable<Star> _stars;
        
        public event Action CollidedWithBike;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out BikeView bike))
            {
                bike.TurnOffPizza();
                _pizzaView.gameObject.SetActive(true);
                CollidedWithBike?.Invoke();
            }
        }

        public void OnPizzaAdded()
        {
            var star = _stars.First(star => star.IsActive == false);
            star.TurnOn();
        }

        public void Init(Star[] stars)
        {
            _stars = stars;
        }
    }
}