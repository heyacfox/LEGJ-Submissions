using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PostListSystem pls;
    public ButtonOption buttonPrefab;
    public Transform buttonParent;

    //Goblin Mode: https://www.nbcnews.com/pop-culture/pop-culture-news/goblin-mode-becoming-part-peoples-everyday-vocabulary-language-meme-ex-rcna22181
    public int followerGoal = 1000000;

    public int currentFollowers = 0;

    public float currentEnergy = 100f;
    public float maxEnergy = 100f;

    public int playerAge = 1;
    public int maxAge = 365;
    public float secondsPerDay = 2f;

    public float energyDrainPerPost = 2f;

    public float defaultFollowerGain = 5000;
    public mode currMode = mode.influencerMode;

    public float buttonSpawnCurr;
    public float buttonSpawnMax = 1.5f;

    public float fuelSpawnCurr;
    public float fuelSpawnMax = 1.5f;

    //This curve should be ascending. As your energy = 1, you get more stuff. As it reduces to 0
    //you get less good. The bad action should just be 1 - the value returned from this. 
    public AnimationCurve actionToRewardCurveBasedOnEnergy;




    public TMP_Text followersTmp;
    public TMP_Text energyTmp;
    public TMP_Text ageTmp;

    public ParticleSystem goodParticles;
    public ParticleSystem badParticles;

    public SpriteRenderer background;
    public Button goblinButton;

    public Transform draggerParent;
    public Draggable dragPrefab;

    public GameObject goblin;
    public GameObject influencer;

    public GameObject EndCanvas;
    public TMP_Text endDaysNumber;
    public TMP_Text endFollowerNumber;

    public AudioSource goodMusic;
    public AudioSource badMusic;
    public AudioSource endMusic;

    public GameObject influencerPanel;
    public GameObject goblinPanel;
    public GameObject middlingPanel;

    //gain followers based on your energy
    //also drains your energy
    public void goodAction()
    {
        currentFollowers = Mathf.RoundToInt(currentFollowers + 
            defaultFollowerGain * actionToRewardCurveBasedOnEnergy.Evaluate(currentEnergy / maxEnergy));
        currentEnergy -= energyDrainPerPost;
        goodParticles.Play();
    }

    //lose followers based on low energy
    public void badAction()
    {
        //if you have a LOT of energy, you won't lose many followers
        currentFollowers = Mathf.RoundToInt(currentFollowers - 
            defaultFollowerGain * actionToRewardCurveBasedOnEnergy.Evaluate(1-currentEnergy / maxEnergy));
        currentEnergy -= energyDrainPerPost;
        badParticles.Play();
    }

    void spawnButton()
    {
        ButtonOption bo = Instantiate(buttonPrefab, buttonParent);
        float goodOrBad = actionToRewardCurveBasedOnEnergy.Evaluate(currentEnergy / maxEnergy);
        float buttoncheck = Random.Range(0, goodOrBad);
        if (buttoncheck > 0.1f)
        {
            bo.setupButton(pls.getGoodPost(), 1);
        } else
        {
            bo.setupButton(pls.getBadPost(), 0);
        }
        bo.GetComponent<RectTransform>().position = new Vector2(Random.Range(-8, 8), Random.Range(-3, 5));
        
        
    }

    private void Update()
    {
        if (currMode == mode.influencerMode)
        {
            influencerUpdate();
        } else if (currMode == mode.goblinMode)
        {
            goblinUpdate();
        }
        if (currMode == mode.influencerMode || currMode == mode.goblinMode)
        {
            updateUI();
            checkEnd();
        }
        
    }

    void checkEnd()
    {
        if (currentFollowers >= followerGoal || playerAge >= maxAge)
        {
            endGame();
        }
    }

    void influencerUpdate()
    {
        buttonSpawnCurr += Time.deltaTime;
        //As energy goes down, more posts spawn
        float tempmaxspawn = buttonSpawnMax * actionToRewardCurveBasedOnEnergy.Evaluate(currentEnergy / maxEnergy);
        //clamp for sensibilitiy purposes
        if (tempmaxspawn < 0.2f) tempmaxspawn = 0.2f;
        if (buttonSpawnCurr > tempmaxspawn)
        {
            spawnButton();
            buttonSpawnCurr = 0f;
        }
        if (currentEnergy < 0)
        {
            currentEnergy = 0f;
        }
    }

    void goblinUpdate()
    {
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
            GoToInfluencerMode();
        }

        fuelSpawnCurr += Time.deltaTime;
        if (fuelSpawnCurr > fuelSpawnMax)
        {
            spawnGoblinFuel();
            fuelSpawnCurr = 0f;
        }
    }

    public void spawnGoblinFuel()
    {
        Draggable dr = Instantiate(dragPrefab, draggerParent);
        if (Random.Range(0f, 1f) > 0.5f)
        {
            dr.GetComponent<RectTransform>().position = new Vector2(Random.Range(-8, -2), Random.Range(-3, 5));
        } else
        {
            dr.GetComponent<RectTransform>().position = new Vector2(Random.Range(2, 8), Random.Range(-3, 5));
        }
        

    }

    public void addEnergy()
    {
        currentEnergy += energyDrainPerPost;
    }

    public void GoToGoblinMode()
    {
        goblinButton.interactable = false;
        currMode = mode.goblinMode;
        background.color = Color.black;
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }
        goblin.SetActive(true);
        influencer.SetActive(false);
    }

    public void GoToInfluencerMode()
    {
        goblinButton.interactable = true;
        currMode = mode.influencerMode;
        background.color = Color.white;
        foreach (Transform child in draggerParent)
        {
            Destroy(child.gameObject);
        }
        goblin.SetActive(false);
        influencer.SetActive(true);
    }

    void updateUI()
    {
        followersTmp.text = $"Followers:\n {currentFollowers}/{followerGoal}";
        energyTmp.text = $"Energy: {currentEnergy.ToString("0.00")}/{maxEnergy}";
        ageTmp.text = $"Age: 29 years, {playerAge} days";
    }

    private void Start()
    {
        spawnButton();
        InvokeRepeating("addAge", secondsPerDay, secondsPerDay);
    }

    public void addAge()
    {
        playerAge++;
    }

    public void endGame()
    {
        CancelInvoke();
        currMode = mode.endMode;
        if (playerAge >= maxAge)
        {
            
            endDaysNumber.text = $"Age: 30 years";
            
        } else
        {
            endDaysNumber.text = $"Age: 29 years, {playerAge} days";
        }
        if (currentFollowers >= followerGoal)
        {
            endFollowerNumber.text = $"Followers: 1,000,000";
        } else
        {
            endFollowerNumber.text = $"Followers: {currentFollowers}";
        }
        if (currentFollowers >= followerGoal)
        {
            influencerPanel.SetActive(true);
        } else if (currentFollowers <= -followerGoal)
        {
            goblinPanel.SetActive(true);
            endFollowerNumber.color = Color.white;
            endDaysNumber.color = Color.white;
        } 
        else
        {
            middlingPanel.SetActive(true);
        }
        
        
        EndCanvas.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("TitleScene");
    }

}

public enum mode
{
    influencerMode,
    goblinMode,
    endMode
}
