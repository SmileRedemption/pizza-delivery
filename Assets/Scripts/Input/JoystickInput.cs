using System;
using Model;
using UnityEngine;
using View;

namespace Input
{
    [RequireComponent(typeof(BikeView))]
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private BikeView _bike;

        private void Awake()
        {
            _bike = GetComponent<BikeView>();
        }

        private void FixedUpdate()
        {
            var horizontal = _joystick.Horizontal; 
            var vertical = _joystick.Vertical;
            var direction = new Vector3(horizontal, 0, vertical);
            
            _bike.MovePosition(direction, CanSpeedUp(direction));
        }
        
        private bool CanSpeedUp(Vector3 direction)
        {
            var spreadToSpeedUp = 0.1;
            return Math.Abs(direction.z - 1) < spreadToSpeedUp;
        }
    }
}