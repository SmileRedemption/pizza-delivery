using System;

namespace Model
{
    public class Health : IHealth
    {
        private readonly int _maxHealth;
        private float _currentHealth;
        
        public event Action<float, float> HealthChanged;        public event Action Died;

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException(nameof(damage));

            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}
   