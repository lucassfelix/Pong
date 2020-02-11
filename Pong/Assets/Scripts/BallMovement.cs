using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BallMovement : MonoBehaviour
{
    [Range(1f,2f)] public float velocityRate;

    public float maxVelocity;
    
    private Rigidbody2D _rb;
    private Vector2 _direction;
    
    
    void Start()
    {
       _rb = GetComponent<Rigidbody2D>();

       _direction = Vector2.left;
       velocityRate = 1.1f;
       
       _rb.velocity = velocityRate * _direction;
    }

    public void ResetPositions(int playerScored)
    {
        _rb.position = new Vector2(0,0);
        _direction = playerScored == 0 ? Vector2.right : Vector2.left;
        velocityRate = 1.1f;
        _rb.velocity = velocityRate * _direction;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var velocity = _rb.velocity;
        velocity = new Vector2(velocity.x,velocity.y + other.rigidbody.velocity.y) * velocityRate;
        _rb.velocity = velocity;
        
        var speedY = velocity.y;
        var speedX = velocity.x;

        if (Math.Abs(speedY) > maxVelocity)
        {
            _rb.velocity = new Vector2( _rb.velocity.x,  Math.Sign(speedY) * maxVelocity);
        }
        if (Math.Abs(speedX) > maxVelocity)
        {
            _rb.velocity = new Vector2(Math.Sign(speedX) * maxVelocity,  _rb.velocity.y);
        }
        
    }
    
    
}
