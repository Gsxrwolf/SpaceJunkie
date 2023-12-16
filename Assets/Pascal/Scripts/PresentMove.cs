using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PresentMove : MonoBehaviour
{
    private Rigidbody2D rigitBody;
    private Collider2D collider;

    private Vector3 mousePos;
    private float distance;

    private bool isDragging = false;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slidingForceMultiplier;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        rigitBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
    private void FixedUpdate()
    {
        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Vector2 direction = (mousePos - transform.position).normalized;
            distance = Vector2.Distance(transform.position, mousePos) + 2;
            float velocity = distance * speed;
            if (velocity > maxSpeed)
            {
                velocity = maxSpeed;
            }
            rigitBody.AddForce(direction * velocity);
        }
        if(!isDragging)
        {
            Vector2 slidingForce = LoadedCalculator.Instance.GetCalculatedSpaceshipDirection();
            slidingForce.y = 0;
            rigitBody.AddForce(slidingForce * slidingForceMultiplier);
        }
    }

    public void MouseButtonPress(InputAction.CallbackContext _input)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider == collider)
            {
                isDragging = true;
            }
        }
    }
}
