using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class WinGameView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Show(Action onRestartClick)
        {
            gameObject.SetActive(true);
            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(() => onRestartClick());
        }
    }
}