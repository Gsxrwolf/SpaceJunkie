using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PresentMove : MonoBehaviour
{
    private Rigidbody2D rigitBody;
    private Collider2D grabCollider;

    private Vector3 mousePos;
    private float distance;

    private bool isDragging = false;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slidingForceMultiplier;

    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private AudioSource dropSound;
    [SerializeField] private AudioSource dragSound;


    private void Start()
    {
        grabCollider = GetComponent<Collider2D>();
        rigitBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isDragging)
        {
            rigitBody.drag = 1;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - transform.position).normalized;
            distance = Vector2.Distance(transform.position, mousePos);
            float velocity = (distance * speed) + 10;
            if (velocity > maxSpeed)
            {
                velocity = maxSpeed;
            }
            rigitBody.AddForce(direction * velocity);
        }
        if (!isDragging)
        {
            rigitBody.drag = 2;
            Vector2 slidingForce = LoadedCalculator.Instance.GetCalculatedSpaceshipDirection();
            slidingForce.y = 0;
            rigitBody.AddForce(slidingForce * slidingForceMultiplier);
        }
    }

    public void MouseButtonPress(InputAction.CallbackContext _input)
    {
        if (_input.started)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if (hitCollider != null)
            {
                if (hitCollider == grabCollider)
                {
                    pickUpSound.Play();
                    isDragging = true;
                    dragSound.Play();
                }
            }
        }
        if (_input.canceled)
        {
            if(isDragging)
            {
                dragSound.Stop();
                isDragging = false;
                dropSound.Play();
            }
        }


    }
}
