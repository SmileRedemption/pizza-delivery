using System;
using UnityEngine;

namespace View
{
    public class PizzaView : View
    {
        public void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}