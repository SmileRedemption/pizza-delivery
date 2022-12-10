using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using View.UI;

namespace View
{
    public class HealthView : View
    {
        [SerializeField] private Image _healthBar;

        public void OnValueChanged(float minValue, float maxValue)
        {
            _healthBar.fillAmount = minValue / maxValue;
        }
    }
}