using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    
    public int GetHealth()
    {
        return this.Health;
    }
}
