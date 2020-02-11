using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Range(1, 10)] public float speed;

    public GameObject ball;
    
    private Rigidbody2D _rb;
    private Rigidbody2D _ballrb;
    private Vector2 _direction;
    private Vector2 _center;
    
    void Start()
    {
        _ballrb = ball.GetComponent<Rigidbody2D>();
        if (Camera.main==null) {Debug.LogError("Camera.main not found."); return;}

        var cam = Camera.main;
        
        _rb = GetComponent<Rigidbody2D>();
        
        var width = cam.pixelWidth;
        var height = cam.pixelHeight;
        
        var initialPosition = Camera.main.ScreenToWorldPoint( new Vector3(width - (width / 6f),height/2f,0));

        _rb.position = initialPosition;
    }
    
    void Update()
    {
        _center = _rb.position;

        var ballHeight = _ballrb.transform.position.y;
       
        //Direction
        //Ball going up and passed center of bar
        if (ballHeight > _center.y && _ballrb.velocity.y > 0)
        {
            _direction = Vector2.up;
        }
        //Ball going down and passed center of bar
        else if (ballHeight < _center.y && _ballrb.velocity.y < 0)
        { 
            _direction = Vector2.down;
        }
        //Ball going straight
        else
        { 
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(_direction);
    }

    private void ApplyMovement(Vector2 direction)
    {
        _rb.velocity = speed * direction;
    }
    
    
}
