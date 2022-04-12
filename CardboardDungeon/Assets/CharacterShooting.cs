using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject shootyPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public Transform projectileSpawnPoint;
    public float projectileShootSpeed = 30f;
    public float ShootTimeIntervalMax = 0.5f;
    float shootTimeInterval;

    private void Start()
    {
        shootTimeInterval = ShootTimeIntervalMax;
    }

    private void Update()
    {
        if (shootTimeInterval <= 0)
        {
            if (Input.GetKey(fireKey))
            {
                GameObject madeShooty = Instantiate(shootyPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                madeShooty.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.transform.forward * projectileShootSpeed);
                shootTimeInterval = ShootTimeIntervalMax;
            }
            
        }
        shootTimeInterval -= Time.deltaTime;

    }
}
