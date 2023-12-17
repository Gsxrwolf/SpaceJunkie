using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    private bool ShieldActive = false;

    [SerializeField] private AudioSource explosionSound;

    [SerializeField] private ShieldActivator ShieldActivator;
    
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private NumberToImage NumberToImage;
    
    private void Awake()
    {
        GameManager.Instance.SetPlayerShield(this.ShieldActive);
        GameManager.Instance.SetPlayerHealth(this.Health);
    }

    public void GenerateShield()
    {
        this.ShieldActivator.EnableShield();
    }
    
    public void SetShieldActive()
    {
        if (this.Health <= 0) return;
        
        this.ShieldActive = true;
        
        GameManager.Instance.SetPlayerShield(this.ShieldActive);
    }
    
    public void DealDamage(int _damage)
    {
        if (this.ShieldActive)
        {
            this.ShieldActive = false;
            this.ShieldActivator.DisableShield();
            GameManager.Instance.SetPlayerShield(this.ShieldActive);
            return;
        }

        this.Health -= _damage;

        if (this.Health <= 0)
        {
            this.Health = 0;
            explosionSound.Play();
            GameManager.Instance.StopScore();
            Invoke("LoadDeathScene", 3);
        }

        GameManager.Instance.SetPlayerHealth(this.Health);
    }
    void LoadDeathScene()
    {
        //SceneManager.LoadScene(2);
        this.DeathScreen.SetActive(true);

        this.NumberToImage.ConvertToImage();
    }
    // 0 - MainMenu
    // 1 - MainGame
    // 2 - DeathScreen
    
    public int GetHealth()
    {
        return this.Health;
    }
}
