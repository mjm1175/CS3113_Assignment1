using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        GlobalVars.levelNum = 0;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }

    public void Level2()
    {
        GlobalVars.levelNum = 1;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }

    public void Level3()
    {
        GlobalVars.levelNum = 2;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }

    public void Level4()
    {
        GlobalVars.levelNum = 3;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }

    public void Level5()
    {
        GlobalVars.levelNum = 4;
        SceneManager.LoadScene("Level " + GlobalVars.levelNum);
    }
}
