using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sliderMultiplier;

    private Rigidbody2D rigitbody;
    private void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveDirection.x = -GameManager.Instance.GetXValueOfSpaceship() * sliderMultiplier;
        rigitbody.velocity = moveDirection.normalized * moveSpeed;
        if (transform.position.y < -17)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 45);
        }
        if(transform.position.x > 40)
        {
            transform.position = new Vector3(transform.position.x - 63, transform.position.y);
        }
        if (transform.position.x < -40)
        {
            transform.position = new Vector3(transform.position.x + 63, transform.position.y);
        }
    }
}
