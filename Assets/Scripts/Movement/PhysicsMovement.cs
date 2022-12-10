using System;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _speed;
    
        private Rigidbody _rigidbody;
        private float _defaultSpeed;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _defaultSpeed = _speed;
        }
    
        public void Move(Vector3 direction)
        {
            var directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            var offset = directionAlongSurface * _speed * Time.fixedDeltaTime;
            var newPosition = _rigidbody.position + offset;
        

            transform.LookAt(newPosition);
            _rigidbody.MovePosition(newPosition);
        }

        public void Move(Vector3 direction, bool isSpeedUp)
        {
            TrySpeedUp(isSpeedUp);

            var directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            var offset = directionAlongSurface * _speed * Time.fixedDeltaTime;
            var newPosition = _rigidbody.position + offset;
        

            transform.LookAt(newPosition);
            _rigidbody.MovePosition(newPosition);
        }

        private void TrySpeedUp(bool isSpeedUp)
        {
            if (isSpeedUp && _speed + 1 < _maxSpeed)
            {
                _speed += 1;
                return;
            }
        
            if (_speed > _defaultSpeed)
                _speed -= 1;
        }
    }
}