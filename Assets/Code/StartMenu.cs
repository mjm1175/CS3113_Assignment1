using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalVars.levelNum = -1;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // try something with "SceneManager.GetActiveScene().name"
            // make sure it doesn't load past levels that exist
            // update so that when you die levelnum resets to 1
            GlobalVars.levelNum++;
            SceneManager.LoadScene("Menu");
        }        
    }
}
