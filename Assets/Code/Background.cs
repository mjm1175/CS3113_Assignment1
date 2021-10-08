using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float length, start;
    public GameObject camera;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - speed));
        float dist = (camera.transform.position.x * speed);
        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);
        if (temp > start + length) start += length;
        else if(temp < start-length) start -=length;
    }
}
