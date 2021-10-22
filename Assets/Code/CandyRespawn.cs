using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class CandyRespawn : MonoBehaviour
{
    int respawnTime = 20;
    SpriteRenderer _spriteRenderer;
    Collider2D _collider2D;
    Light2DE _light;
    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        _light = GetComponent<Light2DE>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            _spriteRenderer.enabled = false;
            _collider2D.enabled = false;
            _light.enabled = false;

            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn(){
        yield return new WaitForSeconds(respawnTime);
        
        Color ogColor = _spriteRenderer.color;
        Color transparentColor = ogColor;
        transparentColor.a = 0;

        float ogIntensity = _light.intensity;
        float transparentIntensity = 0f;

        _spriteRenderer.enabled = true;
        _collider2D.enabled = true;
        _light.enabled = true;

        for (float t=0;t<1;t+=Time.deltaTime){
            _spriteRenderer.color = Color.Lerp(transparentColor, ogColor, t);
            _light.intensity = Mathf.Lerp(transparentIntensity, ogIntensity, t);
            yield return null;
        }
    }
}
