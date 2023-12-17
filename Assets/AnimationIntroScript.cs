using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIntroScript : MonoBehaviour
{
    [SerializeField] private GameObject CargoBayOriginal;
    [SerializeField] private GameObject CargoBayIntro;
    [SerializeField] private GameObject TopShip;

    [SerializeField] private GameObject BluePresent;
    [SerializeField] private GameObject YellowPresent;
    [SerializeField] private GameObject RedPresent;
    [SerializeField] private GameObject NotMoveableObject;
    [SerializeField] private GameObject GameOveray;
    [SerializeField] private GameObject ObsticlePoolManager;

    // Start is called before the first frame update
    void Start()
    {
        FlyAnimation flyAnimation = GetComponent<FlyAnimation>();
        flyAnimation.PlayIntroAnimation(AfterIntroAnimation);
    }

    private void AfterIntroAnimation()
    {
        this.CargoBayIntro.SetActive(false);
        this.CargoBayOriginal.SetActive(true);
        this.BluePresent.SetActive(true);
        this.YellowPresent.SetActive(true);
        this.RedPresent.SetActive(true);
        this.NotMoveableObject.SetActive(true);
        this.GameOveray.SetActive(true);
        this.ObsticlePoolManager.SetActive(true);

        this.TopShip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}