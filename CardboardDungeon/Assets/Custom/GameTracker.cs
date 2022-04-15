using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            Fungus.Flowchart.BroadcastFungusMessage("sceneover");
            isGameOver = true;
        }
    }
}
