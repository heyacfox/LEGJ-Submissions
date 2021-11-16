using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MicrophoneTest : MonoBehaviour
{

    //https://docs.unity3d.com/ScriptReference/Microphone.html

    //public string currentDevice;
   

    public AudioClip IntroClip;
    public AudioClip YourselfClip;
    public AudioClip AboutATime;
    public AudioClip TestQuestion;
    public AudioClip Final;
    public AudioClip Failure;

    public AudioClip savedIntro;
    public AudioClip savedYourself;
    public AudioClip savedAboutATime;
    public AudioClip savedTest;

    public Animator ghostAnimator;

    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject EndPanelWin;
    public GameObject EndPanelLose;
    public GameObject ClipPanel;
    public Text loseText;
    public GameObject recordingDisplay;

    public GameObject IntroClipButton;
    public GameObject YourselfClipButton;
    public GameObject TimeClipButton;
    public GameObject TestClipButton;

    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        string[] allDevices = Microphone.devices;
        Application.RequestUserAuthorization(UserAuthorization.Microphone);
        Debug.Log("A total of this many mics:" + Microphone.devices.Length);
        //savedClip = Microphone.Start("", false, 3, 44100);
        //Microphone.
        //Invoke("stopRecording", 4f);
        //RecordingTest();
    }

    public void StartMainScreen() 
    {
        GamePanel.SetActive(true);
        StartPanel.SetActive(false);
        EndPanelWin.SetActive(false);
        EndPanelLose.SetActive(false);
        ClipPanel.SetActive(false);
        IntroClipButton.SetActive(false);
        YourselfClipButton.SetActive(false);
        TimeClipButton.SetActive(false);
        TestClipButton.SetActive(false);
        savedIntro = null;
        savedYourself = null;
        savedAboutATime = null;
        savedTest = null;
        PlayFirstClip();
        //RecordingTest();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlayFirstClip()
    {
        audioSource.clip = IntroClip;
        audioSource.Play();
        Invoke("OnFirstClipEnd", IntroClip.length + 1);
    }

    public void OnFirstClipEnd()
    {
        
        try
        {
            savedIntro = Microphone.Start("", false, 5, 44100);
            recordingDisplay.SetActive(true);
            Invoke("FirstRecordingEnd", 5f);
        } catch (Exception e)
        {
            Debug.Log("Something bad happened.");
            Invoke("FirstRecordingEnd", 5f);
        }
        
        
    }

    public void FirstRecordingEnd()
    {
        Microphone.End("");
        recordingDisplay.SetActive(false);
        if (savedIntro == null)
        {
            BadEnd("Not able to talk {Make sure you have a valid microphone device on your computer}");
        } else
        {
            //PrintSampleData(savedIntro);
            if (getPercentNoisy(savedIntro) < 0.1)
            {
                BadEnd("Way too quiet");
            } else {
                RecordingConfirmed();
            }
            
        }
    }

    public void BadEnd(string failureType)
    {
        audioSource.clip = Failure;
        audioSource.Play();
        loseText.text = "You didn't get the job:\n" + failureType;
        Invoke("FinalScreenLose", Failure.length + 1);
    }

    public void RecordingConfirmed()
    {

        audioSource.clip = YourselfClip;
        audioSource.Play();
        Invoke("RecordingYourself", YourselfClip.length);
    }
    
    public void RecordingYourself()
    {
        recordingDisplay.SetActive(true);
        savedYourself = Microphone.Start("", false, 30, 44100);
        Invoke("YourselfRecordingEnd", 30f);
    }

    public void YourselfRecordingEnd()
    {
        Microphone.End("");
        recordingDisplay.SetActive(false);
        if (getPercentNoisy(savedYourself) < 0.1f)
        {
            BadEnd("Didn't have anything to say about yourself.");
        }
        else if (getPercentNoisy(savedYourself) > 0.9f) {
            BadEnd("Too abrasive when explaining about yourself");
        }
        else
        {
            audioSource.clip = AboutATime;
            audioSource.Play();
            Invoke("RecordingAboutATime", AboutATime.length);
        }
        
    }

    public void RecordingAboutATime()
    {
        recordingDisplay.SetActive(true);
        savedAboutATime = Microphone.Start("", false, 30, 44100);
        Invoke("AboutATimeRecordingEnd", 30f);
    }

    public void AboutATimeRecordingEnd()
    {
        Microphone.End("");
        recordingDisplay.SetActive(false);
        if (getPercentNoisy(savedYourself) < 0.1f)
        {
            BadEnd("Not enough to your fear story");
        }
        else if (getPercentNoisy(savedYourself) > 0.9f)
        {
            BadEnd("Too much in your fear story");
        }
        else
        {
            audioSource.clip = TestQuestion;
            audioSource.Play();
            Invoke("RecordingTest", TestQuestion.length);
        }
        
    }

    public void RecordingTest()
    {
        savedTest = Microphone.Start("", false, 10, 44100);
        recordingDisplay.SetActive(true);
        ghostAnimator.SetTrigger("StartMove");
        Invoke("TestRecordingEnd", 10f);
    }

    public void TestRecordingEnd()
    {
        Microphone.End("");
        recordingDisplay.SetActive(false);
        //PrintSampleData(savedTest);
        List<float> noisyList = noisyInAndOutOfRange(savedTest, 198450, 242550);
        Debug.Log($"InRange:{noisyList[0]},outrange:{noisyList[1]}");
        if (noisyList[0] > 0.5)
        {
            Debug.Log("Sufficiently scary");
        }
        if (noisyList[1] < 0.2)
        {
            Debug.Log("Quiet at the right parts");
        }

        if (noisyList[0] < 0.5f || noisyList[1] > 0.2f)
        {
            string fullString = "";
            if (noisyList[0] < 0.5f)
            {
                fullString += "\nNot loud enough at the right time for a good jump scare.";
            }
            if (noisyList[1] > 0.2f)
            {
                fullString += "\nToo loud at the wrong times for a good jump scare.";
            }

            fullString += "\nNeed to scare right in the middle.";
            BadEnd("Didn't pass the scaring at the right time test:" + fullString);
        } else
        {
            audioSource.clip = Final;
            audioSource.Play();
            Invoke("FinalScreenWin", Final.length + 1);
        }
        
    }

    public void FinalScreenWin()
    {
        EndPanelWin.SetActive(true);
        GamePanel.SetActive(false);
        IntroClipButton.SetActive(true);
        YourselfClipButton.SetActive(true);
        TimeClipButton.SetActive(true);
        TestClipButton.SetActive(true);
        ClipPanel.SetActive(true);
    }

    public void FinalScreenLose()
    {
        EndPanelLose.SetActive(true);
        GamePanel.SetActive(false);
        ClipPanel.SetActive(true);

        if (savedIntro != null) IntroClipButton.SetActive(true);
        if (savedYourself != null) YourselfClipButton.SetActive(true);
        if (savedAboutATime != null) TimeClipButton.SetActive(true);
        if (savedTest != null) TestClipButton.SetActive(true);
    }

    public void playIntroClip()
    {
        audioSource.clip = savedIntro;
        audioSource.Play();
    }

    public void playYourselfClip()
    {
        audioSource.clip = savedYourself;
        audioSource.Play();
    }

    public void playATimeClip()
    {
        audioSource.clip = savedAboutATime;
        audioSource.Play();
    }

    public void playTestClip()
    {
        audioSource.clip = savedTest;
        audioSource.Play();
    }

    public void PrintSampleData(AudioClip clipToUse)
    {
        float[] samples = new float[clipToUse.samples * clipToUse.channels];
        clipToUse.GetData(samples, 0);
        float bigNumber = 0f;
        int numberBeyondPointFive = 0;
        
        for (int i = 0; i < samples.Length; ++i)
        {
            if (i % 1000 == 0)
            {
                Debug.Log($"[{i}]:[{samples[i]}");
            }
            
            bigNumber += samples[i];
            if (Mathf.Abs(samples[i]) > 0.005f)
            {
                numberBeyondPointFive++;
            }
        }
        float percentBeyondPointFive =  (float) numberBeyondPointFive / (float) samples.Length;
        float averageNumber = bigNumber / samples.Length;
        Debug.Log($"Average Sample:{averageNumber}");
        Debug.Log($"PercentBeyondPoint5:{percentBeyondPointFive}, number beyondpoint5 {numberBeyondPointFive}");
        Debug.Log($"Total Samples:{samples.Length}");
    }

    public List<float> noisyInAndOutOfRange(AudioClip clipToUse, int sampleStart, int sampleEnd)
    {
        float[] samples = new float[clipToUse.samples * clipToUse.channels];
        clipToUse.GetData(samples, 0);
        int numberNoisyInRange = 0;
        int numberInRangeSamplesTotal = 0;
        int numberNoisyOutOfRange = 0;
        int numberOutOfRangeTotal = 0;

        for (int i = 0; i < samples.Length; ++i)
        {
            if (i > sampleStart && i < sampleEnd)
            {
                numberInRangeSamplesTotal++;
                if (Mathf.Abs(samples[i]) > 0.005f)
                {
                    numberNoisyInRange++;
                }
            } else
            {
                numberOutOfRangeTotal++;
                if (Mathf.Abs(samples[i]) > 0.005f)
                {
                    numberNoisyOutOfRange++;
                }
            }
            
        }
        float NoisyPercentInRange = (float)numberNoisyInRange / (float)numberInRangeSamplesTotal;
        float NoisyPercentOutOfRange = (float)numberNoisyOutOfRange / (float)numberOutOfRangeTotal;

        List<float> noisyList = new List<float>();
        noisyList.Add(NoisyPercentInRange);
        noisyList.Add(NoisyPercentOutOfRange);
        return noisyList;
    }

    public float getPercentNoisy(AudioClip clipToUse)
    {
        float[] samples = new float[clipToUse.samples * clipToUse.channels];
        clipToUse.GetData(samples, 0);
        //float bigNumber = 0f;
        int numberBeyondPointFive = 0;

        for (int i = 0; i < samples.Length; ++i)
        {
            if (i % 1000 == 0)
            {
                Debug.Log($"[{i}]:[{samples[i]}");
            }

            //bigNumber += samples[i];
            if (Mathf.Abs(samples[i]) > 0.005f)
            {
                numberBeyondPointFive++;
            }
        }
        float percentBeyondPointFive = (float)numberBeyondPointFive / (float)samples.Length;
        //float averageNumber = bigNumber / samples.Length;
        //Debug.Log($"Average Sample:{averageNumber}");
        Debug.Log($"PercentBeyondPoint5:{percentBeyondPointFive}, number beyondpoint5 {numberBeyondPointFive}");
        return percentBeyondPointFive;
    }




    public void StartRecording(int ClipIndex, int timeForRecording)
    {
        
        Invoke("FinishRecording", timeForRecording);
        
    }
    public void FinishRecording()
    {

    }
    

    void stopRecording()
    {
        Debug.Log("recording ended");
        Microphone.End("");
        AudioSource audio = GetComponent<AudioSource>();
       // audio.clip = savedClip;

        audio.Play();
    }


    //Loudness check help is here -+ https://forum.unity.com/threads/check-current-microphone-input-volume.133501/
}
