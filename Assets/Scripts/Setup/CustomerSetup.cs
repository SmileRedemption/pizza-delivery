using System;
using Model;
using Presenter;
using UnityEngine;
using View;

namespace Setup
{
    public class CustomerSetup : MonoBehaviour
    {
        private CustomerView _customerView;
        
        private Customer _customer;
        private CustomerPresenter _customerPresenter;

        private void Awake()
        {
            _customerView = GetComponent<CustomerView>();
        }

        private void OnEnable()
        {
            _customer = new Customer(_customerView.Position);
            _customerPresenter = new CustomerPresenter(_customer, _customerView);
            
            _customerPresenter.Enable();
        }
        
        private void OnDisable()
        {
            _customerPresenter.Disable();
        }
    }
}