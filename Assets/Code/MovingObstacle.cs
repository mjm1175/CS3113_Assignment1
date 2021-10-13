using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingObstacle : MonoBehaviour
{
    public float delta = 1.5f;  // Amount to move left and right from the start point   
    public float speed = 2.0f;
    private Vector2 startPos;

    void Start () {
        startPos = transform.position;
    }
    void Update () {
        Vector3 charecterScale = transform.localScale;
        Vector2 v = startPos;
        v.x += delta * Mathf.Sin (Time.time * speed);
        if(Mathf.Sin (Time.time * speed)>0.9f)
        {
            charecterScale.x = Math.Abs(charecterScale.x);
        }
        else if (Mathf.Sin (Time.time * speed)<-0.9f)
        {
            charecterScale.x = -Math.Abs(charecterScale.x);
        }
        transform.localScale = charecterScale;
        transform.position = v;
    }
}
