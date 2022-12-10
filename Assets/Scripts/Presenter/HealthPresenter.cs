using Model;
using View;

namespace Presenter
{
    public class HealthPresenter : IPresenter
    {
        private readonly IHealth _health;
        private readonly HealthView _healthView;

        public HealthPresenter(IHealth health, HealthView healthView)
        {
            _health = health;
            _healthView = healthView;
        }

        public void Enable()
        {
            _health.HealthChanged += OnHealthChanged;
        }
        
        public void Disable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }
        
        private void OnHealthChanged(float minValue, float maxValue)
        {
            _healthView.OnValueChanged(minValue, maxValue);
        }
    }
}