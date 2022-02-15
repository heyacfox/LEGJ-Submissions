using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    
    public GameStage currentGameStage = GameStage.title;


    public Text footText;
    public Text timeText;
    public Text destinationDistance;
    public Text endTimer;
    public GameObject titlePanel;
    public GameObject endPanel;
    public GameObject marathonPanel;
    public float savedRaceTime;
    public float distanceLeft;
    public float raceTimer = 0f;
    public float startDistance = .2f;
    public float currentPlayerSpeed;
    public nextFoot nextFootToPress = nextFoot.left;
    public float speedDropRate = 1;
    public float currentSpeed;
    public float speedAddPerStep = 0.33f;
    public float maxEnergy = 100;
    public float currentEnergy = 100;
    public float energyLossPerStep = 5;
    public float energyRechargeRate = 5;
    public float distancePerStep = 0.000555f;
    public List<string> PigdonIntroSays;
    public List<string> PigdonMarathonEncouragement;
    public List<string> PigdonCongratz;
    public List<string> PigdonFailure;
    public List<ParallaxMover> movers;
    public Text affirmationTitle;
    public Text congratzEnd;
    public Text affirmationWhileGoing;
    public float howOftenShowPigdonSeconds = 30f;
    public float showPigdonTime = 10f;
    public GameObject marathonPigdon;
    public SpriteRenderer runnerComp;
    public Sprite standingRunner;
    public Sprite leftRunner;
    public Sprite rightRunner;
    public Rigidbody2D roadStripesBody;
    public AudioSource leftFootSource;
    public AudioSource rightFootSource;

    // Start is called before the first frame update
    void Start()
    {
        affirmationTitle.text = PigdonIntroSays[Random.Range(0, PigdonIntroSays.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameStage == GameStage.title)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                distanceLeft = startDistance;
                currentGameStage = GameStage.marathon;
                titlePanel.SetActive(false);
                marathonPanel.SetActive(true);
                raceTimer = 0;
                footText.text = "Left Foot";
                Invoke("showPigdon", howOftenShowPigdonSeconds);
            }
        } else if (currentGameStage == GameStage.marathon)
        {
            handleMarathon();
        } else if (currentGameStage == GameStage.win)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                endPanel.SetActive(false);
                titlePanel.SetActive(true);
                affirmationTitle.text = PigdonIntroSays[Random.Range(0, PigdonIntroSays.Count)];
                currentGameStage = GameStage.title;
            }
        }


        


    }
    //ten minute mile will be 180 steps per minute. That's .33 steps per second.
    //6 mph is 10 minute mile
    //6 mph is 6 miles per hour
    //6 miles per hour is .1 miles per minute
    // .1 miles per minute is .00167 miles per second;
    //which is .000555 miles every 1/3 of a second;
    //every step subtracts from the distance by 0.000555
    //Footstep sounds from https://opengameart.org/content/100-cc0-sfx-2
    void handleMarathon()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && nextFootToPress == nextFoot.left)
        {
            nextFootToPress = nextFoot.right;
            runnerComp.sprite = leftRunner;
            footText.text = "Right Foot";
            leftFootSource.Play();
            handleStep();
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && nextFootToPress == nextFoot.right)
        {
            nextFootToPress = nextFoot.left;
            runnerComp.sprite = rightRunner;
            footText.text = "Left Foot";
            rightFootSource.Play();
            handleStep();
        }

        //thanks my dude: https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
        raceTimer += Time.deltaTime;
        float tempTime = raceTimer;
        float seconds = tempTime % 60;
        tempTime -= seconds;
        float minutes = Mathf.Floor(tempTime / 60);
        float minutesDisplay = minutes % 60;
        float hours = Mathf.Floor(minutes / 60);

        if (roadStripesBody.velocity.x >= 0)
        {
            runnerComp.sprite = standingRunner;
        }

        timeText.text = "Time: " + hours.ToString("#####00") +
            ":" + minutesDisplay.ToString("00") + ":" + seconds.ToString("00.00");

        if (distanceLeft <= 0)
        {
            currentGameStage = GameStage.win;
            marathonPanel.SetActive(false);
            endPanel.SetActive(true);
            endTimer.text = $"Your Time\nHours:{hours}\nMinutes:{minutesDisplay}\nSeconds:{seconds.ToString("##.00")}";
            hidePigdon();
            CancelInvoke();
        }

        


    }

    void showPigdon()
    {
        marathonPigdon.SetActive(true);
        affirmationWhileGoing.text = PigdonMarathonEncouragement[Random.Range(0, PigdonMarathonEncouragement.Count)];
        Invoke("showPigdon", Random.Range(0, howOftenShowPigdonSeconds + Random.Range(0, 20)));
        Invoke("hidePigdon", showPigdonTime);
    }

    void hidePigdon()
    {
        marathonPigdon.SetActive(false);
    }

    void handleStep()
    {
        distanceLeft -= distancePerStep;
        foreach(ParallaxMover pm in movers)
        {
            pm.addSpeed(distancePerStep);
        }
        destinationDistance.text = "Distance Left: " + distanceLeft.ToString("#0.00") + " miles";
    }
}

public enum GameStage
{
    title,
    win,
    marathon,
    giveup
}

public enum nextFoot
{
    left,
    right
}
