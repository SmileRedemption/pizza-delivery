using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        
        public void Show(Action onRestartClick)
        {
            gameObject.SetActive(true);
            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(() => onRestartClick());
        }
    }
}