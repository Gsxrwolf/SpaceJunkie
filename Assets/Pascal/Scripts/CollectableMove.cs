using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMove : MonoBehaviour
{
    [SerializeField] private string shipTag;

    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigitbody;

    private void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(shipTag))
        {
            HealthSystem effected = other.gameObject.GetComponent<HealthSystem>();
            effected.GenerateShield();
        }
    }

    private void FixedUpdate()
    {
        rigitbody.AddForce(moveDirection.normalized * moveSpeed);
    }
}
