using System;
using Model;
using Presenter;
using UnityEngine;
using View;

namespace Setup
{
    [RequireComponent(typeof(CarView))]
    public class CarSetup : MonoBehaviour
    {
        private CarView _carView;
        private Car _car;
        private CarPresenter _carPresenter;

        private void Awake()
        {
            _carView = GetComponent<CarView>();
        }

        private void OnEnable()
        {
            _car = new Car(_carView.Position);
            _carPresenter = new CarPresenter(_car, _carView);
            
            _carPresenter.Enable();
        }

        private void OnDisable()
        {
            _carPresenter.Disable();
        }
    }
}