using UnityEngine;

namespace View
{
    public abstract class View : MonoBehaviour
    {
        public Vector3 Position => transform.position;
    }
}