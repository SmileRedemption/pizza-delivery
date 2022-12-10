using System;
using UnityEngine;

namespace View.UI
{
    public class Star : MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;

        public event Action TurnedOn;

        public void TurnOn()
        {
            gameObject.SetActive(true);
            TurnedOn?.Invoke();
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}