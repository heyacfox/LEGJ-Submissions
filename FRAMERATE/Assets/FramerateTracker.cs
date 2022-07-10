using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FramerateTracker : MonoBehaviour
{
    public TMP_Text framerateTracker;
    //10 seconds
    public int countToGetToNextLevel = 10;
    public int currentCount;
    public float FPSCantBeOver = 10f;
    public float updateEveryXmSeconds = 5f;
    public float updateTimer = 0.0f;
    public GameObject winPanel;
    public Slider winSlider;

    private void Start()
    {
        winSlider.maxValue = countToGetToNextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1.0f / Time.deltaTime;

        updateTimer += Time.deltaTime;
        if (updateTimer >= updateEveryXmSeconds)
        {
            updateTimer = 0.0f;
            framerateTracker.text = $"{fps.ToString("##.00")} FPS";

            if (fps <= FPSCantBeOver)
            {
                currentCount++;
                winSlider.value = currentCount;
            }
            else
            {
                currentCount = 0;
            }
            if (currentCount >= countToGetToNextLevel)
            {
                winPanel.SetActive(true);
            }
        }
        
        
    }
}
