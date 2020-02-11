using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private float minVelocity = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
       _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = Vector2.left * 2f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var relativeVelocity = other.GetContact(0).relativeVelocity;
        Debug.Log("Enter Collision Velocity:" + relativeVelocity);
        _rb.velocity = other.collider.name == "Borders" ? new Vector2(-relativeVelocity.x, relativeVelocity.y): new Vector2(relativeVelocity.x, relativeVelocity.y);
        Debug.Log("Exit Collision Velocity:" + _rb.velocity);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
