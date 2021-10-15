using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingLeftRightPlat : MonoBehaviour
{
    public float delta = 1.5f;  // Amount to move left and right from the start point   
    public float speed = 2.0f;
    private Vector2 startPos;

    private void Start () {
        startPos = transform.position;
    }
          
    private void Update () {
        Vector2 v = startPos;
        v.x += delta * Mathf.Sin (Time.time * speed);
        transform.position = v;
    }


    private void OnCollisonEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }

    }

    private void OnCollisonExit2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }

    }



}
