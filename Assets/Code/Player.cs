using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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
    bool normalControls = true;

    public int totalJumps = 0;
    public int jumpLimit = 5;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 characterScale = transform.localScale;
        if (normalControls){
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -Math.Abs(characterScale.x);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = Math.Abs(characterScale.x);
            }
            transform.localScale = characterScale;
            xSpeed = Input.GetAxis("Horizontal") * speed;
        } else {
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = Math.Abs(characterScale.x);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = -Math.Abs(characterScale.x);
            }
            transform.localScale = characterScale;
            xSpeed = -Input.GetAxis("Horizontal") * speed;
        }
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
            if(totalJumps<=jumpLimit) totalJumps++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Switch")){
            normalControls = !normalControls;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ghost")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.CompareTag("Candy")){
            Destroy(other.gameObject);
            if(totalJumps>jumpLimit) totalJumps--;
            if(totalJumps>0) totalJumps--;
        }
   }
}
