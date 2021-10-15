using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    public void LoadScene1(){
        GlobalVars.levelNum = 0;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }
}