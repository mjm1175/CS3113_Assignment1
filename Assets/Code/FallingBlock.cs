using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    public GameObject block;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            Instantiate(block,new Vector3 (-5.91f, 5.87f, 0), Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
