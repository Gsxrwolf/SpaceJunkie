using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigitbody;
    private void Start()
    {
        rigitbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigitbody.velocity = moveDirection.normalized * moveSpeed;
        if (transform.position.x < -17)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 45);
        }
    }
}
