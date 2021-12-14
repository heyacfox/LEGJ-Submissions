using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject IntroMessage;
    public GameObject WinMessage;
    public GameObject LoseMessage;
    public GameObject RestartButton;
    public GameObject RestartButHarder;
    public GameObject StartButton;
    public Text DifficultyMessage;
    public Text HealthRemaining;
    public static int Difficulty = 1;
    public float spawnTimerMax;
    public float spawnTimerCurrent;
    public GameObject PlanePrefab;
    public int Health = 10;
    public float roundLength = 60;
    bool roundActive = false;
    bool roundResolved = false;
    bool roundStarted = false;
    //public int startingDifficulty = 1;


    public void OnPlayClicked()
    {
        StartButton.SetActive(false);
        IntroMessage.SetActive(false);
        DifficultyMessage.gameObject.SetActive(false);
        roundActive = true;
        roundStarted = true;
        Invoke("turnOffRound", roundLength);
        HealthRemaining.text = "Health: " + Health;

    }

    private void turnOffRound()
    {
        roundActive = false;
    }

    public void loseHealth()
    {
        Health--;
        if (Health <= 0)
        {
            Health = 0;
            LoseGame();
            roundActive = false;
            roundResolved = true;
        }
        HealthRemaining.text = "Health: " + Health;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGameButHarder()
    {
        Difficulty++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        roundActive = false;
        roundResolved = true;
        WinMessage.SetActive(true);
        RestartButton.SetActive(true);
        RestartButHarder.SetActive(true);
        DifficultyMessage.gameObject.SetActive(true);
        DifficultyMessage.text = "Difficulty: " + Difficulty;
    }

    public void LoseGame()
    {
        LoseMessage.SetActive(true);
        RestartButton.SetActive(true);
        //RestartButHarder.SetActive(true);
        DifficultyMessage.gameObject.SetActive(true);
        DifficultyMessage.text = "Difficulty: " + Difficulty;
    }

    public void Start()
    {
        spawnTimerMax = 5f - Difficulty * 0.5f;
        if (spawnTimerMax < 0.0f)
        {
            spawnTimerMax = 0.25f;
        }
        DifficultyMessage.gameObject.SetActive(true);
        DifficultyMessage.text = "Difficulty: " + Difficulty;
    }

    public void Update()
    {
        //I SHOULD HAVE DONE AN ENUM
        if (roundStarted)
        {
            if (roundActive)
            {
                spawnTimerCurrent += Time.deltaTime;
                if (spawnTimerCurrent > spawnTimerMax)
                {
                    spawnTimerCurrent = 0f;
                    SpawnPlane();
                }
            }
            else
            {
                //Inactive not resolved is for no more spawning planes, but you have to get rid of all the bombs still
                if (roundResolved == false)
                {
                    if (GameObject.FindGameObjectsWithTag("bomb").Length == 0)
                    {
                        roundResolved = true;
                        WinGame();
                    }
                }
            }
        }
        
    }

    private void SpawnPlane()
    {
        //pick left or right side, x = -10
        List<float> directions = new List<float>() { 1, -1 };
        float direction = directions[Random.Range(0, 2)];
        //pick height, 4.7 to 2
        float spawnX = 10f * -direction;
        float spawnY = Random.Range(2, 4.7f);
        //pick speed
        float speed = Random.Range(2, 4);
        GameObject plane = Instantiate(PlanePrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
        if (direction == -1)
        {
            plane.transform.localScale = new Vector3(plane.transform.localScale.x * -1, 
                plane.transform.localScale.y, 
                plane.transform.localScale.z);
        }
        Plane realPlane = plane.GetComponent<Plane>();
        realPlane.moveSpeed = speed * direction;
        //Difficulty Adjustments
        realPlane.drops = Mathf.CeilToInt((float) Difficulty / 2f);
        //realPlane.gravityScale = 0.1f + (Difficulty * 0.01f);
        //realPlane.massofBomb = 1.0f + (Difficulty * 0.1f);
        realPlane.gravityScale = 0.1f;
        realPlane.massofBomb = 1.0f;

    }
}
