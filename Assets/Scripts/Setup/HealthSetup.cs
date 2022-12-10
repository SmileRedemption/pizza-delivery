using Model;
using Presenter;
using UnityEngine;
using View;

namespace Setup
{
    [RequireComponent(typeof(HealthView))]
    public class HealthSetup : MonoBehaviour
    {
        [SerializeField] private Root _root;
        
        private HealthView _healthView;
        private IHealth _health;
        private HealthPresenter _healthPresenter;
        
        public void Awake()
        {
            _root.Init();
            _healthView = GetComponent<HealthView>();
        }

        private void OnEnable()
        {
            _health = _root.BikeHealth;
            _healthPresenter = new HealthPresenter(_health, _healthView);
            
            _healthPresenter.Enable();
            _health.Died += OnDied;
        }

        private void OnDied()
        {
            _root.OnDied();
        }

        private void OnDisable()
        {
            _healthPresenter.Disable();
        }
    }
}