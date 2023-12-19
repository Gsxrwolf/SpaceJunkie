using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PresentMove : MonoBehaviour
{
    private Rigidbody2D rigitBody;


    public bool isDragging = false;

    [SerializeField] private LoadedCalculator loadedCalculator;

    [SerializeField] private float slidingForceMultiplier;


    private void Start()
    {
        rigitBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isDragging)
        {
            rigitBody.drag = 1;
        }
        if (!isDragging)
        {
            rigitBody.drag = 2;
            Vector2 slidingForce = loadedCalculator.GetCalculatedSpaceshipDirection();
            slidingForce.y = 0;
            rigitBody.AddForce(slidingForce * slidingForceMultiplier);
        }
    }
}
