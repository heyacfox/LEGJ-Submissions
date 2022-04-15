using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterShooting : MonoBehaviour
{
    public GameObject shootyPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public Transform projectileSpawnPoint;
    public float projectileShootSpeed = 30f;
    public float ShootTimeIntervalMax = 0.5f;
    float shootTimeInterval;
    public float massBoost = 1;

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
                madeShooty.GetComponent<Rigidbody>().mass = madeShooty.GetComponent<Rigidbody>().mass * massBoost;
                shootTimeInterval = ShootTimeIntervalMax;
            }
            
        }
        shootTimeInterval -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "orb")
        {
            Destroy(other.gameObject);
            projectileShootSpeed = projectileShootSpeed * 1.2f;
            shootTimeInterval = shootTimeInterval * 0.9f;
        }
        if (other.tag == "death")
        {
            SceneManager.LoadScene("DeadScene");
        }
        if (other.tag == "orb2")
        {
            massBoost = massBoost * 1.05f;
            Destroy(other.gameObject);
        }
    }


}
