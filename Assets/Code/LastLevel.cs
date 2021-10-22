using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            GlobalVars.levelNum = 0;
            SceneManager.LoadScene("End Scene");
        }
    }
}