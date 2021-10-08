using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Light2D playerLight;
    public Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerScript.isgrounded){
            playerLight.pointLightOuterRadius = 3;
        }
        else{
            playerLight.pointLightOuterRadius = 100;
        }
        transform.position = player.transform.position;
    }
}
