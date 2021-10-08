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
          Vector2 v = startPos;
          v.x += delta * Mathf.Sin (Time.time * speed);
          transform.position = v;
     }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
