using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public GameObject ExplosionParticlesPrefab;
    public AudioClip Boom;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            Instantiate(ExplosionParticlesPrefab, collision.gameObject.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(Boom);
            gameManager.loseHealth();
            Destroy(collision.gameObject);
        }
    }
}
