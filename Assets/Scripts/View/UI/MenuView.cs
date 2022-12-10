using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class MenuView : View
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            Time.timeScale = 0;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }
        
        private void OnStartButtonClick()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}