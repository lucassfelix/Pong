using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BallMovement : MonoBehaviour
{
    public float speedIncrease;
    public float maxVelocity;
    
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private float _currentVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
       _rb = GetComponent<Rigidbody2D>();

       _direction = Vector2.left;
       _currentVelocity = 1f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _currentVelocity += speedIncrease;
        
        var relativeVelocity = other.GetContact(0).relativeVelocity;
        _direction = other.collider.name == "Borders" ? new Vector2(-relativeVelocity.x, relativeVelocity.y): new Vector2(relativeVelocity.x, relativeVelocity.y);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement(_direction);
    }

    private void ApplyMovement(Vector2 direction)
    {
        _rb.velocity = _currentVelocity * direction;
        if (_rb.velocity.y > maxVelocity)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, maxVelocity);
        }
        if (_rb.velocity.x > maxVelocity)
        {
            _rb.velocity = new Vector2(maxVelocity,_rb.velocity.y);
        }
    }
}
