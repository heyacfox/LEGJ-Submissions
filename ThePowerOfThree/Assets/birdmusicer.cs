using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class birdmusicer : MonoBehaviour
{
    public TMP_Text messageText;
    public TMP_Text nameText;
    
    public string storedMessage;
    public string musicianName;
    public musicianType mType;

    public float writeSpeed = 0.05f;

    public musicianType taggedByPlayerAs;
    

    public void setupMusicer(string message, string name, musicianType musicType)
    {
        mType = musicType;
        storedMessage = message;
        musicianName = name;
        nameText.text = name;
        messageText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("displayMessageOverTime");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hideMessage();
        }   
    }

    IEnumerator displayMessageOverTime()
    {
        int chars = storedMessage.Length;
        int curDisplay = 0;
        while (curDisplay < chars)
        {
            messageText.text = messageText.text + storedMessage.Substring(curDisplay, 1);
            curDisplay++;
            yield return new WaitForSeconds(writeSpeed);
            //beep noise
        }
    }

    public void hideMessage()
    {
        messageText.text = "";
        StopAllCoroutines();    
    }
}

public enum musicianType
{
    drummer,
    guitarist,
    bassist
}
