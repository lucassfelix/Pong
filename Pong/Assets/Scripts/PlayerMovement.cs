using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1,100)]
    public float speed = 1f;

    public float maxSpeed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _initialPosition;
    
    void Start()
    {
        if (Camera.main==null) {Debug.LogError("Camera.main not found."); return;}

        var cam = Camera.main;
        
        _rb = GetComponent<Rigidbody2D>();
        
        var width = cam.pixelWidth;
        var height = cam.pixelHeight;
        
        _initialPosition = Camera.main.ScreenToWorldPoint( new Vector3(width / 6f,height/2f,0));

        _rb.position = _initialPosition;
    }

    public void ResetPositions()
    {
        _rb.velocity = Vector2.zero;
        _rb.position = _initialPosition;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Borders")
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        _movement = new Vector2 (0,Input.GetAxis("Vertical"));
    }
    
    private void FixedUpdate()
    {
        Movement(_movement);

        if (_rb.velocity.y > maxSpeed)
        {
            _rb.velocity = new Vector2(0,maxSpeed);
        }
        
        if (_rb.velocity.y < -maxSpeed)
        {
            _rb.velocity = new Vector2(0,-maxSpeed);
        }
    }

    private void Movement(Vector2 direction)
    {
        _rb.velocity += speed * direction;
    }
}
