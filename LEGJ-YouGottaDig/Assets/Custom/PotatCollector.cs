using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatCollector : MonoBehaviour
{
    public Text potatText;
    int potats = 0;
    public AudioClip oneHundred;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "potat")
        {
            potats++;
            potatText.text = "Potats:" + potats;
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            if (potats == 100) GetComponent<AudioSource>().PlayOneShot(oneHundred);

        }
    }

}
