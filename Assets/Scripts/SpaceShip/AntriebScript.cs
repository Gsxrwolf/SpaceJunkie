using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntriebScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GameManager.Instance.GetPlayerHealth() == 0)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("IsDead", true);
        }
    }

    public void DisableFlames()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.enabled = false;
        
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsDead", false);
    }
}
