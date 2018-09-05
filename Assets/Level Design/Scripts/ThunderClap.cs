using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : MonoBehaviour {

    public AudioClip thunderClip;
    private bool canFlicker = true;
	
	void Update () {
        StartCoroutine(Flicker());
	}

    /*
     * Ativa a luz do objeto para simular o clarão dos raios de uma tempestade e toca o som do trovão.
     */
    IEnumerator Flicker() {
        if (canFlicker) {
            canFlicker = false;
            GetComponent<AudioSource>().PlayOneShot(thunderClip);
            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f, 5));
            canFlicker = true;
        }
    }
}
