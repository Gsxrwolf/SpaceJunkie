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
    }
}
