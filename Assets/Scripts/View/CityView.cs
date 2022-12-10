using CitySpawner;
using UnityEngine;
using Random = UnityEngine.Random;

namespace View
{
    public class CityView : View
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [SerializeField] private Transform[] _customersPositions;

        public float Length => Vector3.Distance(_startPoint.position, _endPoint.position);
        public Vector3 CustomerPosition => _customersPositions[Random.Range(0, _customersPositions.Length)].position;
        
        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }
    }
}