using System;
using UnityEngine;
using View;

namespace Movement
{
    public class NonRidingZone : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out BikeView bikeView))
            {
                bikeView.gameObject.SetActive(false);
                bikeView.DestroyBike();
            }
        }
    }
}