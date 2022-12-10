using UnityEngine;

namespace View.UI
{
    public class Heart : MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}