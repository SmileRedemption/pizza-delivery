using Model;
using UnityEngine;
using View;


namespace Presenter
{
    public class BikePresenter : IPresenter
    {
        private readonly Bike _bike;
        private readonly BikeView _bikeView;

        public BikePresenter(Bike bike, BikeView bikeView)
        {
            _bike = bike;
            _bikeView = bikeView;
        }

        public void Enable()
        {
            _bikeView.Moved += OnMoved;
            _bikeView.CollidedWithCar += OnCollidedWithCar;
        }

        private void OnCollidedWithCar(float damage)
        {
            _bike.Health.ApplyDamage(damage);
        }

        public void Disable()
        {
            _bikeView.Moved -= OnMoved;
        }
        
        private void OnMoved(Vector3 position)
        {
            _bike.Move(position);
        }
    }
}