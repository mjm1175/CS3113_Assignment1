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

    public AudioClip yellowCSnd;
    public AudioClip purpleCSnd;
    public AudioClip ghostSnd;
    AudioSource _audioSource;

    Animator _animator;

    public PauseMenu pauseMenu;

    bool dead;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        dead = false;
    }

    void FixedUpdate()
    {
        if(!pauseMenu.isPaused && !dead)
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
            _animator.SetFloat("Speed", Math.Abs(xSpeed));
        }
    }

    void Update()
    {
        if(!pauseMenu.isPaused && !dead)
        {
            if(transform.position[1]<-10) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isgrounded = Physics2D.OverlapCircle(feetPos.position, .3f, groundLayer);
            _animator.SetBool("Grounded", isgrounded);
            if(isgrounded){
                _animator.ResetTrigger("Jump");
                jumps = 1;
            }

            if(Input.GetButtonDown("Jump") && (jumps > 0 || isgrounded))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(new Vector2(0,jumpForce));
                jumps --;
                if(totalJumps<=jumpLimit) totalJumps++;
                _animator.SetTrigger("Jump");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Switch")){
            normalControls = !normalControls;
            _audioSource.PlayOneShot(purpleCSnd,0.6f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ghost") && !dead){
            _audioSource.PlayOneShot(ghostSnd,0.1f);
            dead = true;
            _animator.SetTrigger("Die");
            StartCoroutine(RestartLevel());
        }

        if (other.CompareTag("Candy")){
            _audioSource.PlayOneShot(yellowCSnd);
            Destroy(other.gameObject);
            if(totalJumps>jumpLimit) totalJumps--;
            if(totalJumps>0) totalJumps--;
        }

   }

    IEnumerator RestartLevel() {
        
        yield return new WaitForSeconds(2f);
        dead = false;
        _animator.ResetTrigger("Die");
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }
}
