using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public bool IsPaused;
    private int PlayerHealth;
    private bool PlayerShield;
    
    private bool GameLevel = false;
    
    [SerializeField] private int AfterFixUpdateTicks = 5;
    private int AfterFixUpdateTicksCounter = 0;

    private float XValueOfSpaceship;

    private int PlayerScore;
    public List<float> scoreboard = new List<float>();
    public List<float> scoreBuffer = new List<float>();

    public void OnLevelWasLoaded(int _level)
    {
        if (_level == 1)
        {
            this.GameLevel = true;
            this.PlayerHealth = 3;
        }
    }

    public void ResetPlayerScore()
    {
        scoreBuffer.Add(PlayerScore);
        PlayerScore = 0;
    }

    private void FixedUpdate()
    {
        if (!this.GameLevel)
        {
            return;
        }

        this.AfterFixUpdateTicksCounter++;

        if (this.AfterFixUpdateTicksCounter < this.AfterFixUpdateTicks)
        {
            return;
        }
        
        this.AfterFixUpdateTicksCounter = 0;
        this.PlayerScore += 10;
    }

    public int GetPlayerHealth()
    {
        return this.PlayerHealth;
    }
    
    public void SetPlayerHealth(int health)
    {
        this.PlayerHealth = health;
    }
    
    public bool GetPlayerShield()
    {
        return this.PlayerShield;
    }
    
    public void SetPlayerShield(bool shield)
    {
        this.PlayerShield = shield;
    }
    
    public int GetPlayerScore()
    {
        return this.PlayerScore;
    }
        
    public void AddPlayerScore(int _score)
    {
        this.PlayerScore += _score;
    }
    
    public void SetXValueOfSpaceship(float _xValue)
    {
        this.XValueOfSpaceship = _xValue;
    }
    
    public float GetXValueOfSpaceship()
    {
        return this.XValueOfSpaceship;
    }
    
    public void StopScore()
    {
        this.GameLevel = false;
    }
}
