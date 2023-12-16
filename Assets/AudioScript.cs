using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioSource DauerFlugAudioSource;

    private void FixedUpdate()
    {
        HealthSystem ownHealthSystem = GetComponent<HealthSystem>();

        if (ownHealthSystem.GetHealth() != 0)
        {
            if (!this.DauerFlugAudioSource.isPlaying)
            {
                this.DauerFlugAudioSource.Play();
            }
        }
        else
        {
            this.DauerFlugAudioSource.Stop();
        }
    }
}
