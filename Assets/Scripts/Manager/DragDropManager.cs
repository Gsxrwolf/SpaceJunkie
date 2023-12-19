using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private AudioSource dropSound;
    [SerializeField] private AudioSource dragSound;

    Rigidbody2D rigitBody;


    private void Start()
    {
        rigitBody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        GetComponent<PresentMove>().isDragging = true;
        pickUpSound.Play();
        dragSound.Play();
    }
    private void OnMouseDrag()
    {
        Vector2 direction = (GetMouseWorldPosition() - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, GetMouseWorldPosition());
        float velocity = (distance * speed) + 10;
        if (velocity > maxSpeed)
        {
            velocity = maxSpeed;
        }
        rigitBody.AddForce(direction * velocity);
    }
    private void OnMouseUp()
    {
        GetComponent<PresentMove>().isDragging = false;
        dragSound.Stop();
        dropSound.Play();
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
