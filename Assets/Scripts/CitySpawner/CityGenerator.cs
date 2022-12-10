using System.Collections.Generic;
using UnityEngine;
using View;
using Random = UnityEngine.Random;

namespace CitySpawner
{
    public class CityGenerator : MonoBehaviour
    {
        [SerializeField] private CityView cityView;
        [SerializeField] private CustomerView _customer;
        [SerializeField] private int _countOfSpawn;
        [SerializeField] private int _countOfCustomers;
        
        private readonly List<CityView> _cities = new();
        private float _spawnPosition;
        private float _cityLength;

        public int CountOfSpawn => _countOfSpawn;
        public int CountOfCustomers => _countOfCustomers;

        public void Spawn()
        {
            _cityLength = cityView.Length;
        
            var city = Instantiate(cityView, transform.forward * _spawnPosition, Quaternion.identity);
            _spawnPosition += _cityLength;
            _cities.Add(city);
        }

        public CustomerView SpawnCustomer()
        {
            var randomIndex = Random.Range(0, _cities.Count);
            return Instantiate(_customer, _cities[randomIndex].CustomerPosition, Quaternion.identity);
        }
    }
}
