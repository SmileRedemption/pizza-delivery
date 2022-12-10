using Model;
using UnityEngine;
using View;

namespace Presenter
{
    public class CarPresenter : IPresenter
    {
        private readonly Car _car;
        private readonly CarView _carView;

        public CarPresenter(Car car, CarView carView)
        {
            _car = car;
            _carView = carView;
        }

        public void Enable()
        {
            _carView.Moved += OnMoved;
        }

        public void Disable()
        {
            _carView.Moved -= OnMoved;
        }
        
        private void OnMoved(Vector3 position)
        {
            _car.Move(position);
        }
    }
}