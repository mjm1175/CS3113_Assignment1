using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            // try something with "SceneManager.GetActiveScene().name"
            // make sure it doesn't load past levels that exist
            // update so that when you die levelnum resets to 1
            print("You win!");

            GlobalVars.levelNum = 1;
            SceneManager.LoadScene("Level " + GlobalVars.levelNum);
        }
    }
}