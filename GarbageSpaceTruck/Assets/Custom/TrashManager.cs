using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashManager : MonoBehaviour
{
    TMP_Text trashText;
    public GameObject pointer;

    public int trashToSpawn;
    public int trashLeft;
    public GameObject trashPrefab;

    public List<GameObject> planets;

    public void trashCollected()
    {
        trashLeft--;
        trashText.text = "Trash left: " + trashLeft;
        if (trashLeft <= 0)
        {
            Debug.Log("You win!");
        }
    }

    public void Start()
    {
        trashLeft = 0;
        for (int x = 0; x < trashToSpawn; x++)
        {
            GameObject selectedPlanet = planets[Random.Range(0, planets.Count)];
            float randomX = Random.Range(0.01f, 1);
            float randomY = Random.Range(0.01f, 1);
            float randomZ = Random.Range(0.01f, 1);
            float randomExtraDistance = 50 + Random.Range(100, 300);
            Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
            spawnPos.Normalize();
            spawnPos = transform.position + (spawnPos * (selectedPlanet.transform.localScale.x + randomExtraDistance));
            Instantiate(trashPrefab, spawnPos, trashPrefab.transform.rotation);
        }
    }

    private void Update()
    {
        //get all trash
        GameObject[] trashes = GameObject.FindGameObjectsWithTag("trash");
        
        //find closest trash.
        if (trashes.Length > 0)
        {
            GameObject closestTrash = trashes[0];
            float distanceCheck = Vector3.Distance(pointer.transform.position, closestTrash.transform.position);
            foreach (GameObject oneTrash in trashes)
            {
                float newDistance = Vector3.Distance(pointer.transform.position, oneTrash.transform.position);
                if ( newDistance < distanceCheck)
                {
                    closestTrash = oneTrash;
                    distanceCheck = newDistance;
                }
            }

            pointer.transform.LookAt(closestTrash.transform);
        }
        
    }
}
