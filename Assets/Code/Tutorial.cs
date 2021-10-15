using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;


    void Start()
    {
        txt1.SetActive(true);
        txt2.SetActive(false);
    }

   private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Tutorial")){
            Destroy(other.gameObject);
            txt2.SetActive(true);
            txt1.SetActive(false);
        }
    }
}
