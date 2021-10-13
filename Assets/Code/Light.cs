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
    public float minRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerScript.isgrounded){
            if(playerLight.pointLightOuterRadius > minRadius) playerLight.pointLightOuterRadius -= Time.deltaTime * 100;
        }
        else{
            playerLight.pointLightOuterRadius += Time.deltaTime * 20;
        }
        transform.position = player.transform.position;
    }
}
