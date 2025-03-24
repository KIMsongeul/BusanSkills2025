using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = transform.forward * v + transform.right * h;
        movement.Normalize();
        transform.position += movement * speed * Time.deltaTime;
    }
}
