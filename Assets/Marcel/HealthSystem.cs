using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    private bool ShieldActive = false;

    public void GenerateShield()
    {
        this.ShieldActive = true;
    }
    
    public void DealDamage(int _damage)
    {
        if (this.ShieldActive)
        {
            this.ShieldActive = false;
            return;
        }

        this.Health -= _damage;
    }
    
    public void DealDamage()
    {
        if (this.ShieldActive)
        {
            this.ShieldActive = false;
            return;
        }

        this.Health--;

        if (this.Health <= 0) {
            this.Health = 0;
            SceneManager.LoadScene(2); // load death scene
        }
    }

    // 0 - MainMenu
    // 1 - MainGame
    // 2 - DeathScreen
    
    public int GetHealth()
    {
        return this.Health;
    }
}
