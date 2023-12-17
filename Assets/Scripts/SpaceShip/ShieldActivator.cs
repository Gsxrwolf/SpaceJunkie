using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
    [SerializeField] private HealthSystem HealthSystem;
    private Animator SpaceShipAnimator;

    private void Awake()
    {
        this.SpaceShipAnimator = GetComponent<Animator>();
        
    }
    
    public void EnableShield()
    {
        SpriteRenderer shieldRenderer = GetComponent<SpriteRenderer>();
        
        shieldRenderer.enabled = true;
        
        this.SpaceShipAnimator.SetBool("IsShieldActive", true);
    }
    
    public void SetShieldActive()
    {
        this.HealthSystem.SetShieldActive();
    }
    
    public void DisableShield()
    {
        this.SpaceShipAnimator.SetBool("IsShieldActive", false);
    }

    public void DisableShieldRenderer()
    {
        SpriteRenderer shieldRenderer = GetComponent<SpriteRenderer>();
        
        shieldRenderer.enabled = false;
    }
}
