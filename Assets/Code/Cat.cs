using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Animator _animator;
    public float speed = 8.0f;
    private Vector2 startPos;

    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        startPos = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(CatEscape());
    }

    // Update is called once per frame
    IEnumerator CatEscape() {
        yield return new WaitForSeconds(3.0f);
        _animator.SetBool("Escape", true);
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }
}
