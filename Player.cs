using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float rotation = 200f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Rotate(0, 0, -SimpleInput.GetAxis("Horizontal") * rotation * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
