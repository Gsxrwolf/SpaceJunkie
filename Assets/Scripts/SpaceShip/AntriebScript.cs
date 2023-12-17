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
            SpriteRenderer ownSprite = GetComponent<SpriteRenderer>();
            
            ownSprite.enabled = false;
        }
    }
}
