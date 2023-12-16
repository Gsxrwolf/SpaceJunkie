using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveDamage : MonoBehaviour
{
    [SerializeField] private string shipTag;
    [SerializeField] private int directDamageAmount;

    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sliderMultiplier;

    [SerializeField] private AudioSource hitSound;

    private Rigidbody2D rigitbody;

    private void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(shipTag))
        {
            hitSound.Play();
            HealthSystem effected = other.gameObject.GetComponent<HealthSystem>();
            effected.DealDamage(directDamageAmount);
            ObsticalPoolManager.MoveToHiddenPoint(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        moveDirection.x = -GameManager.Instance.GetXValueOfSpaceship() * sliderMultiplier;
        rigitbody.velocity = moveDirection.normalized * moveSpeed;
    }
}
