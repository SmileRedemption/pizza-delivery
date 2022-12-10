using System;
using CitySpawner;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;
using View.UI;

public class Root : MonoBehaviour
{
    [SerializeField] private BikeView _bikeView;
    [SerializeField] private Star[] _stars;
    [SerializeField] private CityGenerator _cityGenerator;
    [SerializeField] private WinGameView _winGameView;
    [SerializeField] private EndGameView _endGameView;

    private const int StarToWin = 3;
    private int _countOfTurnedStar;

    private Bike _bike;
    private IHealth _bikeHealth;

    public Bike Bike => _bike;
    public IHealth BikeHealth => _bikeHealth;

    private bool _isInit;

    public void Init()
    {
        if (_isInit)
            return;
        
        _bikeHealth = new Health(20);
        _bike = new Bike(_bikeView.Position, _bikeHealth);

        GenerateCity();
        GenerateCustomers();

        _isInit = true;
    }

    private void OnEnable()
    {
        _bikeView.BikeDestroyed += OnDied;

        foreach (var star in _stars)
        {
            star.TurnedOn += OnStarTurnedOn;
        }
    }

    private void OnDisable()
    {
        _bikeView.BikeDestroyed -= OnDied;

        foreach (var star in _stars)
        {
            star.TurnedOn -= OnStarTurnedOn;
        }
    }

    private void GenerateCustomers()
    {
        for (int i = 0; i < _cityGenerator.CountOfCustomers; i++)
        {
            var customer = _cityGenerator.SpawnCustomer();
            customer.Init(_stars);
        }
    }

    private void GenerateCity()
    {
        for (int i = 0; i < _cityGenerator.CountOfSpawn; i++)
            _cityGenerator.Spawn();
    }

    public void OnDied()
    {
        StopGame();
        _endGameView.Show(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    

    private void OnStarTurnedOn()
    {
        _countOfTurnedStar += 1;

        if (_countOfTurnedStar == StarToWin)
        {
            StopGame();
            _winGameView.Show(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }
}