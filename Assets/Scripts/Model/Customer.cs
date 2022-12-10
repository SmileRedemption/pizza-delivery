using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Customer : Transformable
    {
        private Pizza _pizza;

        public event Action PizzaAdded;

        public Customer(Vector3 position) : base(position)
        {
            
        }

        public void SetPizza(Pizza pizza)
        {
            if (_pizza == null)
            {
                _pizza = pizza;
                PizzaAdded?.Invoke();
            }
        }
    }
}