using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyAnimation : MonoBehaviour
{
    [SerializeField] private GameObject CargoBayIntro;
    private Action Callback;

    private bool PlayIntro;
    private bool PlayOutro;

    private int SceneSelect;

    private void Awake()
    {
        this.PlayIntro = false;
        this.PlayOutro = false;

        this.SceneSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.PlayIntro)
        {
            if (this.Callback != null)
            {
                IntroAnimation(this.Callback);
            }
            else
            {
                IntroAnimation();
            }
        }

        if (this.PlayOutro)
        {
            OutroAnimation();
        }
    }
    
    public void PlayIntroAnimation()
    {
        this.PlayIntro = true;
    }
    
    public void PlayIntroAnimation(Action _callback)
    {
        this.PlayIntro = true;
        this.Callback = _callback;
    }

    public void PlayOutroAnimation(int _scene)
    {
        this.SceneSelect = _scene;
        this.PlayOutro = true;
    }
    
    private void IntroAnimation()
    {
        if (this.CargoBayIntro.transform.position.y < -9.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.3f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -8.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.25f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -7.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.2f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -6.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.15f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -5.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.1f, 0);
            return;
        }

        this.PlayIntro = false;
    }

    private void IntroAnimation(Action _callback)
    {
        if (this.CargoBayIntro.transform.position.y < -9.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.3f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -8.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.25f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -7.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.2f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -6.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.15f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -5.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.1f, 0);
            return;
        }

        this.PlayIntro = false;
        _callback();
    }

    public void OutroAnimation()
    { 
        this.PlayIntro = false;
        
        if (this.CargoBayIntro.transform.position.y < -4.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.1f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -3.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.15f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -2.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.2f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -1.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.25f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= 10.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.30f, 0);
            return;
        }
        

        this.PlayOutro = false;

        SelectScene();
    }

    private void SelectScene()
    {
        SceneManager.LoadScene(this.SceneSelect);
    }
}