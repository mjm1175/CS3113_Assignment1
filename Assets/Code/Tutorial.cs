using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject txt5;
    public GameObject txt6;
    public GameObject txt7;
    public GameObject txt8;
    public GameObject txt9;


    void Start()
    {
        txt1.SetActive(true);
        txt2.SetActive(false);
        txt3.SetActive(false);
        txt4.SetActive(false);
        txt5.SetActive(false);
        txt6.SetActive(false);
        txt7.SetActive(false);
        txt8.SetActive(false);
        txt9.SetActive(false);
        StartCoroutine(UpdateTxt1());
    }

   private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Tutorial")){
            Destroy(other.gameObject);

            if (txt1.activeSelf){
                txt2.SetActive(true);
                txt1.SetActive(false);                
            } else if (txt2.activeSelf){
                txt3.SetActive(true);
                txt2.SetActive(false);
            } else if (txt3.activeSelf){
                txt4.SetActive(true);
                txt3.SetActive(false);
            } else if (txt4.activeSelf){
                txt5.SetActive(true);
                txt4.SetActive(false);
            } else if (txt5.activeSelf){
                txt6.SetActive(true);
                txt5.SetActive(false);
            } else if (txt6.activeSelf){
                txt7.SetActive(true);
                txt6.SetActive(false);
            } else if (txt7.activeSelf){
                txt8.SetActive(true);
                txt7.SetActive(false);
            } else if (txt8.activeSelf){
                txt9.SetActive(true);
                txt8.SetActive(false);
            }
        }
    }

    IEnumerator UpdateTxt1() {
        yield return new WaitForSeconds(1.55f);
        //txt1.GetComponent<UnityEngine.UI.Text>().text = "Wait... Comeback!!!"; 

    }
}
