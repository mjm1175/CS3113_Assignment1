using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 50;
    public LayerMask groundLayer;
    float xSpeed = 0;
    Rigidbody2D _rigidbody;
    public Transform feetPos;
    public bool isgrounded = false; 
    int jumps = 0;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
    }

    void Update()
    {
        isgrounded = Physics2D.OverlapCircle(feetPos.position, .3f, groundLayer);
        if(isgrounded){
            jumps = 1;
        }

        if(Input.GetButtonDown("Jump") && (jumps > 0 || isgrounded))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0,jumpForce));
            jumps --;
        }
    }
}
