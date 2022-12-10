using System;

namespace Model
{
    public interface IHealth
    {
        event Action Died;
        public event Action<float, float> HealthChanged;
        
        void ApplyDamage(float damage);
    }
}