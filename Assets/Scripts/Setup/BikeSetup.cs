using System;
using Model;
using Presenter;
using UnityEngine;
using View;

namespace Setup
{
    public class BikeSetup : MonoBehaviour
    {
        [SerializeField] private Root _root;
        [SerializeField] private BikeView _bikeView;
        
        private Bike _bike;
        private BikePresenter _bikePresenter;
        
        public void Awake()
        {
            _root.Init();
        }

        private void OnEnable()
        {
            _bike = _root.Bike;
            _bikePresenter = new BikePresenter(_bike, _bikeView);
            
            _bikePresenter.Enable();
        }
        
        private void OnDisable()
        {
            _bikePresenter.Disable();
        }
    }
}