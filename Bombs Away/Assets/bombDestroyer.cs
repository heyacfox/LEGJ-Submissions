using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
