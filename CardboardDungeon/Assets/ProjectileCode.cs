using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCode : MonoBehaviour
{
    public float lifetime;
    public float currentLife;

    private void Start()
    {
        currentLife = lifetime;
        StartCoroutine("lifetimeVanisher");
    }

    IEnumerator lifetimeVanisher()
    {
        while (true)
        {
            currentLife -= Time.deltaTime;
            float percentSize = currentLife / lifetime;
            transform.localScale = new Vector3(percentSize, percentSize, percentSize);
            if (currentLife <= 0)
            {
                Destroy(this.gameObject);
            }
            yield return null;
        }
    }

}
